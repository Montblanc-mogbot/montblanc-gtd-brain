using Tbh.Extract.Models.CommandAlkon;

namespace Tbh.Extract.Interfaces;

/// <summary>
/// Interface for extracting data from Command Alkon.
/// Implementations should be in a separate project that has database access.
/// This interface ensures clean separation between extraction and processing.
/// </summary>
public interface ICommandAlkonExtractor
{
    /// <summary>
    /// Extract all plants from the plnt table.
    /// </summary>
    Task<IEnumerable<PlantRecord>> ExtractPlantsAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Extract all customers from the cust table.
    /// </summary>
    Task<IEnumerable<CustomerRecord>> ExtractCustomersAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Extract all items from the imst table.
    /// </summary>
    Task<IEnumerable<ItemMasterRecord>> ExtractItemsAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Extract sales detail for a date range.
    /// This is the primary source for volume and revenue by plant.
    /// </summary>
    Task<IEnumerable<SalesDetailRecord>> ExtractSalesDetailAsync(
        DateTime startDate, 
        DateTime endDate, 
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Export sales detail to CSV (for audit trail and offline processing).
    /// </summary>
    Task ExportSalesDetailToCsvAsync(
        DateTime startDate, 
        DateTime endDate, 
        string outputPath,
        CancellationToken cancellationToken = default);
}
