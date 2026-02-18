using System.Text.Json;

namespace Tbh.ReportCatalog.Pipeline;

public sealed record RunManifest
{
    public required DateTime RunStartedAt { get; init; }
    public required DateTime StartDate { get; init; }
    public required DateTime EndDate { get; init; }
    public required string Prefix { get; init; }
    public required string DbPath { get; init; }

    public required List<DatasetArtifact> Artifacts { get; init; }

    public string ToJson() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
}

public sealed record DatasetArtifact
{
    public required string Layer { get; init; }
    public required string Name { get; init; }
    public required string Path { get; init; }
    public required int RowCount { get; init; }
    public long? FileBytes { get; init; }
}
