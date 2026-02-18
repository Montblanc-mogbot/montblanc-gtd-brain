using Tbh.Normalize;

namespace Tbh.Analytics.Builders;

public static class DispatchAnalyticsBuilders
{
    /// <summary>
    /// Business question: "How much did we deliver (volume + $) by plant each day?"
    /// Source of truth: TKTL.ext_price_amt and TKTL.delv_qty.
    /// </summary>
    public static IEnumerable<DispatchPlantDay> BuildDispatchPlantDay(
        IEnumerable<NormalizedTicket> tickets,
        IEnumerable<NormalizedTicketLine> lines,
        ISet<string> concreteUoms)
    {
        // Join lines -> ticket header to apply removal filter and prefer header plant/date.
        var ticketIndex = tickets
            .Where(t => t.OrderDate != null)
            .ToDictionary(
                t => (Day: t.OrderDate!.Value.Date, t.OrderCode, t.TicketCode),
                t => t);

        var enriched = lines
            .Where(l => l.OrderDate != null)
            .Select(l =>
            {
                var day = l.OrderDate!.Value.Date;
                ticketIndex.TryGetValue((day, l.OrderCode, l.TicketCode), out var t);

                var remove = t?.RemoveReasonCode ?? string.Empty;
                var isRemoved = !string.IsNullOrWhiteSpace(remove);

                var plant = t?.ShipPlantCode ?? l.ShipPlantCode;
                var ticketDay = (t?.TicketDate ?? t?.OrderDate ?? l.OrderDate)!.Value.Date;

                return new
                {
                    TicketDay = ticketDay,
                    Plant = plant,
                    TicketCode = l.TicketCode,
                    TruckCode = t?.TruckCode ?? string.Empty,
                    DeliveredQtyUom = l.DeliveredQtyUom,
                    DeliveredQty = l.DeliveredQty ?? 0m,
                    Revenue = l.ExtendedPriceAmount ?? 0m,
                    isRemoved
                };
            })
            .Where(x => !x.isRemoved);

        return enriched
            .GroupBy(x => new { x.TicketDay, x.Plant })
            .Select(g => new DispatchPlantDay
            {
                Day = g.Key.TicketDay,
                PlantCode = g.Key.Plant,
                Quantity = g.Where(x => concreteUoms.Contains(x.DeliveredQtyUom)).Sum(x => x.DeliveredQty),
                Revenue = g.Sum(x => x.Revenue),
                TicketCount = g.Select(x => x.TicketCode).Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().Count(),
                UniqueTruckCount = g.Select(x => x.TruckCode).Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().Count(),
            })
            .OrderBy(r => r.Day)
            .ThenBy(r => r.PlantCode);
    }

    /// <summary>
    /// Sanity dataset: Loads + volume by day by plant, with splits by product line + UOM.
    /// 
    /// - Excludes removed tickets (TICK.remove_rsn_code).
    /// - Loads = distinct (order_date, order_code, tkt_code) in the group.
    /// - Concrete volume = sum(delv_qty) only where delv_qty_uom is in concreteUoms.
    /// </summary>
    public static IEnumerable<DispatchLoadsVolumeByDayPlant> BuildDispatchLoadsVolumeByDayPlant(
        IEnumerable<NormalizedTicket> tickets,
        IEnumerable<NormalizedTicketLine> lines,
        IEnumerable<NormalizedOrderHeader> orders,
        ISet<string> concreteUoms)
    {
        var ticketIndex = tickets
            .Where(t => t.OrderDate != null)
            .ToDictionary(
                t => (Day: t.OrderDate!.Value.Date, t.OrderCode, t.TicketCode),
                t => t);

        var orderIndex = orders
            .Where(o => o.OrderDate != null)
            .ToDictionary(
                o => (Day: o.OrderDate!.Value.Date, o.OrderCode),
                o => o);

        var enriched = lines
            .Where(l => l.OrderDate != null)
            .Select(l =>
            {
                var day = l.OrderDate!.Value.Date;

                ticketIndex.TryGetValue((day, l.OrderCode, l.TicketCode), out var t);
                orderIndex.TryGetValue((day, l.OrderCode), out var o);

                var remove = t?.RemoveReasonCode ?? string.Empty;
                var isRemoved = !string.IsNullOrWhiteSpace(remove);

                // Use header plant/date when present; otherwise fallback to line.
                var plant = t?.ShipPlantCode ?? l.ShipPlantCode;
                var ticketDay = (t?.TicketDate ?? t?.OrderDate ?? l.OrderDate)!.Value.Date;

                return new
                {
                    TicketDay = ticketDay,
                    Plant = plant,
                    ProdLine = o?.ProductLineCode ?? string.Empty,
                    Uom = l.DeliveredQtyUom,
                    DeliveredQty = l.DeliveredQty ?? 0m,
                    Revenue = l.ExtendedPriceAmount ?? 0m,
                    isRemoved,
                    LoadKey = (day, l.OrderCode, l.TicketCode)
                };
            })
            .Where(x => !x.isRemoved);

        return enriched
            .GroupBy(x => new { x.TicketDay, x.Plant, x.ProdLine, x.Uom })
            .Select(g => new DispatchLoadsVolumeByDayPlant
            {
                Day = g.Key.TicketDay,
                PlantCode = g.Key.Plant,
                ProductLineCode = g.Key.ProdLine,
                DeliveredQtyUom = g.Key.Uom,
                Loads = g.Select(x => x.LoadKey).Distinct().Count(),
                ConcreteDeliveredQty = concreteUoms.Contains(g.Key.Uom) ? g.Sum(x => x.DeliveredQty) : 0m,
                Revenue = g.Sum(x => x.Revenue),
                TicketLineCount = g.Count(),
            })
            .OrderBy(r => r.Day)
            .ThenBy(r => r.PlantCode)
            .ThenBy(r => r.ProductLineCode)
            .ThenBy(r => r.DeliveredQtyUom);
    }

