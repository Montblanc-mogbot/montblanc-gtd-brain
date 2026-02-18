using Tbh.Analytics.Builders;
using Tbh.Extract.Implementations;
using Tbh.Extract.Interfaces;
using Tbh.Normalize;
using Tbh.Normalize.Csv;
using Tbh.Reports.Generators;

namespace Tbh.ReportCatalog.Pipeline;

public static class PipelineRunner
{
    public static async Task<int> RunAsync(RunContext ctx, CancellationToken cancellationToken = default)
    {
        PipelineIo.EnsureDirectories(ctx);

        var manifest = new RunManifest
        {
            RunStartedAt = DateTime.Now,
            StartDate = ctx.StartDate,
            EndDate = ctx.EndDate,
            Prefix = ctx.Prefix,
            DbPath = ctx.DbPath,
            Artifacts = [],
        };

        Console.WriteLine("TBH Report Catalog");
        Console.WriteLine("==================\n");
        Console.WriteLine($"DB:   {ctx.DbPath}");
        Console.WriteLine($"Window: {ctx.StartDate:yyyy-MM-dd} → {ctx.EndDate:yyyy-MM-dd}");
        Console.WriteLine($"Run dir: {ctx.RunDir}\n");

        ICommandAlkonExtractor extractor = new SqliteCommandAlkonExtractor(ctx.DbPath);

        // ---- Layer 1 → 2: Extract + Normalize ----
        Console.WriteLine("Extract + Normalize");
        Console.WriteLine("-------------------");

        var plants = (await extractor.ExtractPlantsAsync(cancellationToken)).Select(CommandAlkonMasterDataNormalizer.Normalize).ToList();
        var customers = (await extractor.ExtractCustomersAsync(cancellationToken)).Select(CommandAlkonMasterDataNormalizer.Normalize).ToList();
        var items = (await extractor.ExtractItemsAsync(cancellationToken)).Select(CommandAlkonMasterDataNormalizer.Normalize).ToList();
        var uoms = (await extractor.ExtractUomsAsync(cancellationToken)).Select(CommandAlkonMasterDataNormalizer.Normalize).ToList();

        var itrn = (await extractor.ExtractItrnAsync(ctx.StartDate, ctx.EndDate, cancellationToken)).Select(CommandAlkonItrnNormalizer.Normalize).ToList();
        var artb = (await extractor.ExtractArtbAsync(ctx.StartDate, ctx.EndDate, cancellationToken)).ToList();

        List<NormalizedTicket> tick = [];
        List<NormalizedTicketLine> tktl = [];
        List<NormalizedOrderHeader> ordr = [];
        var tktc = new List<Tbh.Extract.Models.CommandAlkon.TicketChargeRecord>();

        try
        {
            var tickRaw = (await extractor.ExtractTicketsAsync(ctx.StartDate, ctx.EndDate, cancellationToken)).ToList();
            var tktlRaw = (await extractor.ExtractTicketLinesAsync(ctx.StartDate, ctx.EndDate, cancellationToken)).ToList();
            var tktcRaw = (await extractor.ExtractTicketChargesAsync(ctx.StartDate, ctx.EndDate, cancellationToken)).ToList();
            var ordrRaw = (await extractor.ExtractOrdersAsync(ctx.StartDate, ctx.EndDate, cancellationToken)).ToList();

            tick = tickRaw.Select(CommandAlkonDispatchNormalizer.Normalize).ToList();
            tktl = tktlRaw.Select(CommandAlkonDispatchNormalizer.Normalize).ToList();
            ordr = ordrRaw.Select(CommandAlkonDispatchNormalizer.Normalize).ToList();
            tktc = tktcRaw;

            // Normalization rule: exclude removed tickets and their lines/charges (auditable).
            tick = tick.Where(t => string.IsNullOrWhiteSpace(t.RemoveReasonCode)).ToList();
            var validTicketKeys = new HashSet<(DateTime?, string, string)>(tick.Select(t => (t.OrderDate, t.OrderCode, t.TicketCode)));
            tktl = tktl.Where(l => validTicketKeys.Contains((l.OrderDate, l.OrderCode, l.TicketCode))).ToList();

            // Normalization rule: replace UOM codes with UOM descriptions (auditable mapping).
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
                .Select(l => l with { DeliveredQtyUom = MapUom(l.DeliveredQtyUom) })
                .ToList();

            // Normalize and filter TKTC to the same ticket keyspace.
            var tktcNorm = tktc
                .Select(c => new
                {
                    c.OrderDate,
                    OrderCode = CommandAlkonDispatchNormalizer.NormalizeCode(c.OrderCode),
                    TicketCode = CommandAlkonDispatchNormalizer.NormalizeCode(c.TicketCode),
                    TicketChargeCode = CommandAlkonDispatchNormalizer.NormalizeCode(c.TicketChargeCode),
                    DeliveredQty = c.DeliveredQty,
                    DeliveredQtyUom = MapUom(CommandAlkonDispatchNormalizer.NormalizeCode(c.DeliveredQtyUom).ToUpperInvariant()),
                    ExtendedPriceAmount = c.ExtendedPriceAmount,
                })
                .Where(c => validTicketKeys.Contains((c.OrderDate, c.OrderCode, c.TicketCode)))
                .ToList();

            // Ticket-grain dispatch revenue components (safe to store on Tickets.csv).
            var productAmtByTicket = tktl
                .GroupBy(l => (l.OrderDate, l.OrderCode, l.TicketCode))
                .ToDictionary(g => g.Key, g => g.Sum(x => x.ExtendedPriceAmount ?? 0m));

            var chargeAmtByTicket = tktcNorm
                .GroupBy(c => (c.OrderDate, c.OrderCode, c.TicketCode))
                .ToDictionary(g => g.Key, g => g.Sum(x => x.ExtendedPriceAmount ?? 0m));

            // Invoice paid-in-full flag derived from ITRN.
            var invoiceStatusByCode = itrn
                .Where(r => !string.IsNullOrWhiteSpace(r.InvoiceCode))
                .GroupBy(r => r.InvoiceCode!.Trim())
                .ToDictionary(
                    g => g.Key,
                    g =>
                    {
                        var billed = g.Sum(x => x.TotalAmount);
                        var paid = g.Sum(x => x.PaymentAmount + x.CheckAmount);
                        var open = billed - paid;
                        var isPaid = open <= 0.01m;
                        return (billed, paid, open, isPaid);
                    },
                    StringComparer.OrdinalIgnoreCase);

            tick = tick
                .Select(t =>
                {
                    var key = (t.OrderDate, t.OrderCode, t.TicketCode);
                    var prod = productAmtByTicket.TryGetValue(key, out var p) ? p : 0m;
                    var chg = chargeAmtByTicket.TryGetValue(key, out var c) ? c : 0m;

                    bool? paidInFull = null;
                    if (!string.IsNullOrWhiteSpace(t.InvcCode) && invoiceStatusByCode.TryGetValue(t.InvcCode, out var st))
                    {
                        paidInFull = st.isPaid;
                    }

                    return t with
                    {
                        TicketProductAmount = prod,
                        TicketChargeAmount = chg,
                        InvoicePaidInFull = paidInFull,
                    };
                })
                .ToList();

            // Order-grain derived fields.
            var ticketCountByOrder = tick
                .GroupBy(t => (t.OrderDate, t.OrderCode))
                .ToDictionary(g => g.Key, g => g.Select(x => x.TicketCode).Distinct().Count());

            ordr = ordr
                .Select(o =>
                {
                    var key = (o.OrderDate, o.OrderCode);
                    var tc = ticketCountByOrder.TryGetValue(key, out var count) ? count : 0;
                    return o with { TicketCount = tc };
                })
                .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  Dispatch extract skipped (missing tables?): {ex.Message}");
        }

        // Build normalized invoice entity (1 row per invoice) from ITRN (+ ARTB enrichment).
        var itrnByInvoice = itrn
            .Where(r => !string.IsNullOrWhiteSpace(r.InvoiceCode))
            .GroupBy(r => r.InvoiceCode!.Trim(), StringComparer.OrdinalIgnoreCase)
            .ToDictionary(g => g.Key, g => g.ToList(), StringComparer.OrdinalIgnoreCase);

        var artbByInvoice = artb
            .Where(r => r.PrimaryTransactionType == "11")
            .Where(r => !string.IsNullOrWhiteSpace(r.InvoiceCode))
            .GroupBy(r => r.InvoiceCode!.Trim(), StringComparer.OrdinalIgnoreCase)
            .ToDictionary(g => g.Key, g => g.ToList(), StringComparer.OrdinalIgnoreCase);

        var allInvoiceCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var k in itrnByInvoice.Keys) allInvoiceCodes.Add(k);
        foreach (var k in artbByInvoice.Keys) allInvoiceCodes.Add(k);

