namespace Tbh.Extract.Models.CommandAlkon;

/// <summary>
/// Raw ITRN transaction export record (Billing/AR-oriented).
///
/// NOTE: This model is intentionally narrow: we only capture fields we currently
/// need for reconciliation and CFO-level dispatch vs billing reporting.
/// Add fields as downstream reports require them.
/// </summary>
public class ItrnRecord
{
    public DateTime? BatchDate { get; set; }
    public string? BatchNum { get; set; }
    public string? BatchSeq { get; set; }

    public string? UniqueNum { get; set; }

    public string? CustomerCode { get; set; }
    public string? ShipCustomerCode { get; set; }

    public string? TransactionType { get; set; }
    public DateTime? TransactionDate { get; set; }

    public string? PlantCode { get; set; }
    public string? CompanyCode { get; set; }

    public string? InvoiceCode { get; set; }
    public string? ArAdjustmentCode { get; set; }

    public decimal? PretaxAmount { get; set; }
    public decimal? TaxAmount { get; set; }
    public decimal? PaymentAmount { get; set; }
    public decimal? CheckAmount { get; set; }
    public decimal? CostAmount { get; set; }

    public string? Po { get; set; }
    public string? ProjectCode { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
