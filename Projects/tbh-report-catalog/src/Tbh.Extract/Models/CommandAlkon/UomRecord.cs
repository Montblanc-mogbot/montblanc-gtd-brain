namespace Tbh.Extract.Models.CommandAlkon;

/// <summary>
/// Unit of measure master data (UOMS table).
/// Provides a stable mapping between UOM code and human-readable names/abbreviations.
/// </summary>
public record UomRecord
{
    public string UomCode { get; init; } = string.Empty;
    public string? Name { get; init; }
    public string? Abbreviation { get; init; }
}
