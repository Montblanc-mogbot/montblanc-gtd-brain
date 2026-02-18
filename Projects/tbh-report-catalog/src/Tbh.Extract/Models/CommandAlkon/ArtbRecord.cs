namespace Tbh.Extract.Models.CommandAlkon;

/// <summary>
/// Raw AR trial balance / open items record (ARTB export).
/// Stored as TEXT in the dummy DB; we parse only the fields needed for reconciliation.
/// </summary>
public record ArtbRecord
{
    public string? CustomerCode { get; init; }
    public string? InvoiceCode { get; init; } // item_ref_code
    public DateTime? TransactionDate { get; init; } // trans_date

    public string? PrimaryTransactionType { get; init; } // prim_trans_type

    public DateTime? DueDate { get; init; } // due_date
    public DateTime? LatestPaymentDate { get; init; } // latest_pmt_date

    public decimal? CurrentBalanceAmount { get; init; } // curr_bal_amt

    public decimal? SalesAmount { get; init; } // sales_amt
    public decimal? TaxAmount { get; init; } // tax_amt
}
