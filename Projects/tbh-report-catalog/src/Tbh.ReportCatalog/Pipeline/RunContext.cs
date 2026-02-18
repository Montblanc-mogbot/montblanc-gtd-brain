using System.Text.Json;

namespace Tbh.ReportCatalog.Pipeline;

public sealed record RunContext
{
    public required DateTime StartDate { get; init; }
    public required DateTime EndDate { get; init; }

    public required string ProjectRoot { get; init; }
    public required string DbPath { get; init; }

    /// <summary>
    /// Naming convention for this window. Whole months use yyyyMM; otherwise yyyyMMdd.
    /// </summary>
    public required string Prefix { get; init; }

    /// <summary>
    /// Immutable output directory for this run.
    /// </summary>
    public required string RunDir { get; init; }

    public string RunNormalizedDir => Path.Combine(RunDir, "normalized");
    public string RunAnalyticsDir => Path.Combine(RunDir, "analytics");
    public string RunReportsDir => Path.Combine(RunDir, "reports");

    /// <summary>
    /// "Latest" output directories (mutable, overwritten each run).
    /// </summary>
    public string LatestNormalizedDir => Path.Combine(ProjectRoot, "normalized");
    public string LatestAnalyticsDir => Path.Combine(ProjectRoot, "analytics");
    public string LatestReportsDir => Path.Combine(ProjectRoot, "reports");

    public string ManifestPath => Path.Combine(RunDir, "manifest.json");

    public string ToJson() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
}
