namespace Tbh.Extract.Models.CommandAlkon;

/// <summary>
/// Item master from Command Alkon imst table.
/// </summary>
public record ItemMasterRecord
{
    public string? ItemCode { get; init; }
    public string? Description { get; init; }
    public string? ShortDescription { get; init; }
    public string? ItemCategory { get; init; }
    public string? MaterialType { get; init; }
    public string? OrderUom { get; init; }
    public string? PriceUom { get; init; }
    public bool IsTaxable { get; init; }
    public bool PrintOnTicket { get; init; }
    public bool IsConstructionItem { get; init; }
}
