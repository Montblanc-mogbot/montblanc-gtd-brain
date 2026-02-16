using Tbh.Extract.Implementations;
using Tbh.Extract.Interfaces;
using Tbh.Analytics.Builders;
using Tbh.Analytics.Models;
using Tbh.Reports.Generators;

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
        
        Console.WriteLine($"Extracting sales detail: {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}");
        
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
