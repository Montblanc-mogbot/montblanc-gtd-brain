using Tbh.Normalize;

namespace Tbh.Analytics.Builders;

public static class InvoiceAgingBuilder
{
    public static IEnumerable<InvoiceAgingByInvoice> BuildInvoiceAgingByInvoice(
        IEnumerable<NormalizedInvoice> invoices,
        DateTime asOfDate)
    {
        foreach (var inv in invoices)
        {
            var invDate = inv.InvoiceDate?.Date;
            if (invDate == null)
            {
                continue;
            }

            // TBH convention:
            // - If due_date differs from invoice date, treat as net15
            // - Else treat as net30 (because due_date is set equal to invoice date for most customers)
            var termsClass = (inv.DueDate.HasValue && inv.DueDate.Value.Date != invDate.Value)
                ? "net15"
                : "net30_assumed";

            var assumedDue = termsClass == "net15"
                ? invDate.Value.AddDays(15)
                : invDate.Value.AddDays(30);

            var daysOutstanding = (asOfDate.Date - invDate.Value).Days;
            var daysPastDue = Math.Max(0, (asOfDate.Date - assumedDue).Days);

            var bucket = daysPastDue switch
            {
                <= 0 => "current",
                <= 30 => "1-30",
                <= 60 => "31-60",
                <= 90 => "61-90",
                _ => "90+",
            };

            yield return new InvoiceAgingByInvoice
            {
                AsOfDate = asOfDate.Date,
                InvoiceCode = inv.InvoiceCode,
                CustomerCode = inv.CustomerCode ?? string.Empty,
                PlantCode = inv.PlantCode ?? string.Empty,
                InvoiceDate = invDate.Value,
                OpenBalanceAmount = inv.OpenBalanceAmount,
                TermsClass = termsClass,
                AssumedDueDate = assumedDue,
                DaysOutstanding = daysOutstanding,
                DaysPastDue = daysPastDue,
                AgingBucket = bucket,
                PaidInFull = inv.IsPaidInFull,
            };
        }
    }
}

public sealed record InvoiceAgingByInvoice
{
    public DateTime AsOfDate { get; init; }

    public string InvoiceCode { get; init; } = string.Empty;
    public string CustomerCode { get; init; } = string.Empty;
    public string PlantCode { get; init; } = string.Empty;

    public DateTime InvoiceDate { get; init; }

    public decimal OpenBalanceAmount { get; init; }

    public string TermsClass { get; init; } = string.Empty;
    public DateTime AssumedDueDate { get; init; }

    public int DaysOutstanding { get; init; }
    public int DaysPastDue { get; init; }
    public string AgingBucket { get; init; } = string.Empty;

    public bool PaidInFull { get; init; }
}
