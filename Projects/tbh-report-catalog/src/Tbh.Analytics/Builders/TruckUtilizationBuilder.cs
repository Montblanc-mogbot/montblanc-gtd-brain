using Tbh.Normalize;

namespace Tbh.Analytics.Builders;

public static class TruckUtilizationBuilder
{
    public static IEnumerable<TruckUtilizationTruckDay> BuildTruckDay(
        IEnumerable<NormalizedTicket> tickets,
        IEnumerable<NormalizedTicketLine> lines,
        ISet<string> concreteUoms)
    {
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
                var day = (t.TicketDate ?? t.OrderDate)!.Value.Date;

                return new
                {
                    Day = day,
                    Plant = t.ShipPlantCode,
                    Truck = t.TruckCode,
                    TicketCode = t.TicketCode,
                    ConcreteQty = qty,
                    Revenue = t.TicketDispatchTotalAmount,
                };
            })
            .ToList();

        return ticketRows
            .GroupBy(x => new { x.Day, x.Plant, x.Truck })
            .Select(g => new TruckUtilizationTruckDay
            {
                Day = g.Key.Day,
                PlantCode = g.Key.Plant,
                TruckCode = g.Key.Truck,
                TruckDay = 1,
                Loads = g.Select(x => x.TicketCode).Distinct().Count(),
                ConcreteCy = g.Sum(x => x.ConcreteQty),
                DispatchRevenue = g.Sum(x => x.Revenue),
            })
            .OrderBy(r => r.Day)
            .ThenBy(r => r.PlantCode)
            .ThenBy(r => r.TruckCode);
    }

    public static IEnumerable<TruckUtilizationTruckMonth> BuildTruckMonth(IEnumerable<TruckUtilizationTruckDay> truckDay)
    {
        return truckDay
            .GroupBy(x => new { Month = new DateTime(x.Day.Year, x.Day.Month, 1), x.PlantCode, x.TruckCode })
            .Select(g =>
            {
                var truckDays = g.Select(x => x.Day).Distinct().Count();
                var loads = g.Sum(x => x.Loads);
                var cy = g.Sum(x => x.ConcreteCy);
                var rev = g.Sum(x => x.DispatchRevenue);

                return new TruckUtilizationTruckMonth
                {
                    Month = g.Key.Month,
                    PlantCode = g.Key.PlantCode,
                    TruckCode = g.Key.TruckCode,
                    TruckDays = truckDays,
                    Loads = loads,
                    ConcreteCy = cy,
                    DispatchRevenue = rev,
                    LoadsPerTruckDay = truckDays > 0 ? (decimal)loads / truckDays : 0m,
                    CyPerTruckDay = truckDays > 0 ? cy / truckDays : 0m,
                };
            })
            .OrderBy(r => r.Month)
            .ThenBy(r => r.PlantCode)
            .ThenBy(r => r.TruckCode);
    }

    public static IEnumerable<PlantShippingDaysMonth> BuildPlantShippingDaysMonth(IEnumerable<TruckUtilizationTruckDay> truckDay)
    {
        return truckDay
            .GroupBy(x => new { Month = new DateTime(x.Day.Year, x.Day.Month, 1), x.PlantCode })
            .Select(g =>
            {
                var shippingDays = g.Select(x => x.Day).Distinct().Count();
                var truckDays = g.Sum(x => x.TruckDay);
                var loads = g.Sum(x => x.Loads);
                var cy = g.Sum(x => x.ConcreteCy);
                var rev = g.Sum(x => x.DispatchRevenue);

                return new PlantShippingDaysMonth
                {
                    Month = g.Key.Month,
                    PlantCode = g.Key.PlantCode,
                    ShippingDays = shippingDays,
                    TruckDays = truckDays,
                    Loads = loads,
                    ConcreteCy = cy,
                    DispatchRevenue = rev,
                };
            })
            .OrderBy(r => r.Month)
            .ThenBy(r => r.PlantCode);
    }
}

public sealed record TruckUtilizationTruckDay
{
    public DateTime Day { get; init; }
    public string PlantCode { get; init; } = string.Empty;
    public string TruckCode { get; init; } = string.Empty;

    public int TruckDay { get; init; }
    public int Loads { get; init; }
    public decimal ConcreteCy { get; init; }
    public decimal DispatchRevenue { get; init; }
}

public sealed record TruckUtilizationTruckMonth
{
    public DateTime Month { get; init; }
    public string PlantCode { get; init; } = string.Empty;
    public string TruckCode { get; init; } = string.Empty;

    public int TruckDays { get; init; }
    public int Loads { get; init; }
    public decimal ConcreteCy { get; init; }
    public decimal DispatchRevenue { get; init; }

    public decimal LoadsPerTruckDay { get; init; }
    public decimal CyPerTruckDay { get; init; }
}

public sealed record PlantShippingDaysMonth
{
    public DateTime Month { get; init; }
    public string PlantCode { get; init; } = string.Empty;

    public int ShippingDays { get; init; }
    public int TruckDays { get; init; }
    public int Loads { get; init; }
    public decimal ConcreteCy { get; init; }
    public decimal DispatchRevenue { get; init; }
}