        var invoices = allInvoiceCodes
            .Select(code =>
            {
                itrnByInvoice.TryGetValue(code, out var itrnRows);
                artbByInvoice.TryGetValue(code, out var artbRows);

                var customerCode = itrnRows?.Select(x => x.CustomerCode).FirstOrDefault(x => !string.IsNullOrWhiteSpace(x))
                    ?? artbRows?.Select(x => x.CustomerCode).FirstOrDefault(x => !string.IsNullOrWhiteSpace(x));

                var plantCode = itrnRows?.Select(x => x.PlantCode).FirstOrDefault(x => !string.IsNullOrWhiteSpace(x));

                var invoiceDate = itrnRows?.Select(x => x.TransactionDate).Where(x => x != null).Min();

                var sales = artbRows?.Sum(x => x.SalesAmount ?? 0m)
                    ?? itrnRows?.Sum(x => x.PretaxAmount)
                    ?? 0m;

                var tax = artbRows?.Sum(x => x.TaxAmount ?? 0m)
                    ?? itrnRows?.Sum(x => x.TaxAmount)
                    ?? 0m;

                var payments = itrnRows?.Sum(x => x.PaymentAmount + x.CheckAmount) ?? 0m;
                var billed = (itrnRows?.Sum(x => x.TotalAmount) ?? 0m);
                var open = billed - payments;

                // Prefer ARTB current balance if present (often closer to "open items" semantics).
                var artbCurrBal = artbRows?.Select(x => x.CurrentBalanceAmount).FirstOrDefault(x => x != null);
                if (artbCurrBal != null) open = artbCurrBal.Value;

                var dueDate = artbRows?.Select(x => x.DueDate).FirstOrDefault(x => x != null);
                var latestPmtDate = artbRows?.Select(x => x.LatestPaymentDate).FirstOrDefault(x => x != null);

                var isPaid = open <= 0.01m;

                return new NormalizedInvoice
                {
                    InvoiceCode = code,
                    CustomerCode = customerCode,
                    PlantCode = plantCode,
                    InvoiceDate = invoiceDate,
                    DueDate = dueDate,
                    LatestPaymentDate = latestPmtDate,
                    SalesAmount = sales,
                    TaxAmount = tax,
                    PaymentsAmount = payments,
                    OpenBalanceAmount = open,
                    IsPaidInFull = isPaid,
                };
            })
            .OrderBy(i => i.InvoiceCode)
            .ToList();

