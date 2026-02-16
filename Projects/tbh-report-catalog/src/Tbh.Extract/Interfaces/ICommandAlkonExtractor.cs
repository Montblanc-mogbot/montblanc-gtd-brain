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
    /// Extract TICK (ticket headers) for a date range.
    /// Primary dispatch truth for plant attribution, invoicing status, etc.
    /// </summary>
    Task<IEnumerable<TicketRecord>> ExtractTicketsAsync(
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Extract TKTL (ticket lines) for a date range.
    /// Primary dispatch truth for delivered revenue (ext_price_amt).
    /// </summary>
    Task<IEnumerable<TicketLineRecord>> ExtractTicketLinesAsync(
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Extract ORDR (order headers) for a date range.
    /// Used for customer/order context and authoritative order_date.
    /// </summary>
    Task<IEnumerable<OrderHeaderRecord>> ExtractOrdersAsync(
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Extract ITRN transactions for a date range.
    /// Billing/AR-oriented export used for reconciliation with dispatch.
    /// </summary>
    Task<IEnumerable<ItrnRecord>> ExtractItrnAsync(
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Extract sales detail for a date range.
    /// NOTE: Currently backed by ORDL in the dummy DB; being phased out for dispatch-first reporting.
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