    /// <summary>
    /// Business question: "How much did we deliver by plant for the month?"
    /// </summary>
    public static IEnumerable<DispatchPlantMonth> BuildDispatchPlantMonth(
        IEnumerable<NormalizedTicket> tickets,
        IEnumerable<NormalizedTicketLine> lines,
        ISet<string> concreteUoms)
    {
        // Join lines -> ticket header to apply removal filter and prefer header plant/date.
        var ticketIndex = tickets
            .Where(t => t.OrderDate != null)
            .ToDictionary(
                t => (Day: t.OrderDate!.Value.Date, t.OrderCode, t.TicketCode),
                t => t);

        var enriched = lines
            .Where(l => l.OrderDate != null)
            .Select(l =>
            {
                var day = l.OrderDate!.Value.Date;
                ticketIndex.TryGetValue((day, l.OrderCode, l.TicketCode), out var t);

                var remove = t?.RemoveReasonCode ?? string.Empty;
                var isRemoved = !string.IsNullOrWhiteSpace(remove);

                var plant = t?.ShipPlantCode ?? l.ShipPlantCode;
                var ticketDay = (t?.TicketDate ?? t?.OrderDate ?? l.OrderDate)!.Value.Date;

                return new
                {
                    TicketDay = ticketDay,
                    Plant = plant,
                    DeliveredQtyUom = l.DeliveredQtyUom,
                    DeliveredQty = l.DeliveredQty ?? 0m,
                    Revenue = l.ExtendedPriceAmount ?? 0m,
                    isRemoved
                };
            })
            .Where(x => !x.isRemoved);

        return enriched
            .GroupBy(x => new { x.TicketDay.Year, x.TicketDay.Month, x.Plant })
            .Select(g => new DispatchPlantMonth
            {
                AccountingYear = g.Key.Year,
                AccountingPeriod = g.Key.Month,
                PlantCode = g.Key.Plant,
                DeliveredQty = g.Sum(x => x.DeliveredQty),
                ConcreteDeliveredQty = g.Where(x => concreteUoms.Contains(x.DeliveredQtyUom)).Sum(x => x.DeliveredQty),
                Revenue = g.Sum(x => x.Revenue),
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

    public decimal Revenue { get; init; }

    public int TicketCount { get; init; }
    public int UniqueTruckCount { get; init; }
}

public record DispatchLoadsVolumeByDayPlant
{
    public DateTime Day { get; init; }
    public string PlantCode { get; init; } = string.Empty;
    public string ProductLineCode { get; init; } = string.Empty;
    public string DeliveredQtyUom { get; init; } = string.Empty;

    public int Loads { get; init; }
    public decimal ConcreteDeliveredQty { get; init; }
    public decimal Revenue { get; init; }
    public int TicketLineCount { get; init; }
}

public record DispatchPlantMonth
{
    public int AccountingYear { get; init; }
    public int AccountingPeriod { get; init; }
    public string PlantCode { get; init; } = string.Empty;
    public decimal DeliveredQty { get; init; }
    public decimal ConcreteDeliveredQty { get; init; }
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
