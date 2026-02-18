namespace Tbh.Normalize;

/// <summary>
/// Normalized invoice entity (1 row per invoice).
/// Built primarily from ITRN (for payments/batch linkage) and ARTB (for invoice-level totals and due dates).
/// </summary>
public sealed record NormalizedInvoice
{
    public string InvoiceCode { get; init; } = string.Empty;

    public string? CustomerCode { get; init; }
    public string? PlantCode { get; init; }

    public DateTime? InvoiceDate { get; init; }
    public DateTime? DueDate { get; init; }
    public DateTime? LatestPaymentDate { get; init; }

    public decimal SalesAmount { get; init; }
    public decimal TaxAmount { get; init; }
    public decimal TotalAmount => SalesAmount + TaxAmount;

    public decimal PaymentsAmount { get; init; }
    public decimal OpenBalanceAmount { get; init; }

    public bool IsPaidInFull { get; init; }
}
