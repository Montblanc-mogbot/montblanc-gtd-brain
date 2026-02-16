using Tbh.Analytics.Models;
using Tbh.Normalize;
using Tbh.Extract.Models.CommandAlkon;

namespace Tbh.Analytics.Builders;

/// <summary>
/// Builds the Plant Performance analytical dataset from normalized Command Alkon data.
/// 
/// Key Rule: "Each dataset answers one business question well"
/// This dataset answers: "How did each plant perform this month?"
/// </summary>
public class PlantPerformanceBuilder
{
    private readonly Dictionary<string, string> _plantNames;
    
    public PlantPerformanceBuilder(IEnumerable<PlantRecord> plants)
    {
        _plantNames = plants.ToDictionary(
            p => CommandAlkonNormalizer.NormalizePlantCode(p.PlantCode),
            p => p.Name ?? p.ShortName ?? p.PlantCode ?? "Unknown",
            StringComparer.OrdinalIgnoreCase);
    }
    
    /// <summary>
    /// Builds Plant Performance records from normalized sales detail.
    /// </summary>
    public IEnumerable<PlantPerformanceRecord> Build(IEnumerable<NormalizedSalesDetail> salesDetails)
    {
        var grouped = CommandAlkonNormalizer.GroupByPlantAndPeriod(salesDetails);
        
        foreach (var group in grouped)
        {
            var (plantCode, year, period) = group.Key;
            var records = group.ToList();
            
            yield return BuildRecord(plantCode, year, period, records);
        }
    }
    
    private PlantPerformanceRecord BuildRecord(
        string plantCode, 
        int year, 
        int period, 
        IReadOnlyList<NormalizedSalesDetail> records)
    {
        var totalYards = records.Sum(r => r.DeliveryQuantity);
        var ticketCount = records.Count;
        var revenue = records.Sum(r => r.Revenue + r.AssociatedProductRevenue + r.OtherProductRevenue);
        var estMaterialCost = records.Sum(r => r.EstimatedMaterialCost);
        var estHaulCost = records.Sum(r => r.EstimatedHaulCost);
        var estOverheadCost = records.Sum(r => r.EstimatedOverheadCost);
        var totalEstCost = records.Sum(r => r.TotalEstimatedCost);
        var contributionMargin = records.Sum(r => r.ContributionMargin);
        
        return new PlantPerformanceRecord
        {
            AccountingYear = year,
            AccountingPeriod = period,
            PlantCode = plantCode,
            PlantName = _plantNames.GetValueOrDefault(plantCode, plantCode),
            
            TotalYards = totalYards,
            TicketCount = ticketCount,
            AverageYardsPerTicket = ticketCount > 0 ? totalYards / ticketCount : 0,
            
            Revenue = revenue,
            RevenuePerYard = totalYards > 0 ? revenue / totalYards : 0,
            
            EstimatedMaterialCost = estMaterialCost,
            EstimatedHaulCost = estHaulCost,
            EstimatedOverheadCost = estOverheadCost,
            TotalEstimatedCost = totalEstCost,
            
            ContributionMargin = contributionMargin,
            MarginPerYard = totalYards > 0 ? contributionMargin / totalYards : 0,
            MarginPercentage = revenue > 0 ? (contributionMargin / revenue) * 100 : 0,
            
            GeneratedAt = DateTime.UtcNow,
            DataSource = "CommandAlkon"
        };
    }
}
