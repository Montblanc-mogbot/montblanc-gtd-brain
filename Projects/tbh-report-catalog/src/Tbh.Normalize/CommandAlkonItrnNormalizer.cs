using Tbh.Extract.Models.CommandAlkon;

namespace Tbh.Normalize;

/// <summary>
/// Normalization for ITRN (Billing/AR transaction export).
///
/// Goal: create a narrow, stable schema suitable for reconciliation and CFO reporting.
/// Keep transformations explainable (trim, plant code normalization, date parsing already done in extract).
/// </summary>
public static class CommandAlkonItrnNormalizer
{
    public static NormalizedItrn Normalize(ItrnRecord record)
    {
        var dt = record.TransactionDate;

        return new NormalizedItrn
        {
            TransactionDate = dt,
            AccountingYear = dt?.Year,
            AccountingPeriod = dt?.Month,

            PlantCode = CommandAlkonNormalizer.NormalizePlantCode(record.PlantCode),
            RawPlantCode = record.PlantCode,

            CustomerCode = record.CustomerCode?.Trim(),
            ShipCustomerCode = record.ShipCustomerCode?.Trim(),

            InvoiceCode = record.InvoiceCode?.Trim(),
            TransactionType = record.TransactionType?.Trim(),
            ArAdjustmentCode = record.ArAdjustmentCode?.Trim(),

            PretaxAmount = record.PretaxAmount ?? 0m,
            TaxAmount = record.TaxAmount ?? 0m,
            PaymentAmount = record.PaymentAmount ?? 0m,
            CheckAmount = record.CheckAmount ?? 0m,
            CostAmount = record.CostAmount,

            ProjectCode = record.ProjectCode?.Trim(),
            Po = record.Po?.Trim(),

            UniqueNum = record.UniqueNum?.Trim(),
            BatchDate = record.BatchDate,
            ModifiedDate = record.ModifiedDate,
        };
    }
}

public record NormalizedItrn
{
    public DateTime? TransactionDate { get; init; }
    public int? AccountingYear { get; init; }
    public int? AccountingPeriod { get; init; }

    public string PlantCode { get; init; } = "UNKNOWN";
    public string? RawPlantCode { get; init; }

    public string? CustomerCode { get; init; }
    public string? ShipCustomerCode { get; init; }

    public string? InvoiceCode { get; init; }
    public string? TransactionType { get; init; }
    public string? ArAdjustmentCode { get; init; }

    public decimal PretaxAmount { get; init; }
    public decimal TaxAmount { get; init; }
    public decimal PaymentAmount { get; init; }
    public decimal CheckAmount { get; init; }
    public decimal? CostAmount { get; init; }

    public string? ProjectCode { get; init; }
    public string? Po { get; init; }

    public string? UniqueNum { get; init; }
    public DateTime? BatchDate { get; init; }
    public DateTime? ModifiedDate { get; init; }

    public decimal TotalAmount => PretaxAmount + TaxAmount;
}
