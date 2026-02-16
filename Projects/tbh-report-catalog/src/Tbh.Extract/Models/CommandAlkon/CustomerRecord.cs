namespace Tbh.Extract.Models.CommandAlkon;

/// <summary>
/// Customer master from Command Alkon cust table.
/// </summary>
public record CustomerRecord
{
    public string? CustomerCode { get; init; }
    public string? Name { get; init; }
    public string? SortName { get; init; }
    public string? AddressLine1 { get; init; }
    public string? City { get; init; }
    public string? State { get; init; }
    public string? PostalCode { get; init; }
    public string? PhoneNumber { get; init; }
    public string? ContactName { get; init; }
    public DateTime? SetupDate { get; init; }
    public string? TaxCode { get; init; }
    public string? InactiveCode { get; init; }
}