        // Write normalized to immutable run dir (then copy to latest)
        await WriteNormalizedAsync(ctx, manifest, plants, customers, items, uoms, itrn, invoices, tick, tktl, ordr);

        // ---- Layer 3: Analytics ----
        Console.WriteLine("\nAnalytics");
        Console.WriteLine("---------");

        var concreteUoms = new HashSet<string>(
            uoms
                .Where(u => u.UomCode is "40003" or "40005" || string.Equals(u.Abbreviation, "cy", StringComparison.OrdinalIgnoreCase))
                .Select(u => u.Name)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x!.Trim()),
            StringComparer.OrdinalIgnoreCase);
        concreteUoms.Add("Cubic Yards");
        concreteUoms.Add("Cubic Yard");
        concreteUoms.Add("CY");
        concreteUoms.Add("CYARD");

        var dispatchPlantDay = DispatchAnalyticsBuilders.BuildDispatchPlantDay(tick, tktl, concreteUoms).ToList();
        var dispatchPlantMonth = DispatchPlantMonthBuilder.BuildDispatchPlantMonth(tick, tktl, concreteUoms).ToList();

        var truckDay = TruckUtilizationBuilder.BuildTruckDay(tick, tktl, concreteUoms).ToList();
        var truckMonth = TruckUtilizationBuilder.BuildTruckMonth(truckDay).ToList();
        var plantShippingDaysMonth = TruckUtilizationBuilder.BuildPlantShippingDaysMonth(truckDay).ToList();

        var dispatchInvoiceTotals = DispatchAnalyticsBuilders.BuildDispatchInvoiceTotals(tick, tktl).ToList();
        var dispatchVsArRecon = DispatchAnalyticsBuilders.BuildDispatchVsArInvoiceRecon(dispatchInvoiceTotals, itrn).ToList();

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
                return new DispatchVsArtbReconRow
                {
                    InvoiceCode = d.InvoiceCode,
                    DispatchRevenue = d.DispatchRevenue,
                    ArtbSales = ar?.Sales ?? 0m,
                    ArtbTax = ar?.Tax ?? 0m,
                    ArtbTotal = arTotal,
                    Difference = d.DispatchRevenue - arTotal,
                };
            })
            .OrderBy(r => r.InvoiceCode)
            .ToList();

        var dispatchUomSummary = DispatchUomSummaryBuilder.BuildDispatchUomSummary(tick, tktl).ToList();

        await WriteAnalyticsAsync(ctx, manifest, dispatchPlantDay, dispatchPlantMonth, truckDay, truckMonth, plantShippingDaysMonth, dispatchVsArRecon, dispatchVsArtbRecon, dispatchUomSummary);

        // ---- Layer 4: Reports ----
        Console.WriteLine("\nReports");
        Console.WriteLine("-------");

        // Dispatch verification pack
        try
        {
            var dispatchPackPathRun = Path.Combine(ctx.RunReportsDir, $"{ctx.Prefix} DispatchBilling Verification Pack.xlsx");
            var dispatchPackPathLatest = Path.Combine(ctx.LatestReportsDir, $"{ctx.Prefix} DispatchBilling Verification Pack.xlsx");

            var generator = new DispatchCfoPackExcelGenerator();
            await generator.GenerateAsync(ctx.StartDate, ctx.EndDate, plants, tick, tktl, itrn, dispatchPackPathRun);
            PipelineIo.CopyToLatest(dispatchPackPathRun, dispatchPackPathLatest);

            manifest.Artifacts.Add(new DatasetArtifact
            {
                Layer = "report",
                Name = "DispatchBilling Verification Pack",
                Path = dispatchPackPathRun,
                RowCount = 0,
                FileBytes = PipelineIo.TryGetFileBytes(dispatchPackPathRun),
            });

            Console.WriteLine($"  REPORT: {dispatchPackPathRun}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  REPORT: Dispatch pack failed: {ex.Message}");
        }

        // Write manifest
        await File.WriteAllTextAsync(ctx.ManifestPath, manifest.ToJson(), cancellationToken);
        Console.WriteLine($"\nManifest: {ctx.ManifestPath}");

        return 0;
    }

    private static async Task WriteNormalizedAsync(
        RunContext ctx,
        RunManifest manifest,
        List<NormalizedPlant> plants,
        List<NormalizedCustomer> customers,
        List<NormalizedItem> items,
        List<NormalizedUom> uoms,
        List<NormalizedItrn> itrn,
        List<NormalizedInvoice> invoices,
        List<NormalizedTicket> tick,
        List<NormalizedTicketLine> tktl,
        List<NormalizedOrderHeader> ordr)
    {
        // Normalized outputs (run)
        var plantsRun = Path.Combine(ctx.RunNormalizedDir, $"{ctx.Prefix} Plants.csv");
        var customersRun = Path.Combine(ctx.RunNormalizedDir, $"{ctx.Prefix} Customers.csv");
        var itemsRun = Path.Combine(ctx.RunNormalizedDir, $"{ctx.Prefix} Items.csv");
        var uomsRun = Path.Combine(ctx.RunNormalizedDir, $"{ctx.Prefix} Uoms.csv");
        var itrnRun = Path.Combine(ctx.RunNormalizedDir, $"{ctx.Prefix} InvoiceTransactions.csv");
        var invoicesRun = Path.Combine(ctx.RunNormalizedDir, $"{ctx.Prefix} Invoices.csv");
        var tickRun = Path.Combine(ctx.RunNormalizedDir, $"{ctx.Prefix} Tickets.csv");
        var tktlRun = Path.Combine(ctx.RunNormalizedDir, $"{ctx.Prefix} TicketLines.csv");
        var ordrRun = Path.Combine(ctx.RunNormalizedDir, $"{ctx.Prefix} Orders.csv");

        await NormalizedCsvWriter.WriteAsync(plants, plantsRun,
        [
            ("plant_code", r => r.PlantCode),
            ("short_name", r => r.ShortName),
            ("name", r => r.Name),
            ("location", r => r.Location),
        ]);

        await NormalizedCsvWriter.WriteAsync(customers, customersRun,
        [
            ("cust_code", r => r.CustomerCode),
            ("name", r => r.Name),
            ("city", r => r.City),
            ("state", r => r.State),
        ]);

        await NormalizedCsvWriter.WriteAsync(items, itemsRun,
        [
            ("item_code", r => r.ItemCode),
            ("short_descr", r => r.ShortDescription),
            ("descr", r => r.Description),
            ("item_cat", r => r.ItemCategory),
            ("matl_type", r => r.MaterialType),
        ]);

        await NormalizedCsvWriter.WriteAsync(uoms, uomsRun,
        [
            ("uom", r => r.UomCode),
            ("name", r => r.Name),
            ("abbr", r => r.Abbreviation),
        ]);

        await NormalizedCsvWriter.WriteAsync(itrn, itrnRun,
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

        await NormalizedCsvWriter.WriteAsync(invoices, invoicesRun,
        [
            ("invc_code", r => r.InvoiceCode),
            ("cust_code", r => r.CustomerCode ?? ""),
            ("plant_code", r => r.PlantCode ?? ""),
            ("invc_date", r => r.InvoiceDate?.ToString("yyyy-MM-dd") ?? ""),
            ("due_date", r => r.DueDate?.ToString("yyyy-MM-dd") ?? ""),
            ("latest_pmt_date", r => r.LatestPaymentDate?.ToString("yyyy-MM-dd") ?? ""),
            ("sales_amt", r => r.SalesAmount.ToString()),
            ("tax_amt", r => r.TaxAmount.ToString()),
            ("total_amt", r => r.TotalAmount.ToString()),
            ("payments_amt", r => r.PaymentsAmount.ToString()),
            ("open_balance_amt", r => r.OpenBalanceAmount.ToString()),
            ("paid_in_full", r => r.IsPaidInFull ? "1" : "0"),
        ]);

        await NormalizedCsvWriter.WriteAsync(tick, tickRun,
        [
            ("order_date", r => r.OrderDate?.ToString("yyyy-MM-dd") ?? ""),
            ("order_code", r => r.OrderCode),
            ("tkt_code", r => r.TicketCode),
            ("tkt_date", r => r.TicketDate?.ToString("yyyy-MM-dd") ?? ""),
            ("ship_plant_code", r => r.ShipPlantCode),
            ("truck_code", r => r.TruckCode),
            ("invc_code", r => r.InvcCode),
            ("invoice_paid_in_full", r => r.InvoicePaidInFull.HasValue ? (r.InvoicePaidInFull.Value ? "1" : "0") : ""),
            ("ticket_product_amt", r => r.TicketProductAmount.ToString()),
            ("ticket_charge_amt", r => r.TicketChargeAmount.ToString()),
            ("ticket_dispatch_total_amt", r => r.TicketDispatchTotalAmount.ToString()),
            ("remove_rsn_code", r => r.RemoveReasonCode),
            ("invc_flag", r => r.InvcFlag),
            ("tkt_status", r => r.TicketStatus),
        ]);

        await NormalizedCsvWriter.WriteAsync(tktl, tktlRun,
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

        await NormalizedCsvWriter.WriteAsync(ordr, ordrRun,
        [
            ("order_date", r => r.OrderDate?.ToString("yyyy-MM-dd") ?? ""),
            ("order_code", r => r.OrderCode),
            ("cust_code", r => r.CustomerCode),
            ("cust_name", r => r.CustomerName),
            ("proj_code", r => r.ProjectCode),
            ("ticket_count", r => r.TicketCount.ToString()),
        ]);

        // Copy to latest
        PipelineIo.CopyToLatest(plantsRun, Path.Combine(ctx.LatestNormalizedDir, Path.GetFileName(plantsRun)));
        PipelineIo.CopyToLatest(customersRun, Path.Combine(ctx.LatestNormalizedDir, Path.GetFileName(customersRun)));
        PipelineIo.CopyToLatest(itemsRun, Path.Combine(ctx.LatestNormalizedDir, Path.GetFileName(itemsRun)));
        PipelineIo.CopyToLatest(uomsRun, Path.Combine(ctx.LatestNormalizedDir, Path.GetFileName(uomsRun)));
        PipelineIo.CopyToLatest(itrnRun, Path.Combine(ctx.LatestNormalizedDir, Path.GetFileName(itrnRun)));
        PipelineIo.CopyToLatest(invoicesRun, Path.Combine(ctx.LatestNormalizedDir, Path.GetFileName(invoicesRun)));
        PipelineIo.CopyToLatest(tickRun, Path.Combine(ctx.LatestNormalizedDir, Path.GetFileName(tickRun)));
        PipelineIo.CopyToLatest(tktlRun, Path.Combine(ctx.LatestNormalizedDir, Path.GetFileName(tktlRun)));
        PipelineIo.CopyToLatest(ordrRun, Path.Combine(ctx.LatestNormalizedDir, Path.GetFileName(ordrRun)));

        void Add(string name, string layer, string path, int rowCount)
        {
            manifest.Artifacts.Add(new DatasetArtifact { Layer = layer, Name = name, Path = path, RowCount = rowCount, FileBytes = PipelineIo.TryGetFileBytes(path) });
            Console.WriteLine($"  NORMALIZED: {rowCount} rows -> {path}");
        }

        Add("Plants", "normalized", plantsRun, plants.Count);
        Add("Customers", "normalized", customersRun, customers.Count);
        Add("Items", "normalized", itemsRun, items.Count);
        Add("Uoms", "normalized", uomsRun, uoms.Count);
        Add("InvoiceTransactions", "normalized", itrnRun, itrn.Count);
        Add("Invoices", "normalized", invoicesRun, invoices.Count);
        Add("Tickets", "normalized", tickRun, tick.Count);
        Add("TicketLines", "normalized", tktlRun, tktl.Count);
        Add("Orders", "normalized", ordrRun, ordr.Count);
    }

    public sealed record DispatchVsArtbReconRow
    {
        public string InvoiceCode { get; init; } = string.Empty;
        public decimal DispatchRevenue { get; init; }
        public decimal ArtbSales { get; init; }
        public decimal ArtbTax { get; init; }
        public decimal ArtbTotal { get; init; }
        public decimal Difference { get; init; }
    }

    private static async Task WriteAnalyticsAsync(
        RunContext ctx,
        RunManifest manifest,
        List<DispatchPlantDay> dispatchPlantDay,
        List<DispatchPlantMonth> dispatchPlantMonth,
        List<TruckUtilizationTruckDay> truckDay,
        List<TruckUtilizationTruckMonth> truckMonth,
        List<PlantShippingDaysMonth> plantShippingDaysMonth,
        List<DispatchVsArInvoiceRecon> dispatchVsArRecon,
        List<DispatchVsArtbReconRow> dispatchVsArtbRecon,
        List<Tbh.Analytics.Builders.DispatchUomSummary> dispatchUomSummary)
    {
        var plantDayRun = Path.Combine(ctx.RunAnalyticsDir, $"{ctx.Prefix} DispatchPlantDay.csv");
        var plantMonthRun = Path.Combine(ctx.RunAnalyticsDir, $"{ctx.Prefix} DispatchPlantMonth.csv");
        var truckDayRun = Path.Combine(ctx.RunAnalyticsDir, $"{ctx.Prefix} TruckUtilization_TruckDay.csv");
        var truckMonthRun = Path.Combine(ctx.RunAnalyticsDir, $"{ctx.Prefix} TruckUtilization_TruckMonth.csv");
        var plantShippingDaysMonthRun = Path.Combine(ctx.RunAnalyticsDir, $"{ctx.Prefix} PlantShippingDays_Month.csv");
        var reconRun = Path.Combine(ctx.RunAnalyticsDir, $"{ctx.Prefix} DispatchVsAR_ByInvoice.csv");
        var reconArtbRun = Path.Combine(ctx.RunAnalyticsDir, $"{ctx.Prefix} DispatchVsAR_ByInvoice_ARTB.csv");
        var uomSummaryRun = Path.Combine(ctx.RunAnalyticsDir, $"{ctx.Prefix} DispatchUomSummary.csv");

        await NormalizedCsvWriter.WriteAsync(dispatchPlantDay, plantDayRun,
        [
            ("day", r => r.Day.ToString("yyyy-MM-dd")),
            ("plant_code", r => r.PlantCode),
            ("concrete_cy", r => r.Quantity.ToString()),
            ("dispatch_revenue", r => r.Revenue.ToString()),
            ("loads", r => r.TicketCount.ToString()),
            ("unique_truck_count", r => r.UniqueTruckCount.ToString()),
            ("avg_revenue_per_load", r => r.AvgRevenuePerLoad.ToString()),
            ("avg_cy_per_load", r => r.AvgCyPerLoad.ToString()),
        ]);

        await NormalizedCsvWriter.WriteAsync(dispatchPlantMonth, plantMonthRun,
        [
            ("month", r => r.Month.ToString("yyyy-MM-01")),
            ("plant_code", r => r.PlantCode),
            ("concrete_cy", r => r.ConcreteCy.ToString()),
            ("dispatch_revenue", r => r.DispatchRevenue.ToString()),
            ("loads", r => r.Loads.ToString()),
            ("unique_truck_count", r => r.UniqueTruckCount.ToString()),
            ("avg_revenue_per_load", r => r.AvgRevenuePerLoad.ToString()),
            ("avg_cy_per_load", r => r.AvgCyPerLoad.ToString()),
        ]);

        await NormalizedCsvWriter.WriteAsync(truckDay, truckDayRun,
        [
            ("day", r => r.Day.ToString("yyyy-MM-dd")),
            ("plant_code", r => r.PlantCode),
            ("truck_code", r => r.TruckCode),
            ("truck_day", r => r.TruckDay.ToString()),
            ("loads", r => r.Loads.ToString()),
            ("concrete_cy", r => r.ConcreteCy.ToString()),
            ("dispatch_revenue", r => r.DispatchRevenue.ToString()),
        ]);

        await NormalizedCsvWriter.WriteAsync(truckMonth, truckMonthRun,
        [
            ("month", r => r.Month.ToString("yyyy-MM-01")),
            ("plant_code", r => r.PlantCode),
            ("truck_code", r => r.TruckCode),
            ("truck_days", r => r.TruckDays.ToString()),
            ("loads", r => r.Loads.ToString()),
            ("concrete_cy", r => r.ConcreteCy.ToString()),
            ("dispatch_revenue", r => r.DispatchRevenue.ToString()),
            ("loads_per_truck_day", r => r.LoadsPerTruckDay.ToString()),
            ("cy_per_truck_day", r => r.CyPerTruckDay.ToString()),
        ]);

        await NormalizedCsvWriter.WriteAsync(plantShippingDaysMonth, plantShippingDaysMonthRun,
        [
            ("month", r => r.Month.ToString("yyyy-MM-01")),
            ("plant_code", r => r.PlantCode),
            ("shipping_days", r => r.ShippingDays.ToString()),
            ("truck_days", r => r.TruckDays.ToString()),
            ("loads", r => r.Loads.ToString()),
            ("concrete_cy", r => r.ConcreteCy.ToString()),
            ("dispatch_revenue", r => r.DispatchRevenue.ToString()),
        ]);

        await NormalizedCsvWriter.WriteAsync(dispatchVsArRecon, reconRun,
        [
            ("invc_code", r => r.InvoiceCode),
            ("dispatch_revenue", r => r.DispatchRevenue.ToString()),
            ("ar_total", r => r.ArTotalAmount.ToString()),
            ("difference", r => r.Difference.ToString()),
        ]);

        await NormalizedCsvWriter.WriteAsync(dispatchVsArtbRecon, reconArtbRun,
        [
            ("invc_code", r => r.InvoiceCode),
            ("dispatch_revenue", r => r.DispatchRevenue.ToString()),
            ("artb_sales_amt", r => r.ArtbSales.ToString()),
            ("artb_tax_amt", r => r.ArtbTax.ToString()),
            ("artb_total", r => r.ArtbTotal.ToString()),
            ("difference", r => r.Difference.ToString()),
        ]);

        await NormalizedCsvWriter.WriteAsync(dispatchUomSummary, uomSummaryRun,
        [
            ("day", r => r.Day.ToString("yyyy-MM-dd")),
            ("plant_code", r => r.PlantCode),
            ("delv_qty_uom", r => r.DeliveredQtyUom),
            ("delv_qty", r => r.DeliveredQty.ToString()),
            ("revenue", r => r.Revenue.ToString()),
            ("ticket_line_count", r => r.TicketLineCount.ToString()),
        ]);

        // Copy to latest
        PipelineIo.CopyToLatest(plantDayRun, Path.Combine(ctx.LatestAnalyticsDir, Path.GetFileName(plantDayRun)));
        PipelineIo.CopyToLatest(plantMonthRun, Path.Combine(ctx.LatestAnalyticsDir, Path.GetFileName(plantMonthRun)));
        PipelineIo.CopyToLatest(truckDayRun, Path.Combine(ctx.LatestAnalyticsDir, Path.GetFileName(truckDayRun)));
        PipelineIo.CopyToLatest(truckMonthRun, Path.Combine(ctx.LatestAnalyticsDir, Path.GetFileName(truckMonthRun)));
        PipelineIo.CopyToLatest(plantShippingDaysMonthRun, Path.Combine(ctx.LatestAnalyticsDir, Path.GetFileName(plantShippingDaysMonthRun)));
        PipelineIo.CopyToLatest(reconRun, Path.Combine(ctx.LatestAnalyticsDir, Path.GetFileName(reconRun)));
        PipelineIo.CopyToLatest(reconArtbRun, Path.Combine(ctx.LatestAnalyticsDir, Path.GetFileName(reconArtbRun)));
        PipelineIo.CopyToLatest(uomSummaryRun, Path.Combine(ctx.LatestAnalyticsDir, Path.GetFileName(uomSummaryRun)));

        void Add(string name, string path, int rowCount)
        {
            manifest.Artifacts.Add(new DatasetArtifact { Layer = "analytics", Name = name, Path = path, RowCount = rowCount, FileBytes = PipelineIo.TryGetFileBytes(path) });
            Console.WriteLine($"  ANALYTICS: {rowCount} rows -> {path}");
        }

        Add("DispatchPlantDay", plantDayRun, dispatchPlantDay.Count);
        Add("DispatchPlantMonth", plantMonthRun, dispatchPlantMonth.Count);
        Add("TruckUtilization_TruckDay", truckDayRun, truckDay.Count);
        Add("TruckUtilization_TruckMonth", truckMonthRun, truckMonth.Count);
        Add("PlantShippingDays_Month", plantShippingDaysMonthRun, plantShippingDaysMonth.Count);
        Add("DispatchVsAR_ByInvoice", reconRun, dispatchVsArRecon.Count);
        Add("DispatchVsAR_ByInvoice_ARTB", reconArtbRun, dispatchVsArtbRecon.Count);
        Add("DispatchUomSummary", uomSummaryRun, dispatchUomSummary.Count);
    }
}
