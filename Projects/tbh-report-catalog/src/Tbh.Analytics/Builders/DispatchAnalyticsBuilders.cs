using Tbh.Normalize;

namespace Tbh.Analytics.Builders;

public static class DispatchAnalyticsBuilders
{
    /// <summary>
    /// Business question: "How much did we deliver (volume + $) by plant each day?"
    /// Source of truth: TKTL.ext_price_amt and TKTL.delv_qty.
    /// </summary>
    public static IEnumerable<DispatchPlantDay> BuildDispatchPlantDay(IEnumerable<NormalizedTicketLine> lines)
    {
        return lines
            .Where(l => l.OrderDate != null)
            .GroupBy(l => new { Day = l.OrderDate!.Value.Date, Plant = l.ShipPlantCode })
            .Select(g => new DispatchPlantDay
            {
                Day = g.Key.Day,
                PlantCode = g.Key.Plant,
                DeliveredQty = g.Sum(x => x.DeliveredQty ?? 0m),
                Revenue = g.Sum(x => x.ExtendedPriceAmount ?? 0m),
                TicketLineCount = g.Count(),
            })
            .OrderBy(r => r.Day)
            .ThenBy(r => r.PlantCode);
    }

    /// <summary>
    /// Business question: "How much did we deliver by plant for the month?"
    /// </summary>
    public static IEnumerable<DispatchPlantMonth> BuildDispatchPlantMonth(IEnumerable<NormalizedTicketLine> lines)
    {
        return lines
            .Where(l => l.OrderDate != null)
            .GroupBy(l => new { Year = l.OrderDate!.Value.Year, Month = l.OrderDate!.Value.Month, Plant = l.ShipPlantCode })
            .Select(g => new DispatchPlantMonth
            {
                AccountingYear = g.Key.Year,
                AccountingPeriod = g.Key.Month,
                PlantCode = g.Key.Plant,
                DeliveredQty = g.Sum(x => x.DeliveredQty ?? 0m),
                Revenue = g.Sum(x => x.ExtendedPriceAmount ?? 0m),
                TicketLineCount = g.Count(),
            })
            .OrderBy(r => r.AccountingYear)
            .ThenBy(r => r.AccountingPeriod)
            .ThenBy(r => r.PlantCode);
    }

    /// <summary>
    /// Business question: "For each invoice, what does dispatch say we delivered (by invoice_code)?"
    /// Join path: TKTL (ticket lines) -> TICK (ticket header) -> invc_code.
    /// </summary>
    public static IEnumerable<DispatchInvoiceTotal> BuildDispatchInvoiceTotals(
        IEnumerable<NormalizedTicket> tickets,
        IEnumerable<NormalizedTicketLine> lines)
    {
        // Ticket codes are not guaranteed unique across the raw export (sample data shows duplicates).
        // For reconciliation, we need a stable mapping TicketCode -> InvoiceCode.
        // Strategy: group by TicketCode and pick the first non-empty invoice code (or empty).
        var ticketToInvoice = tickets
            .Where(t => !string.IsNullOrWhiteSpace(t.TicketCode))
            .GroupBy(t => t.TicketCode)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.InvcCode).FirstOrDefault(x => !string.IsNullOrWhiteSpace(x)) ?? string.Empty);

        return lines
            .Select(l => new
            {
                InvoiceCode = ticketToInvoice.TryGetValue(l.TicketCode, out var inv) ? inv : string.Empty,
                Revenue = l.ExtendedPriceAmount ?? 0m,
            })
            .Where(x => !string.IsNullOrWhiteSpace(x.InvoiceCode))
            .GroupBy(x => x.InvoiceCode)
            .Select(g => new DispatchInvoiceTotal
            {
                InvoiceCode = g.Key,
                DispatchRevenue = g.Sum(x => x.Revenue),
            })
            .OrderBy(r => r.InvoiceCode);
    }

    /// <summary>
    /// Business question: "Do dispatch-delivered totals match AR (ITRN) totals per invoice?"
    /// AR truth: ITRN trans_type 11/21 for invoiced amounts.
    /// </summary>
    public static IEnumerable<DispatchVsArInvoiceRecon> BuildDispatchVsArInvoiceRecon(
        IEnumerable<DispatchInvoiceTotal> dispatchByInvoice,
        IEnumerable<NormalizedItrn> itrn)
    {
        var arByInvoice = itrn
            .Where(r => r.TransactionType is "11" or "21")
            .Where(r => !string.IsNullOrWhiteSpace(r.InvoiceCode))
            .GroupBy(r => r.InvoiceCode!)
            .Select(g => new
            {
                InvoiceCode = g.Key,
                Pretax = g.Sum(x => x.PretaxAmount),
                Tax = g.Sum(x => x.TaxAmount),
                Total = g.Sum(x => x.TotalAmount),
            })
            .ToDictionary(x => x.InvoiceCode);

        foreach (var d in dispatchByInvoice)
        {
            arByInvoice.TryGetValue(d.InvoiceCode, out var ar);
            var arTotal = ar?.Total ?? 0m;

            yield return new DispatchVsArInvoiceRecon
            {
                InvoiceCode = d.InvoiceCode,
                DispatchRevenue = d.DispatchRevenue,
                ArTotalAmount = arTotal,
                Difference = d.DispatchRevenue - arTotal,
            };
        }
    }
}

public record DispatchPlantDay
{
    public DateTime Day { get; init; }
    public string PlantCode { get; init; } = string.Empty;
    public decimal DeliveredQty { get; init; }
    public decimal Revenue { get; init; }
    public int TicketLineCount { get; init; }
}

public record DispatchPlantMonth
{
    public int AccountingYear { get; init; }
    public int AccountingPeriod { get; init; }
    public string PlantCode { get; init; } = string.Empty;
    public decimal DeliveredQty { get; init; }
    public decimal Revenue { get; init; }
    public int TicketLineCount { get; init; }
}

public record DispatchInvoiceTotal
{
    public string InvoiceCode { get; init; } = string.Empty;
    public decimal DispatchRevenue { get; init; }
}

public record DispatchVsArInvoiceRecon
{
    public string InvoiceCode { get; init; } = string.Empty;
    public decimal DispatchRevenue { get; init; }
    public decimal ArTotalAmount { get; init; }
    public decimal Difference { get; init; }
}
