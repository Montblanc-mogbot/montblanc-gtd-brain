using Tbh.Normalize;

namespace Tbh.Analytics.Builders;

public static class DispatchUomSummaryBuilder
{
    /// <summary>
    /// Verification dataset: summarize dispatch ticket lines by UOM.
    /// 
    /// - Excludes removed tickets (TICK.remove_rsn_code).
    /// - Helps validate what UOMs are present and whether non-yard lines are leaking into volume.
    /// </summary>
    public static IEnumerable<DispatchUomSummary> BuildDispatchUomSummary(
        IEnumerable<NormalizedTicket> tickets,
        IEnumerable<NormalizedTicketLine> lines)
    {
        // Join lines -> ticket header to apply removal filter and prefer header date/plant when present.
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
                    Uom = l.DeliveredQtyUom,
                    DeliveredQty = l.DeliveredQty ?? 0m,
                    Revenue = l.ExtendedPriceAmount ?? 0m,
                    isRemoved
                };
            })
            .Where(x => !x.isRemoved);

        return enriched
            .GroupBy(x => new { x.TicketDay, x.Plant, x.Uom })
            .Select(g => new DispatchUomSummary
            {
                Day = g.Key.TicketDay,
                PlantCode = g.Key.Plant,
                DeliveredQtyUom = g.Key.Uom,
                DeliveredQty = g.Sum(x => x.DeliveredQty),
                Revenue = g.Sum(x => x.Revenue),
                TicketLineCount = g.Count(),
            })
            .OrderBy(r => r.Day)
            .ThenBy(r => r.PlantCode)
            .ThenBy(r => r.DeliveredQtyUom);
    }
}

public record DispatchUomSummary
{
    public DateTime Day { get; init; }
    public string PlantCode { get; init; } = string.Empty;
    public string DeliveredQtyUom { get; init; } = string.Empty;
    public decimal DeliveredQty { get; init; }
    public decimal Revenue { get; init; }
    public int TicketLineCount { get; init; }
}
