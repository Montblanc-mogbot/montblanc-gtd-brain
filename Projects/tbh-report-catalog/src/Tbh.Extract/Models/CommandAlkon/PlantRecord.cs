namespace Tbh.Extract.Models.CommandAlkon;

/// <summary>
/// Plant master from Command Alkon plnt table.
/// </summary>
public record PlantRecord
{
    public string? PlantCode { get; init; }
    public string? Name { get; init; }
    public string? ShortName { get; init; }
    public string? CompanyCode { get; init; }
    public string? LocationCode { get; init; }
    public string? Location { get; init; }
}
