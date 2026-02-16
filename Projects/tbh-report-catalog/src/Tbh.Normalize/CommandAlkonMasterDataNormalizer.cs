using Tbh.Extract.Models.CommandAlkon;

namespace Tbh.Normalize;

public static class CommandAlkonMasterDataNormalizer
{
    private static string Norm(string? s) => string.IsNullOrWhiteSpace(s) ? string.Empty : s.Trim();

    public static NormalizedPlant Normalize(PlantRecord r)
    {
        return new NormalizedPlant
        {
            PlantCode = Norm(r.PlantCode).ToUpperInvariant(),
            ShortName = Norm(r.ShortName).ToUpperInvariant(),
            Name = Norm(r.Name),
            Location = Norm(r.Location),
        };
    }

    public static NormalizedCustomer Normalize(CustomerRecord r)
    {
        return new NormalizedCustomer
        {
            CustomerCode = Norm(r.CustomerCode).ToUpperInvariant(),
            Name = Norm(r.Name),
            City = Norm(r.City),
            State = Norm(r.State).ToUpperInvariant(),
        };
    }

    public static NormalizedItem Normalize(ItemMasterRecord r)
    {
        return new NormalizedItem
        {
            ItemCode = Norm(r.ItemCode).ToUpperInvariant(),
            ShortDescription = Norm(r.ShortDescription),
            Description = Norm(r.Description),
            ItemCategory = Norm(r.ItemCategory),
            MaterialType = Norm(r.MaterialType),
            OrderUom = Norm(r.OrderUom).ToUpperInvariant(),
            PriceUom = Norm(r.PriceUom).ToUpperInvariant(),
        };
    }
}

public record NormalizedPlant
{
    public string PlantCode { get; init; } = string.Empty;
    public string ShortName { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Location { get; init; } = string.Empty;
}

public record NormalizedCustomer
{
    public string CustomerCode { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string State { get; init; } = string.Empty;
}

public record NormalizedItem
{
    public string ItemCode { get; init; } = string.Empty;
    public string ShortDescription { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;

    public string ItemCategory { get; init; } = string.Empty;
    public string MaterialType { get; init; } = string.Empty;

    public string OrderUom { get; init; } = string.Empty;
    public string PriceUom { get; init; } = string.Empty;
}
