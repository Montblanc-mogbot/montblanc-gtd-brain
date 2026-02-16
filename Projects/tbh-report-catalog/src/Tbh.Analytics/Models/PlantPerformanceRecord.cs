namespace Tbh.Analytics.Models;

/// <summary>
/// Plant Performance analytical dataset.
/// One row per plant per month.
/// 
/// This is Layer 3: Analytical Datasets
/// "This dataset doesn't exist in any source system, it exists because we understand the business."
/// </summary>
public record PlantPerformanceRecord
{
    // Identifiers
    public required int AccountingYear { get; init; }
    public required int AccountingPeriod { get; init; }
    public required string PlantCode { get; init; }
    public required string PlantName { get; init; }
    
    // Volume Metrics
    public decimal TotalYards { get; init; }
    public int TicketCount { get; init; }
    public decimal AverageYardsPerTicket { get; init; }
    
    // Revenue
    public decimal Revenue { get; init; }
    public decimal RevenuePerYard { get; init; }
    
    // Command-Estimated Costs (operational view)
    public decimal EstimatedMaterialCost { get; init; }
    public decimal EstimatedHaulCost { get; init; }
    public decimal EstimatedOverheadCost { get; init; }
    public decimal TotalEstimatedCost { get; init; }
    
    // Contribution Margin (Command view)
    public decimal ContributionMargin { get; init; }
    public decimal MarginPerYard { get; init; }
    public decimal MarginPercentage { get; init; }
    
    // GL Costs (to be populated later when GL integration is built)
    public decimal? ActualMaterialCost { get; init; }
    public decimal? ActualFuelCost { get; init; }
    public decimal? ActualLaborCost { get; init; }
    public decimal? TotalActualCost { get; init; }
    
    // Reconciliation
    public decimal? CostVariance { get; init; }
    public decimal? CostVariancePercentage { get; init; }
    
    // Metadata
    public DateTime GeneratedAt { get; init; }
    public string DataSource { get; init; } = "CommandAlkon";
}
