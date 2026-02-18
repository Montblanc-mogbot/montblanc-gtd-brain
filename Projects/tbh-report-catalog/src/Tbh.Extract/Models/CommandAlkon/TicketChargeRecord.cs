namespace Tbh.Extract.Models.CommandAlkon;

/// <summary>
/// Raw ticket charge/surcharge record (TKTC export).
/// In Command Alkon this represents non-product charges (fuel, washout, etc.) applied to a ticket.
/// </summary>
public record TicketChargeRecord
{
    public DateTime? OrderDate { get; init; }
    public string? OrderCode { get; init; }
    public string? TicketCode { get; init; }

    public string? TicketChargeCode { get; init; }

    public decimal? DeliveredQty { get; init; }
    public string? DeliveredQtyUom { get; init; }

    public decimal? ExtendedPriceAmount { get; init; }

    public DateTime? UpdateDate { get; init; }
}
