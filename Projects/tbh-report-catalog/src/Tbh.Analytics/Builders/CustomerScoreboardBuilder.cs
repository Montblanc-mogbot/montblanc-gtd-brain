using Tbh.Normalize;

namespace Tbh.Analytics.Builders;

public static class CustomerScoreboardBuilder
{
    public static IEnumerable<CustomerScoreboardMonth> BuildCustomerScoreboardMonth(
        IEnumerable<InvoiceAgingByInvoice> invoiceAging)
    {
        return invoiceAging
            .GroupBy(x => new { Month = new DateTime(x.InvoiceDate.Year, x.InvoiceDate.Month, 1), x.CustomerCode })
            .Select(g =>
            {
                var open = g.Sum(x => x.OpenBalanceAmount);
                var pastDue = g.Where(x => x.DaysPastDue > 0).Sum(x => x.OpenBalanceAmount);

                // Weighted avg days outstanding (weighted by open balance).
                var denom = g.Sum(x => Math.Abs(x.OpenBalanceAmount));
                var wad = denom > 0m
                    ? (decimal)g.Sum(x => (double)(Math.Abs(x.OpenBalanceAmount) * x.DaysOutstanding)) / denom
                    : 0m;

                return new CustomerScoreboardMonth
                {
                    Month = g.Key.Month,
                    CustomerCode = g.Key.CustomerCode,
                    OpenBalanceAmount = open,
                    PastDueBalanceAmount = pastDue,
                    PercentPastDue = open != 0m ? pastDue / open : 0m,
                    WeightedAvgDaysOutstanding = wad,
                    InvoiceCount = g.Select(x => x.InvoiceCode).Distinct().Count(),
                    OpenInvoiceCount = g.Count(x => !x.PaidInFull && x.OpenBalanceAmount > 0m),
                };
            })
            .OrderBy(r => r.Month)
            .ThenBy(r => r.CustomerCode);
    }
}

public sealed record CustomerScoreboardMonth
{
    public DateTime Month { get; init; }
    public string CustomerCode { get; init; } = string.Empty;

    public int InvoiceCount { get; init; }
    public int OpenInvoiceCount { get; init; }

    public decimal OpenBalanceAmount { get; init; }
    public decimal PastDueBalanceAmount { get; init; }
    public decimal PercentPastDue { get; init; }

    public decimal WeightedAvgDaysOutstanding { get; init; }
}
