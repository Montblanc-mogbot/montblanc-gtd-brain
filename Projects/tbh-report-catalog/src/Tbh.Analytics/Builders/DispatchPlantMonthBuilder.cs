using Tbh.Normalize;

namespace Tbh.Analytics.Builders;

public static class DispatchPlantMonthBuilder
{
    public static IEnumerable<DispatchPlantMonth> BuildDispatchPlantMonth(
        IEnumerable<NormalizedTicket> tickets,
        IEnumerable<NormalizedTicketLine> lines,
        ISet<string> concreteUoms)
    {
        // Concrete volume by ticket
        var concreteQtyByTicket = lines
            .Where(l => l.OrderDate != null)
            .Where(l => concreteUoms.Contains(l.DeliveredQtyUom))
            .GroupBy(l => (Day: l.OrderDate!.Value.Date, l.OrderCode, l.TicketCode))
            .ToDictionary(g => g.Key, g => g.Sum(x => x.DeliveredQty ?? 0m));

        var ticketRows = tickets
            .Where(t => t.OrderDate != null)
            .Where(t => !string.IsNullOrWhiteSpace(t.TicketCode))
            .Select(t =>
            {
                var key = (Day: t.OrderDate!.Value.Date, t.OrderCode, t.TicketCode);
                var qty = concreteQtyByTicket.TryGetValue(key, out var q) ? q : 0m;
                var month = new DateTime((t.TicketDate ?? t.OrderDate)!.Value.Year, (t.TicketDate ?? t.OrderDate)!.Value.Month, 1);

                return new
                {
                    Month = month,
                    Plant = t.ShipPlantCode,
                    TicketCode = t.TicketCode,
                    TruckCode = t.TruckCode,
                    ConcreteQty = qty,
                    DispatchRevenue = t.TicketDispatchTotalAmount,
                };
            })
            .ToList();

        return ticketRows
            .GroupBy(x => new { x.Month, x.Plant })
            .Select(g =>
            {
                var loads = g.Select(x => x.TicketCode).Distinct().Count();
                var qty = g.Sum(x => x.ConcreteQty);
                var rev = g.Sum(x => x.DispatchRevenue);

                return new DispatchPlantMonth
                {
                    Month = g.Key.Month,
                    PlantCode = g.Key.Plant,
                    ConcreteCy = qty,
                    DispatchRevenue = rev,
                    Loads = loads,
                    UniqueTruckCount = g.Select(x => x.TruckCode).Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().Count(),
                    AvgRevenuePerLoad = loads > 0 ? rev / loads : 0m,
                    AvgCyPerLoad = loads > 0 ? qty / loads : 0m,
                };
            })
            .OrderBy(r => r.Month)
            .ThenBy(r => r.PlantCode);
    }
}

public sealed record DispatchPlantMonth
{
    public DateTime Month { get; init; }
    public string PlantCode { get; init; } = string.Empty;

    public decimal ConcreteCy { get; init; }
    public int Loads { get; init; }
    public int UniqueTruckCount { get; init; }

    public decimal DispatchRevenue { get; init; }

    public decimal AvgRevenuePerLoad { get; init; }
    public decimal AvgCyPerLoad { get; init; }
}
