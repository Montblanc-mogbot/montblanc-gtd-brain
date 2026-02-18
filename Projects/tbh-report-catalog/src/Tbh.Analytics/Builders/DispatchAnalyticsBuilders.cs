using Tbh.Normalize;

namespace Tbh.Analytics.Builders;

public static class DispatchAnalyticsBuilders
{
    /// <summary>
    /// Business question: "How much did we deliver (volume + $) by plant each day?"
    /// Source of truth:
    /// - Volume: TKTL.delv_qty filtered to concrete UOMs.
    /// - Dispatch revenue: ticket-grain totals (TKTL + TKTC) stored on NormalizedTicket.
    /// </summary>
    public static IEnumerable<DispatchPlantDay> BuildDispatchPlantDay(
        IEnumerable<NormalizedTicket> tickets,
        IEnumerable<NormalizedTicketLine> lines,
        ISet<string> concreteUoms)
    {
        // Ticket-grain index (removals are already filtered in normalization, but keep this auditable).
        var ticketIndex = tickets
            .Where(t => t.OrderDate != null)
            .Where(t => !string.IsNullOrWhiteSpace(t.TicketCode))
            .ToDictionary(
                t => (Day: t.OrderDate!.Value.Date, t.OrderCode, t.TicketCode),
                t => t);

        // Concrete volume by ticket (sum of TKTL concrete lines).
        var concreteQtyByTicket = lines
            .Where(l => l.OrderDate != null)
            .Where(l => concreteUoms.Contains(l.DeliveredQtyUom))
            .GroupBy(l => (Day: l.OrderDate!.Value.Date, l.OrderCode, l.TicketCode))
            .ToDictionary(g => g.Key, g => g.Sum(x => x.DeliveredQty ?? 0m));

        // Build one enriched row per ticket, then roll up by day/plant.
        var enrichedTickets = ticketIndex
            .Select(kvp =>
            {
                var key = kvp.Key;
                var t = kvp.Value;

                var ticketDay = (t.TicketDate ?? t.OrderDate)!.Value.Date;
                var plant = t.ShipPlantCode;

                var qty = concreteQtyByTicket.TryGetValue(key, out var q) ? q : 0m;

                return new
                {
                    Day = ticketDay,
                    Plant = plant,
                    TicketCode = t.TicketCode,
                    TruckCode = t.TruckCode,
                    ConcreteQty = qty,
                    DispatchRevenue = t.TicketDispatchTotalAmount,
                };
            })
            .ToList();

        return enrichedTickets
            .GroupBy(x => new { x.Day, x.Plant })
            .Select(g =>
            {
                var loads = g.Select(x => x.TicketCode).Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().Count();
                var qty = g.Sum(x => x.ConcreteQty);
                var rev = g.Sum(x => x.DispatchRevenue);

                return new DispatchPlantDay
                {
                    Day = g.Key.Day,
                    PlantCode = g.Key.Plant,
                    Quantity = qty,
                    Revenue = rev,
                    TicketCount = loads,
                    UniqueTruckCount = g.Select(x => x.TruckCode).Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().Count(),
                    AvgRevenuePerLoad = loads > 0 ? rev / loads : 0m,
                    AvgCyPerLoad = loads > 0 ? qty / loads : 0m,
                };
            })
            .OrderBy(r => r.Day)
            .ThenBy(r => r.PlantCode);
    }

    // NOTE: additional dispatch rollups (month, product line splits, etc.) were removed from the pipeline.
    // We’ll reintroduce new analytics only when they answer a specific business question and are backed by
    // the normalized data required for reconciliation (TKTL + TKTC + TLAP + TLAC + TKTX).

    /// <summary>
    /// Business question: "For each invoice, what does dispatch say we delivered (by invoice_code)?"
    /// Join path: TKTL (ticket lines) -> TICK (ticket header) -> invc_code.
    /// </summary>
    public static IEnumerable<DispatchInvoiceTotal> BuildDispatchInvoiceTotals(
        IEnumerable<NormalizedTicket> tickets,
        IEnumerable<NormalizedTicketLine> lines)
    {
        // Ticket codes are not guaranteed unique across the raw export.
        // For reconciliation, use the composite key (order_date, order_code, tkt_code) to map lines -> invoice.
        var ticketIndex = tickets
            .Where(t => t.OrderDate != null)
            .Where(t => !string.IsNullOrWhiteSpace(t.TicketCode))
            .GroupBy(t => (Day: t.OrderDate!.Value.Date, t.OrderCode, t.TicketCode))
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.InvcCode).FirstOrDefault(x => !string.IsNullOrWhiteSpace(x)) ?? string.Empty);

        return lines
            .Where(l => l.OrderDate != null)
            .Select(l => new
            {
                InvoiceCode = ticketIndex.TryGetValue((l.OrderDate!.Value.Date, l.OrderCode, l.TicketCode), out var inv)
                    ? inv
                    : string.Empty,
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

    // Concrete yards only (UOM-filtered).
    public decimal Quantity { get; init; }

    // Dispatch revenue (ticket-grain totals: product + charges).
    public decimal Revenue { get; init; }

    public int TicketCount { get; init; }
    public int UniqueTruckCount { get; init; }

    public decimal AvgRevenuePerLoad { get; init; }
    public decimal AvgCyPerLoad { get; init; }
}

// (Removed) DispatchLoadsVolumeByDayPlant and DispatchPlantMonth records.

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
