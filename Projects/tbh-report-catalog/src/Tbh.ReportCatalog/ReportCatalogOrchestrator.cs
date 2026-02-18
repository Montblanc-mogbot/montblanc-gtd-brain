using Tbh.Analytics.Builders;
using Tbh.Analytics.Models;
using Tbh.Extract.Interfaces;
using Tbh.Extract.Models.CommandAlkon;
using Tbh.Reports.Interfaces;

namespace Tbh.ReportCatalog;

/// <summary>
/// Main orchestrator for the TBH Report Catalog.
/// 
/// Architecture:
/// 1. Extract (Layer 1): Pull data from source systems (Command, GL)
/// 2. Normalize (Layer 2): Clean, align, apply stable business rules
/// 3. Analytics (Layer 3): Build analytical datasets
/// 4. Reports (Layer 4): Generate Excel outputs
/// </summary>
public class ReportCatalogOrchestrator
{
    private readonly ICommandAlkonExtractor _commandExtractor;
    private readonly IExcelReportGenerator<PlantPerformanceRecord> _excelGenerator;

    public ReportCatalogOrchestrator(
        ICommandAlkonExtractor commandExtractor,
        IExcelReportGenerator<PlantPerformanceRecord> excelGenerator)
    {
        _commandExtractor = commandExtractor;
        _excelGenerator = excelGenerator;
    }

    /// <summary>
    /// Generates a Plant Performance report for the specified period.
    /// </summary>
    public async Task GeneratePlantPerformanceReportAsync(
        DateTime startDate,
        DateTime endDate,
        string outputPath,
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"Generating Plant Performance Report for {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}");

        // Step 1: Extract (Layer 1)
        Console.WriteLine("Extracting data from Command Alkon...");
        var plants = await _commandExtractor.ExtractPlantsAsync(cancellationToken);
        var salesDetail = await _commandExtractor.ExtractSalesDetailAsync(startDate, endDate, cancellationToken);

        Console.WriteLine($"  - Loaded {plants.Count()} plants");
        Console.WriteLine($"  - Loaded {salesDetail.Count()} sales detail records");

        // Step 2: Analytics (Layer 3) - simplified direct build
        Console.WriteLine("Building Plant Performance dataset...");
        var builder = new PlantPerformanceBuilder();
        var plantPerformance = builder.Build(salesDetail).ToList();

        Console.WriteLine($"  - Generated {plantPerformance.Count} plant/period records");

        // Step 3: Reports (Layer 4)
        Console.WriteLine($"Generating Excel report: {outputPath}");
        await _excelGenerator.GenerateAsync(plantPerformance, outputPath);

        Console.WriteLine("Report generation complete.");
    }

    /// <summary>
    /// Exports raw data to CSV for audit trail.
    /// </summary>
    public async Task ExportRawDataAsync(
        DateTime startDate,
        DateTime endDate,
        string outputDirectory,
        CancellationToken cancellationToken = default)
    {
        var csvPath = Path.Combine(outputDirectory, $"slsd_{startDate:yyyyMM}_{endDate:yyyyMM}_raw.csv");
        Console.WriteLine($"Exporting raw data to: {csvPath}");
        await _commandExtractor.ExportSalesDetailToCsvAsync(startDate, endDate, csvPath, cancellationToken);
    }
}
