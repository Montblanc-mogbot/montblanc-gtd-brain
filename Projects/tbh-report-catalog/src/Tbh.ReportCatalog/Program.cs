using Tbh.Extract.Implementations;
using Tbh.Extract.Interfaces;
using Tbh.Analytics.Builders;
using Tbh.Analytics.Models;
using Tbh.Reports.Generators;
using Tbh.Normalize;
using Tbh.Normalize.Csv;

namespace Tbh.ReportCatalog;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("TBH Report Catalog - Plant Performance Demo");
        Console.WriteLine("===========================================\n");
        
        // Path to dummy database
        // Prefer the unified Command Alkon dummy DB built by scripts/sqlite/build_dummy_db.py
        var projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", ".."));

        var dbCandidates = new[]
        {
            Path.Combine(projectRoot, "data", "command_alkon_dummy.db"),
            Path.Combine(projectRoot, "data", "tbh_dummy.sqlite"),
        };

        var dbPath = dbCandidates.FirstOrDefault(File.Exists);
        if (dbPath is null)
        {
            Console.WriteLine("No dummy database found. Expected one of:");
            foreach (var p in dbCandidates) Console.WriteLine($"  - {p}");
            Console.WriteLine("Hint: run: python scripts/sqlite/build_dummy_db.py");
            return;
        }

        Console.WriteLine($"Using database: {dbPath}\n");
        
        // Create extractor
        ICommandAlkonExtractor extractor = new SqliteCommandAlkonExtractor(dbPath);
        
        // Parse reporting period from args or default to January 2025
        DateTime startDate, endDate;
        if (args.Length >= 2 && DateTime.TryParse(args[0], out var s) && DateTime.TryParse(args[1], out var e))
        {
            startDate = s;
            endDate = e;
        }
        else
        {
            startDate = new DateTime(2025, 1, 1);
            endDate = new DateTime(2025, 2, 1);
        }
        
        Console.WriteLine($"Extracting normalized datasets: {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}");

        // Master data (always present in our dummy DB)
        var plants = (await extractor.ExtractPlantsAsync())
            .Select(CommandAlkonMasterDataNormalizer.Normalize)
            .ToList();
        var customers = (await extractor.ExtractCustomersAsync())
            .Select(CommandAlkonMasterDataNormalizer.Normalize)
            .ToList();
        var items = (await extractor.ExtractItemsAsync())
            .Select(CommandAlkonMasterDataNormalizer.Normalize)
            .ToList();
        var uoms = (await extractor.ExtractUomsAsync())
            .Select(CommandAlkonMasterDataNormalizer.Normalize)
            .ToList();

        // Billing/AR transactions (ITRN)
        var itrn = (await extractor.ExtractItrnAsync(startDate, endDate))
            .Select(CommandAlkonItrnNormalizer.Normalize)
            .ToList();

        // AR trial balance / open items (ARTB) - optional alternate AR truth
        var artb = (await extractor.ExtractArtbAsync(startDate, endDate)).ToList();

        // Dispatch-side extracts (TICK/TKTL/ORDR). Not all dummy DBs include these tables.
        List<Tbh.Normalize.NormalizedTicket> tick = [];
        List<Tbh.Normalize.NormalizedTicketLine> tktl = [];
        List<Tbh.Normalize.NormalizedOrderHeader> ordr = [];

        try
        {
            var tickRaw = (await extractor.ExtractTicketsAsync(startDate, endDate)).ToList();
            var tktlRaw = (await extractor.ExtractTicketLinesAsync(startDate, endDate)).ToList();
            var ordrRaw = (await extractor.ExtractOrdersAsync(startDate, endDate)).ToList();

            tick = tickRaw.Select(CommandAlkonDispatchNormalizer.Normalize).ToList();
            tktl = tktlRaw.Select(CommandAlkonDispatchNormalizer.Normalize).ToList();
            ordr = ordrRaw.Select(CommandAlkonDispatchNormalizer.Normalize).ToList();

            // Normalization: exclude removed tickets and their lines (auditable filter)
            tick = tick.Where(t => string.IsNullOrWhiteSpace(t.RemoveReasonCode)).ToList();
            var validTicketKeys = new HashSet<(DateTime?, string, string)>(
                tick.Select(t => (t.OrderDate, t.OrderCode, t.TicketCode))
            );
            tktl = tktl.Where(l => validTicketKeys.Contains((l.OrderDate, l.OrderCode, l.TicketCode))).ToList();

            // Normalization: replace UOM codes with UOM descriptions from UOMS reference table (auditable mapping)
            var uomNameByCode = uoms
                .Where(u => !string.IsNullOrWhiteSpace(u.UomCode))
                .ToDictionary(
                    u => u.UomCode.Trim(),
                    u => (u.Name ?? string.Empty).Trim(),
                    StringComparer.OrdinalIgnoreCase);

            string MapUom(string code)
            {
                if (string.IsNullOrWhiteSpace(code)) return string.Empty;
                return uomNameByCode.TryGetValue(code, out var name) && !string.IsNullOrWhiteSpace(name)
                    ? name
                    : code;
            }

            tktl = tktl
                .Select(l => l with
                {
                    DeliveredQtyUom = MapUom(l.DeliveredQtyUom)
                })
                .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  Dispatch export skipped (missing tables?): {ex.Message}");
        }

        // Normalized CSV output convention:
        //   YYYYMM(DD) ReportName
        // Use day only when the date range is not a clean whole-month window.
        var normalizedDir = Path.Combine(projectRoot, "normalized");
        Directory.CreateDirectory(normalizedDir);

        static bool IsWholeMonthWindow(DateTime start, DateTime end) =>
            start.Day == 1 && end.Day == 1 && end == start.AddMonths(1);

        var prefix = IsWholeMonthWindow(startDate, endDate)
            ? startDate.ToString("yyyyMM")
            : startDate.ToString("yyyyMMdd");

        var plantsOut = Path.Combine(normalizedDir, $"{prefix} Plants.csv");
        var customersOut = Path.Combine(normalizedDir, $"{prefix} Customers.csv");
        var itemsOut = Path.Combine(normalizedDir, $"{prefix} Items.csv");
        var itrnOut = Path.Combine(normalizedDir, $"{prefix} InvoiceTransactions.csv");
        var uomsOut = Path.Combine(normalizedDir, $"{prefix} Uoms.csv");

        var tickOut = Path.Combine(normalizedDir, $"{prefix} Tickets.csv");
        var tktlOut = Path.Combine(normalizedDir, $"{prefix} TicketLines.csv");
        var ordrOut = Path.Combine(normalizedDir, $"{prefix} Orders.csv");

        // Keep normalized schemas narrow; add fields only when a downstream report needs them.
        await NormalizedCsvWriter.WriteAsync(plants, plantsOut,
        [
            ("plant_code", r => r.PlantCode),
            ("short_name", r => r.ShortName),
            ("name", r => r.Name),
            ("location", r => r.Location),
        ]);

        await NormalizedCsvWriter.WriteAsync(customers, customersOut,
        [
            ("cust_code", r => r.CustomerCode),
            ("name", r => r.Name),
            ("city", r => r.City),
            ("state", r => r.State),
        ]);

        await NormalizedCsvWriter.WriteAsync(items, itemsOut,
        [
            ("item_code", r => r.ItemCode),
            ("short_descr", r => r.ShortDescription),
            ("descr", r => r.Description),
            ("item_cat", r => r.ItemCategory),
            ("matl_type", r => r.MaterialType),
        ]);

        await NormalizedCsvWriter.WriteAsync(uoms, uomsOut,
        [
            ("uom", r => r.UomCode),
            ("name", r => r.Name),
            ("abbr", r => r.Abbreviation),
        ]);

        await NormalizedCsvWriter.WriteAsync(itrn, itrnOut,
        [
            ("trans_date", r => r.TransactionDate?.ToString("yyyy-MM-dd") ?? ""),
            ("invc_code", r => r.InvoiceCode ?? ""),
            ("trans_type", r => r.TransactionType ?? ""),
            ("cust_code", r => r.CustomerCode ?? ""),
            ("pretax_amt", r => r.PretaxAmount.ToString()),
            ("tax_amt", r => r.TaxAmount.ToString()),
            ("pmt_amt", r => r.PaymentAmount.ToString()),
            ("check_amt", r => r.CheckAmount.ToString()),
        ]);

        await NormalizedCsvWriter.WriteAsync(tick, tickOut,
        [
            ("order_date", r => r.OrderDate?.ToString("yyyy-MM-dd") ?? ""),
            ("order_code", r => r.OrderCode),
            ("tkt_code", r => r.TicketCode),
            ("tkt_date", r => r.TicketDate?.ToString("yyyy-MM-dd") ?? ""),
            ("ship_plant_code", r => r.ShipPlantCode),
            ("truck_code", r => r.TruckCode),
            ("remove_rsn_code", r => r.RemoveReasonCode),
            ("invc_flag", r => r.InvcFlag),
            ("invc_code", r => r.InvcCode),
        ]);

        await NormalizedCsvWriter.WriteAsync(tktl, tktlOut,
        [
            ("order_date", r => r.OrderDate?.ToString("yyyy-MM-dd") ?? ""),
            ("order_code", r => r.OrderCode),
            ("tkt_code", r => r.TicketCode),
            ("order_intrnl_line_num", r => r.OrderInternalLineNum?.ToString() ?? ""),
            ("ship_plant_code", r => r.ShipPlantCode),
            ("delv_qty", r => r.DeliveredQty?.ToString() ?? ""),
            ("delv_qty_uom", r => r.DeliveredQtyUom),
            ("ext_price_amt", r => r.ExtendedPriceAmount?.ToString() ?? ""),
        ]);

        await NormalizedCsvWriter.WriteAsync(ordr, ordrOut,
        [
            ("order_date", r => r.OrderDate?.ToString("yyyy-MM-dd") ?? ""),
            ("order_code", r => r.OrderCode),
            // prod_line_code removed (not informative in this dataset)
            ("cust_code", r => r.CustomerCode),
            ("cust_name", r => r.CustomerName),
            ("proj_code", r => r.ProjectCode),
        ]);

        Console.WriteLine($"  PLNT: {plants.Count} rows -> {plantsOut}");
        Console.WriteLine($"  CUST: {customers.Count} rows -> {customersOut}");
        Console.WriteLine($"  IMST: {items.Count} rows -> {itemsOut}");
        Console.WriteLine($"  UOMS: {uoms.Count} rows -> {uomsOut}");
        Console.WriteLine($"  ITRN: {itrn.Count} rows -> {itrnOut}");
        Console.WriteLine($"  TICK: {tick.Count} rows -> {tickOut}");
        Console.WriteLine($"  TKTL: {tktl.Count} rows -> {tktlOut}");
        Console.WriteLine($"  ORDR: {ordr.Count} rows -> {ordrOut}\n");

        // === Analytical datasets (each answers one business question well) ===
        var analyticsDir = Path.Combine(projectRoot, "analytics");
        Directory.CreateDirectory(analyticsDir);

        // Concrete UOMs are expressed as UOM *descriptions* (because normalization replaces codes with names).
        // Rule: treat UOMS 40003/40005 as concrete yards, plus any UOM whose abbreviation is "cy".
        var concreteUoms = new HashSet<string>(
            uoms
                .Where(u => u.UomCode is "40003" or "40005" || string.Equals(u.Abbreviation, "cy", StringComparison.OrdinalIgnoreCase))
                .Select(u => u.Name)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim()),
            StringComparer.OrdinalIgnoreCase);

        // Fallbacks in case a site uses literal text instead of UOMS mapping.
        concreteUoms.Add("Cubic Yards");
        concreteUoms.Add("Cubic Yard");
        concreteUoms.Add("CY");
        concreteUoms.Add("CYARD");

        var dispatchPlantDay = Tbh.Analytics.Builders.DispatchAnalyticsBuilders.BuildDispatchPlantDay(tick, tktl, concreteUoms).ToList();
        var dispatchInvoiceTotals = Tbh.Analytics.Builders.DispatchAnalyticsBuilders.BuildDispatchInvoiceTotals(tick, tktl).ToList();
        var dispatchVsArRecon = Tbh.Analytics.Builders.DispatchAnalyticsBuilders.BuildDispatchVsArInvoiceRecon(dispatchInvoiceTotals, itrn).ToList();

        // ARTB-based AR totals (alternate view)
        var arByInvoiceArtb = artb
            .Where(r => r.PrimaryTransactionType == "11")
            .Where(r => !string.IsNullOrWhiteSpace(r.InvoiceCode))
            .GroupBy(r => r.InvoiceCode!.Trim())
            .Select(g => new
            {
                InvoiceCode = g.Key,
                Sales = g.Sum(x => x.SalesAmount ?? 0m),
                Tax = g.Sum(x => x.TaxAmount ?? 0m),
            })
            .ToDictionary(x => x.InvoiceCode);

        var dispatchVsArtbRecon = dispatchInvoiceTotals
            .Select(d =>
            {
                arByInvoiceArtb.TryGetValue(d.InvoiceCode, out var ar);
                var arTotal = (ar?.Sales ?? 0m) + (ar?.Tax ?? 0m);
                return new
                {
                    d.InvoiceCode,
                    DispatchRevenue = d.DispatchRevenue,
                    ArtbSales = ar?.Sales ?? 0m,
                    ArtbTax = ar?.Tax ?? 0m,
                    ArtbTotal = arTotal,
                    Difference = d.DispatchRevenue - arTotal,
                };
            })
            .OrderBy(r => r.InvoiceCode)
            .ToList();

        var dispatchUomSummary = Tbh.Analytics.Builders.DispatchUomSummaryBuilder
            .BuildDispatchUomSummary(tick, tktl)
            .ToList();

        var plantDayOut = Path.Combine(analyticsDir, $"{prefix} DispatchPlantDay.csv");
        var reconOut = Path.Combine(analyticsDir, $"{prefix} DispatchVsAR_ByInvoice.csv");
        var reconArtbOut = Path.Combine(analyticsDir, $"{prefix} DispatchVsAR_ByInvoice_ARTB.csv");
        var uomSummaryOut = Path.Combine(analyticsDir, $"{prefix} DispatchUomSummary.csv");

        await NormalizedCsvWriter.WriteAsync(dispatchPlantDay, plantDayOut,
        [
            ("day", r => r.Day.ToString("yyyy-MM-dd")),
            ("plant_code", r => r.PlantCode),
            ("quantity", r => r.Quantity.ToString()),
            ("revenue", r => r.Revenue.ToString()),
            ("ticket_count", r => r.TicketCount.ToString()),
            ("unique_truck_count", r => r.UniqueTruckCount.ToString()),
        ]);

        // DispatchPlantMonth removed (extraneous vs daily + month rollups can be produced from DispatchPlantDay when needed).

        await NormalizedCsvWriter.WriteAsync(dispatchVsArRecon, reconOut,
        [
            ("invc_code", r => r.InvoiceCode),
            ("dispatch_revenue", r => r.DispatchRevenue.ToString()),
            ("ar_total", r => r.ArTotalAmount.ToString()),
            ("difference", r => r.Difference.ToString()),
        ]);

        await NormalizedCsvWriter.WriteAsync(dispatchVsArtbRecon, reconArtbOut,
        [
            ("invc_code", r => r.InvoiceCode),
            ("dispatch_revenue", r => r.DispatchRevenue.ToString()),
            ("artb_sales_amt", r => r.ArtbSales.ToString()),
            ("artb_tax_amt", r => r.ArtbTax.ToString()),
            ("artb_total", r => r.ArtbTotal.ToString()),
            ("difference", r => r.Difference.ToString()),
        ]);

        // ARInvoiceTotals_ARTB removed (redundant; ARTB totals are included directly in DispatchVsAR_ByInvoice_ARTB).

        // DispatchLoadsVolumeByDayPlant_ProductLine_Uom removed (product line is not informative in CA extracts; keep UOM drilldowns in DispatchUomSummary).

        await NormalizedCsvWriter.WriteAsync(dispatchUomSummary, uomSummaryOut,
        [
            ("day", r => r.Day.ToString("yyyy-MM-dd")),
            ("plant_code", r => r.PlantCode),
            ("delv_qty_uom", r => r.DeliveredQtyUom),
            ("delv_qty", r => r.DeliveredQty.ToString()),
            ("revenue", r => r.Revenue.ToString()),
            ("ticket_line_count", r => r.TicketLineCount.ToString()),
        ]);

        Console.WriteLine($"  ANALYTICS: {dispatchPlantDay.Count} rows -> {plantDayOut}");
        Console.WriteLine($"  ANALYTICS: {dispatchVsArRecon.Count} rows -> {reconOut}");
        Console.WriteLine($"  ANALYTICS: {dispatchVsArtbRecon.Count} rows -> {reconArtbOut}");
        Console.WriteLine($"  ANALYTICS: {dispatchUomSummary.Count} rows -> {uomSummaryOut}\n");

        try
        {
            Console.WriteLine($"Extracting sales detail (legacy ORDL-backed): {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}");

            // Extract data
            var salesDetails = await extractor.ExtractSalesDetailAsync(startDate, endDate);
            var salesList = salesDetails.ToList();

            Console.WriteLine($"  Retrieved {salesList.Count} records\n");

            // Build Plant Performance analytics
            Console.WriteLine("Building Plant Performance analytics...");
            var builder = new PlantPerformanceBuilder();
            var plantPerformance = builder.Build(salesList);

            var perfList = plantPerformance.ToList();
            Console.WriteLine($"  Generated {perfList.Count} plant-month records\n");

            // Display results
            Console.WriteLine("=== Plant Performance Summary ===");
            Console.WriteLine(string.Format("{0,-8} {1,-8} {2,-12} {3,-14} {4,-14} {5}", "Plant", "Month", "Volume", "Revenue", "Material Cost", "Margin %"));
            Console.WriteLine(new string('-', 80));

            foreach (var pp in perfList.OrderBy(p => p.PlantCode).ThenBy(p => p.AccountingPeriod))
            {
                var margin = pp.Revenue > 0
                    ? (pp.Revenue - (pp.EstimatedMaterialCost)) / pp.Revenue * 100
                    : 0;

                var month = new DateTime(pp.AccountingYear, pp.AccountingPeriod, 1);
                Console.WriteLine($"{pp.PlantCode,-8} {month:MM/yyyy,-8} {pp.TotalYards,-12:N2} ${pp.Revenue,-14:N2} ${pp.EstimatedMaterialCost,-14:N2} {margin,6:F1}%");
            }

            Console.WriteLine();

            // Generate Excel report (legacy Plant Performance demo)
            var outputPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                $"PlantPerformance_{startDate:yyyyMMdd}_{endDate:yyyyMMdd}.xlsx");

            Console.WriteLine($"Generating Excel report: {outputPath}");

            var excelGenerator = new PlantPerformanceExcelGenerator();
            await excelGenerator.GenerateAsync(perfList, outputPath);

            Console.WriteLine("  Done!\n");

            // Generate dispatch/billing validation pack (January 2025)
            var reportsDir = Path.Combine(projectRoot, "reports");
            Directory.CreateDirectory(reportsDir);

            var dispatchPackPath = Path.Combine(reportsDir, "202501 DispatchBilling Verification Pack.xlsx");
            Console.WriteLine($"Generating Excel report: {dispatchPackPath}");

            var dispatchPack = new Tbh.Reports.Generators.DispatchCfoPackExcelGenerator();
            await dispatchPack.GenerateAsync(startDate, endDate, plants, tick, tktl, itrn, dispatchPackPath);

            Console.WriteLine("  Done!\n");

            // Summary stats
            var totalRevenue = perfList.Sum(p => p.Revenue);
            var totalMatlCost = perfList.Sum(p => p.EstimatedMaterialCost);
            var totalVolume = perfList.Sum(p => p.TotalYards);
            var overallMargin = totalRevenue > 0 ? (totalRevenue - totalMatlCost) / totalRevenue * 100 : 0;

            Console.WriteLine("=== Overall Statistics ===");
            Console.WriteLine($"Total Volume: {totalVolume:N2} yards");
            Console.WriteLine($"Total Revenue: ${totalRevenue:N2}");
            Console.WriteLine($"Total Material Cost: ${totalMatlCost:N2}");
            Console.WriteLine($"Overall Margin: {overallMargin:F1}%");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Sales detail / Plant Performance demo skipped (missing legacy tables?): {ex.Message}");
        }
    }
}
