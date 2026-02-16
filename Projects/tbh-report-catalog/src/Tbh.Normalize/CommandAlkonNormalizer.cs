using Tbh.Extract.Models.CommandAlkon;

namespace Tbh.Normalize;

/// <summary>
/// Normalizes Command Alkon data before analytical processing.
/// 
/// Key Rule: "Normalized data should be explainable to an auditor in plain English"
/// </summary>
public static class CommandAlkonNormalizer
{
    /// <summary>
    /// Normalizes plant codes to ensure consistency.
    /// Handles cases where the same plant might have different codes in different systems.
    /// </summary>
    public static string NormalizePlantCode(string? rawPlantCode)
    {
        if (string.IsNullOrWhiteSpace(rawPlantCode))
            return "UNKNOWN";
        
        // Trim and uppercase for consistency
        var normalized = rawPlantCode.Trim().ToUpperInvariant();
        
        // TODO: Add specific normalization rules as discovered
        // Examples:
        // - Map "MAIN" to "001"
        // - Map legacy codes to current codes
        
        return normalized;
    }
    
    /// <summary>
    /// Normalizes a sales detail record for analytical processing.
    /// </summary>
    public static NormalizedSalesDetail Normalize(SalesDetailRecord record)
    {
        return new NormalizedSalesDetail
        {
            TicketDate = record.TicketDate ?? DateTime.MinValue,
            AccountingYear = record.TicketDate?.Year ?? 0,
            AccountingPeriod = record.TicketDate?.Month ?? 0,
            PlantCode = NormalizePlantCode(record.ShipPlantCode),
            RawPlantCode = record.ShipPlantCode,
            CustomerCode = record.CustomerCode?.Trim() ?? string.Empty,
            ProjectCode = record.ProjectCode?.Trim() ?? string.Empty,
            ItemCode = record.ItemCode?.Trim() ?? string.Empty,
            
            // Normalize quantities (ensure consistent UOM handling)
            DeliveryQuantity = record.DeliveryQuantity ?? 0,
            DeliveryQuantityUom = record.DeliveryQuantityUom?.Trim().ToUpperInvariant() ?? "YD",
            
            // Financial amounts
            Revenue = record.ExtendedPriceAmount ?? 0,
            EstimatedMaterialCost = record.ExtendedMaterialCostAmount ?? 0,
            HaulCharges = record.HaulAmount ?? 0,
            EstimatedHaulCost = record.HaulCostAmount ?? 0,
            EstimatedOverheadCost = record.OverheadCostAmount ?? 0,
            AssociatedProductRevenue = record.AssociatedProductAmount ?? 0,
            AssociatedProductCost = record.AssociatedProductCostAmount ?? 0,
            OtherProductRevenue = record.OtherProductAmount ?? 0,
            OtherProductCost = record.OtherProductCostAmount ?? 0,
        };
    }
    
    /// <summary>
    /// Groups normalized sales detail by plant and period for aggregation.
    /// </summary>
    public static IEnumerable<IGrouping<( string PlantCode, int Year, int Period), NormalizedSalesDetail>> GroupByPlantAndPeriod(
        IEnumerable<NormalizedSalesDetail> records)
    {
        return records.GroupBy(r => (r.PlantCode, r.AccountingYear, r.AccountingPeriod));
    }
}

/// <summary>
/// Normalized representation of a sales detail record.
/// All fields are guaranteed to have values (no nulls for processing).
/// </summary>
public record NormalizedSalesDetail
{
    public DateTime TicketDate { get; init; }
    public int AccountingYear { get; init; }
    public int AccountingPeriod { get; init; }
    public string PlantCode { get; init; } = string.Empty;
    public string? RawPlantCode { get; init; }
    public string CustomerCode { get; init; } = string.Empty;
    public string ProjectCode { get; init; } = string.Empty;
    public string ItemCode { get; init; } = string.Empty;
    
    public decimal DeliveryQuantity { get; init; }
    public string DeliveryQuantityUom { get; init; } = "YD";
    
    public decimal Revenue { get; init; }
    public decimal EstimatedMaterialCost { get; init; }
    public decimal HaulCharges { get; init; }
    public decimal EstimatedHaulCost { get; init; }
    public decimal EstimatedOverheadCost { get; init; }
    public decimal AssociatedProductRevenue { get; init; }
    public decimal AssociatedProductCost { get; init; }
    public decimal OtherProductRevenue { get; init; }
    public decimal OtherProductCost { get; init; }
    
    /// <summary>
    /// Total estimated cost for contribution margin calculation.
    /// </summary>
    public decimal TotalEstimatedCost => 
        EstimatedMaterialCost + 
        EstimatedHaulCost + 
        EstimatedOverheadCost +
        AssociatedProductCost +
        OtherProductCost;
    
    /// <summary>
    /// Contribution margin for this line.
    /// </summary>
    public decimal ContributionMargin => 
        Revenue + AssociatedProductRevenue + OtherProductRevenue - TotalEstimatedCost;
}
