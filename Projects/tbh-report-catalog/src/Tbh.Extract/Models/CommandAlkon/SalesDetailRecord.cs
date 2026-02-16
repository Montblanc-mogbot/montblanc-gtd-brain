namespace Tbh.Extract.Models.CommandAlkon;

/// <summary>
/// Raw sales detail from Command Alkon slsd table.
/// This is Layer 1: Extraction - no business logic, just "what is in the system"
/// 
/// NOTE: SLSD is the PRIMARY source for reporting because it matches
/// the Command reports that the board uses for validation.
/// </summary>
public record SalesDetailRecord
{
    // Identifiers
    public DateTime? OrderDate { get; init; }
    public string? OrderCode { get; init; }
    public string? TicketCode { get; init; }
    public DateTime? TicketDate { get; init; }
    
    // Plant and Company
    public string? ShipPlantCode { get; init; }
    public string? ShipCompanyCode { get; init; }
    public string? PricePlantCode { get; init; }
    public string? PriceCompanyCode { get; init; }
    
    // Customer and Project
    public string? CustomerCode { get; init; }
    public string? ShipCustomerCode { get; init; }
    public string? ReferenceCustomerCode { get; init; }
    public string? ProjectCode { get; init; }
    
    // Product
    public string? ItemCode { get; init; }
    public string? ItemType { get; init; }
    public string? ItemCategory { get; init; }
    public string? ProductLineCode { get; init; }
    
    // Salesperson
    public string? SalesmanEmployeeCode { get; init; }
    public string? SalesAnalysisCode { get; init; }
    
    // Delivery
    public string? ZoneCode { get; init; }
    public string? MapPage { get; init; }
    public string? HaulerCode { get; init; }
    public string? TruckCode { get; init; }
    public string? DriverEmployeeCode { get; init; }
    public string? DeliveryMethodCode { get; init; }
    
    // Volume
    /// <summary>
    /// Volume delivered (yards or other UOM)
    /// </summary>
    public decimal? DeliveryQuantity { get; init; }
    public string? DeliveryQuantityUom { get; init; }
    
    public decimal? PriceQuantity { get; init; }
    public string? PriceQuantityUom { get; init; }
    
    // Revenue
    /// <summary>
    /// Extended price (revenue)
    /// </summary>
    public decimal? ExtendedPriceAmount { get; init; }
    
    /// <summary>
    /// Haul charges billed to customer
    /// </summary>
    public decimal? HaulAmount { get; init; }
    
    /// <summary>
    /// Associated product revenue (additives, etc.)
    /// </summary>
    public decimal? AssociatedProductAmount { get; init; }
    
    /// <summary>
    /// Other product revenue
    /// </summary>
    public decimal? OtherProductAmount { get; init; }
    
    // Estimated Costs (from Command's standard costing)
    /// <summary>
    /// Estimated material cost (from Command's standard costs)
    /// </summary>
    public decimal? ExtendedMaterialCostAmount { get; init; }
    
    /// <summary>
    /// Estimated haul cost
    /// </summary>
    public decimal? HaulCostAmount { get; init; }
    
    /// <summary>
    /// Overhead allocation
    /// </summary>
    public decimal? OverheadCostAmount { get; init; }
    
    public decimal? AssociatedProductCostAmount { get; init; }
    public decimal? OtherProductCostAmount { get; init; }
    
    // Fixed and Variable Delivery Costs
    public decimal? FixedDeliveryCostAmount { get; init; }
    public decimal? EstimatedVariableDeliveryCostAmount { get; init; }
    public decimal? ActualVariableDeliveryCostAmount { get; init; }
    
    // Timing (for operational analysis)
    public DateTime? TypedTime { get; init; }
    public DateTime? LoadTime { get; init; }
    public DateTime? ToJobTime { get; init; }
    public DateTime? OnJobTime { get; init; }
    public DateTime? BeginUnloadTime { get; init; }
    public DateTime? EndUnloadTime { get; init; }
    public DateTime? WashTime { get; init; }
    public DateTime? ToPlantTime { get; init; }
    public DateTime? AtPlantTime { get; init; }
    
    // Duration calculations (minutes)
    public decimal? YardMinutes { get; init; }
    public decimal? LoadMinutes { get; init; }
    public decimal? ToJobMinutes { get; init; }
    public decimal? OnJobMinutes { get; init; }
    public decimal? UnloadMinutes { get; init; }
    public decimal? WashMinutes { get; init; }
    public decimal? ToPlantMinutes { get; init; }
    public decimal? DeadheadMinutes { get; init; }
    public decimal? RoundTripMinutes { get; init; }
    
    // Scheduling data
    public DateTime? ScheduledStartTime { get; init; }
    public decimal? ScheduledDistance { get; init; }
    public string? ScheduledDistanceUom { get; init; }
    
    // Metadata
    public DateTime? UpdateDate { get; init; }
}
