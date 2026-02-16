using Tbh.Analytics.Models;

namespace Tbh.Reports.Interfaces;

/// <summary>
/// Interface for generating Excel reports.
/// Implementations use EPPlus to create formatted, professional reports.
/// </summary>
public interface IExcelReportGenerator
{
    /// <summary>
    /// Generates a Plant Performance Excel report.
    /// </summary>
    Task GeneratePlantPerformanceReportAsync(
        IEnumerable<PlantPerformanceRecord> records,
        string outputPath,
        CancellationToken cancellationToken = default);
}
