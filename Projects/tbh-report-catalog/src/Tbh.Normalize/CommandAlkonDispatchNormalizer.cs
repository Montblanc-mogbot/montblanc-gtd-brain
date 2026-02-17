using Tbh.Extract.Models.CommandAlkon;

namespace Tbh.Normalize;

/// <summary>
/// Normalization for dispatch-first reporting (TICK/TKTL/ORDR).
///
/// Key rule: normalized data should be explainable to an auditor in plain English.
/// Keep it narrow and stable; do NOT bake report-specific logic here.
/// </summary>
public static class CommandAlkonDispatchNormalizer
{
    public static string NormalizePlantCode(string? rawPlantCode) =>
        string.IsNullOrWhiteSpace(rawPlantCode) ? "UNKNOWN" : rawPlantCode.Trim().ToUpperInvariant();

    public static string NormalizeCode(string? raw) =>
        string.IsNullOrWhiteSpace(raw) ? string.Empty : raw.Trim();

    public static NormalizedTicket Normalize(TicketRecord r)
    {
        return new NormalizedTicket
        {
            OrderDate = r.OrderDate,
            OrderCode = NormalizeCode(r.OrderCode),
            TicketCode = NormalizeCode(r.TicketCode),
            TicketDate = r.TicketDate,
            ShipPlantCode = NormalizePlantCode(r.ShipPlantCode),
            RawShipPlantCode = r.ShipPlantCode,
            RemoveReasonCode = NormalizeCode(r.RemoveReasonCode),
            InvcFlag = NormalizeCode(r.InvcFlag),
            InvcCode = NormalizeCode(r.InvcCode),
            InvcDate = r.InvcDate,
            InvcSeqNum = r.InvcSeqNum,
            TicketStatus = NormalizeCode(r.TicketStatus),
            UpdateDate = r.UpdateDate,
        };
    }

    public static NormalizedTicketLine Normalize(TicketLineRecord r)
    {
        return new NormalizedTicketLine
        {
            OrderDate = r.OrderDate,
            OrderCode = NormalizeCode(r.OrderCode),
            TicketCode = NormalizeCode(r.TicketCode),
            OrderInternalLineNum = r.OrderInternalLineNum,
            DeliveredQty = r.DeliveredQty,
            DeliveredQtyUom = NormalizeCode(r.DeliveredQtyUom).ToUpperInvariant(),
            ShipPlantCode = NormalizePlantCode(r.ShipPlantCode),
            RawShipPlantCode = r.ShipPlantCode,
            ExtendedPriceAmount = r.ExtendedPriceAmount,
            UpdateDate = r.UpdateDate,
        };
    }

    public static NormalizedOrderHeader Normalize(OrderHeaderRecord r)
    {
        return new NormalizedOrderHeader
        {
            OrderDate = r.OrderDate,
            OrderCode = NormalizeCode(r.OrderCode),
            ProductLineCode = NormalizeCode(r.ProductLineCode),
            CustomerCode = NormalizeCode(r.CustomerCode),
            CustomerName = NormalizeCode(r.CustomerName),
            ShipToPlantCode = NormalizePlantCode(r.ShipToPlantCode),
            RawShipToPlantCode = r.ShipToPlantCode,
            ZoneCode = NormalizeCode(r.ZoneCode),
            ProjectCode = NormalizeCode(r.ProjectCode),
            UpdateDate = r.UpdateDate,
        };
    }
}

public record NormalizedTicket
{
    public DateTime? OrderDate { get; init; }
    public string OrderCode { get; init; } = string.Empty;

    public string TicketCode { get; init; } = string.Empty;
    public DateTime? TicketDate { get; init; }

    public string ShipPlantCode { get; init; } = string.Empty;
    public string? RawShipPlantCode { get; init; }

    public string RemoveReasonCode { get; init; } = string.Empty;

    public string InvcFlag { get; init; } = string.Empty;
    public string InvcCode { get; init; } = string.Empty;
    public DateTime? InvcDate { get; init; }
    public int? InvcSeqNum { get; init; }

    public string TicketStatus { get; init; } = string.Empty;

    public DateTime? UpdateDate { get; init; }
}

public record NormalizedTicketLine
{
    public DateTime? OrderDate { get; init; }
    public string OrderCode { get; init; } = string.Empty;

    public string TicketCode { get; init; } = string.Empty;
    public int? OrderInternalLineNum { get; init; }

    public decimal? DeliveredQty { get; init; }
    public string DeliveredQtyUom { get; init; } = string.Empty;

    public string ShipPlantCode { get; init; } = string.Empty;
    public string? RawShipPlantCode { get; init; }

    public decimal? ExtendedPriceAmount { get; init; }

    public DateTime? UpdateDate { get; init; }
}

public record NormalizedOrderHeader
{
    public DateTime? OrderDate { get; init; }
    public string OrderCode { get; init; } = string.Empty;

    public string ProductLineCode { get; init; } = string.Empty;

    public string CustomerCode { get; init; } = string.Empty;
    public string CustomerName { get; init; } = string.Empty;

    public string ShipToPlantCode { get; init; } = string.Empty;
    public string? RawShipToPlantCode { get; init; }

    public string ZoneCode { get; init; } = string.Empty;
    public string ProjectCode { get; init; } = string.Empty;

    public DateTime? UpdateDate { get; init; }
}
