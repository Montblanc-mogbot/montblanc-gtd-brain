namespace Tbh.Extract.Models.CommandAlkon;

/// <summary>
/// Raw sales detail from Command Alkon slsd table.
/// This is Layer 1: Extraction - no business logic, just "what is in the system"
/// </summary>
public record SalesDetailRecord
{
    public DateTime? TicketDate { get; init; }
    public string? TicketCode { get; init; }
    public string? OrderCode { get; init; }
    public string? ShipPlantCode { get; init; }
    public string? CustomerCode { get; init; }
    public string? ProjectCode { get; init; }
    public string? ItemCode { get; init; }
    
    /// <summary>
    /// Volume delivered (yards or other UOM)
    /// </summary>
    public decimal? DeliveryQuantity { get; init; }
    
    public string? DeliveryQuantityUom { get; init; }
    
    /// <summary>
    /// Extended price (revenue)
    /// </summary>
    public decimal? ExtendedPriceAmount { get; init; }
    
    /// <summary>
    /// Estimated material cost (from Command's standard costs)
    /// </summary>
    public decimal? ExtendedMaterialCostAmount { get; init; }
    
    /// <summary>
    /// Haul charges billed to customer
    /// </summary>
    public decimal? HaulAmount { get; init; }
    
    /// <summary>
    /// Estimated haul cost
    /// </summary>
    public decimal? HaulCostAmount { get; init; }
    
    /// <summary>
    /// Overhead allocation
    /// </summary>
    public decimal? OverheadCostAmount { get; init; }
    
    public decimal? AssociatedProductAmount { get; init; }
    public decimal? AssociatedProductCostAmount { get; init; }
    public decimal? OtherProductAmount { get; init; }
    public decimal? OtherProductCostAmount { get; init; }
}
