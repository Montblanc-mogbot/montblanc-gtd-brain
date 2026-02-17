namespace Tbh.Extract.Models.CommandAlkon;

/// <summary>
/// Raw ticket header from Command Alkon TICK table.
/// Layer 1 (Extract): no business logic, just columns we need for reporting.
/// </summary>
public record TicketRecord
{
    public DateTime? OrderDate { get; init; }
    public string? OrderCode { get; init; }

    public string? TicketCode { get; init; }
    public DateTime? TicketDate { get; init; }

    public string? ShipPlantCode { get; init; }
    public string? ShipPlantLocCode { get; init; }

    public string? TruckCode { get; init; }

    /// <summary>
    /// When present, the ticket was removed/voided for this reason.
    /// For analytics, tickets with a non-null/non-empty remove_rsn_code should be excluded.
    /// </summary>
    public string? RemoveReasonCode { get; init; }

    public string? InvcFlag { get; init; }
    public string? InvcCode { get; init; }
    public DateTime? InvcDate { get; init; }
    public int? InvcSeqNum { get; init; }

    public string? TicketStatus { get; init; }

    public DateTime? UpdateDate { get; init; }
}
