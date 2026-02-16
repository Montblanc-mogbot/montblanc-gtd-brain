namespace Tbh.Extract.Models.CommandAlkon;

/// <summary>
/// Raw ticket line from Command Alkon TKTL table.
/// Layer 1 (Extract): no business logic.
/// </summary>
public record TicketLineRecord
{
    public DateTime? OrderDate { get; init; }
    public string? OrderCode { get; init; }

    public string? TicketCode { get; init; }
    public int? OrderInternalLineNum { get; init; }

    public decimal? DeliveredQty { get; init; }
    public string? DeliveredQtyUom { get; init; }

    public string? ShipPlantCode { get; init; }

    public decimal? ExtendedPriceAmount { get; init; }

    public DateTime? UpdateDate { get; init; }
}
