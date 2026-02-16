namespace Tbh.Reports.Interfaces;

/// <summary>
/// Interface for Excel report generators.
/// </summary>
public interface IExcelReportGenerator<TData>
{
    Task GenerateAsync(IEnumerable<TData> data, string outputPath);
}
