using Tbh.Analytics.Models;
using Tbh.Extract.Models.CommandAlkon;

namespace Tbh.Analytics.Builders;

/// <summary>
/// Builds Plant Performance directly from raw SalesDetailRecords.
/// Simplified version for development with the dummy database.
/// </summary>
public class PlantPerformanceBuilder
{
    /// <summary>
    /// Builds Plant Performance records from raw sales detail.
    /// Groups by plant and month.
    /// </summary>
    public IEnumerable<PlantPerformanceRecord> Build(IEnumerable<SalesDetailRecord> salesDetails)
    {
        var grouped = salesDetails
            .Where(s => s.ShipPlantCode != null && s.TicketDate.HasValue)
            .GroupBy(s => new
            {
                PlantCode = s.ShipPlantCode!.Trim(),
                Year = s.TicketDate!.Value.Year,
                Period = s.TicketDate!.Value.Month
            });

        foreach (var group in grouped)
        {
            var records = group.ToList();

            var totalVolume = records.Sum(r => r.DeliveryQuantity ?? 0);
            var ticketCount = records.Count;
            var revenue = records.Sum(r => (r.ExtendedPriceAmount ?? 0) + (r.AssociatedProductAmount ?? 0) + (r.OtherProductAmount ?? 0));
            var matlCost = records.Sum(r => r.ExtendedMaterialCostAmount ?? 0);
            var haulCost = records.Sum(r => r.HaulCostAmount ?? 0);
            var ovhdCost = records.Sum(r => r.OverheadCostAmount ?? 0);
            var totalCost = matlCost + haulCost + ovhdCost;
            var contributionMargin = revenue - totalCost;

            yield return new PlantPerformanceRecord
            {
                AccountingYear = group.Key.Year,
                AccountingPeriod = group.Key.Period,
                PlantCode = group.Key.PlantCode,
                PlantName = $"Plant {group.Key.PlantCode}",

                TotalYards = totalVolume,
                TicketCount = ticketCount,
                AverageYardsPerTicket = ticketCount > 0 ? totalVolume / ticketCount : 0,

                Revenue = revenue,
                RevenuePerYard = totalVolume > 0 ? revenue / totalVolume : 0,

                EstimatedMaterialCost = matlCost,
                EstimatedHaulCost = haulCost,
                EstimatedOverheadCost = ovhdCost,
                TotalEstimatedCost = totalCost,

                ContributionMargin = contributionMargin,
                MarginPerYard = totalVolume > 0 ? contributionMargin / totalVolume : 0,
                MarginPercentage = revenue > 0 ? (contributionMargin / revenue) * 100 : 0,

                GeneratedAt = DateTime.UtcNow,
                DataSource = "CommandAlkon"
            };
        }
    }
}
