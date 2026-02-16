namespace Tbh.Extract.Models.CommandAlkon;

/// <summary>
/// Raw order header from Command Alkon ORDR table.
/// Layer 1 (Extract): no business logic.
/// </summary>
public record OrderHeaderRecord
{
    public DateTime? OrderDate { get; init; }
    public string? OrderCode { get; init; }

    public string? CustomerCode { get; init; }
    public string? CustomerName { get; init; }

    public string? ShipToPlantCode { get; init; }

    public string? ZoneCode { get; init; }
    public string? ProjectCode { get; init; }

    public DateTime? UpdateDate { get; init; }
}
