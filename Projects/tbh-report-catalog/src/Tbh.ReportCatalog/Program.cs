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
        var dbPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, 
            "..", "..", "..", "..", "..", "data", "command_alkon_dummy.db");
        dbPath = Path.GetFullPath(dbPath);
        
        if (!File.Exists(dbPath))
        {
            Console.WriteLine($"Database not found: {dbPath}");
            Console.WriteLine("Run: python scripts/sqlite/build_dummy_db.py");
            return;
        }
        
        Console.WriteLine($"Using database: {dbPath}\n");
        
        // Create extractor
        ICommandAlkonExtractor extractor = new SqliteCommandAlkonExtractor(dbPath);
        
        // Define reporting period (January 2025 to match ORDL sample)
        var startDate = new DateTime(2025, 1, 1);
        var endDate = new DateTime(2025, 2, 1);
        
        Console.WriteLine($"Extracting normalized dispatch datasets: {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}");

        var tickRaw = (await extractor.ExtractTicketsAsync(startDate, endDate)).ToList();
        var tktlRaw = (await extractor.ExtractTicketLinesAsync(startDate, endDate)).ToList();
        var ordrRaw = (await extractor.ExtractOrdersAsync(startDate, endDate)).ToList();

        var tick = tickRaw.Select(CommandAlkonDispatchNormalizer.Normalize).ToList();
        var tktl = tktlRaw.Select(CommandAlkonDispatchNormalizer.Normalize).ToList();
        var ordr = ordrRaw.Select(CommandAlkonDispatchNormalizer.Normalize).ToList();

        // Normalized CSV output convention:
        //   YYYYMM(DD) ReportName
        // Use day only when the date range is not a clean whole-month window.
        var projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", ".."));
        var normalizedDir = Path.Combine(projectRoot, "normalized");
        Directory.CreateDirectory(normalizedDir);

        static bool IsWholeMonthWindow(DateTime start, DateTime end) =>
            start.Day == 1 && end.Day == 1 && end == start.AddMonths(1);

        var prefix = IsWholeMonthWindow(startDate, endDate)
            ? startDate.ToString("yyyyMM")
            : startDate.ToString("yyyyMMdd");

        var tickOut = Path.Combine(normalizedDir, $"{prefix} Tickets.csv");
        var tktlOut = Path.Combine(normalizedDir, $"{prefix} TicketLines.csv");
        var ordrOut = Path.Combine(normalizedDir, $"{prefix} Orders.csv");

        // Keep normalized schemas narrow; add fields only when a downstream report needs them.
        await NormalizedCsvWriter.WriteAsync(tick, tickOut,
        [
            ("order_date", r => r.OrderDate?.ToString("yyyy-MM-dd") ?? ""),
            ("order_code", r => r.OrderCode),
            ("tkt_code", r => r.TicketCode),
            ("tkt_date", r => r.TicketDate?.ToString("yyyy-MM-dd") ?? ""),
            ("ship_plant_code", r => r.ShipPlantCode),
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
            ("cust_code", r => r.CustomerCode),
            ("cust_name", r => r.CustomerName),
            ("proj_code", r => r.ProjectCode),
        ]);

        Console.WriteLine($"  TICK: {tick.Count} rows -> {tickOut}");
        Console.WriteLine($"  TKTL: {tktl.Count} rows -> {tktlOut}");
        Console.WriteLine($"  ORDR: {ordr.Count} rows -> {ordrOut}\n");

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
        
        // Generate Excel report
        var outputPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            $"PlantPerformance_{startDate:yyyyMMdd}_{endDate:yyyyMMdd}.xlsx");
        
        Console.WriteLine($"Generating Excel report: {outputPath}");
        
        var excelGenerator = new PlantPerformanceExcelGenerator();
        await excelGenerator.GenerateAsync(perfList, outputPath);
        
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
}
