using OfficeOpenXml;
using OfficeOpenXml.Style;
using Tbh.Analytics.Builders;
using Tbh.Normalize;

namespace Tbh.Reports.Generators;

/// <summary>
/// CFO-facing dispatch/billing verification pack (dispatch-first).
/// Designed for data validation against Command/AR exports.
/// </summary>
public class DispatchCfoPackExcelGenerator
{
    public DispatchCfoPackExcelGenerator()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    }

    public Task GenerateAsync(
        DateTime startDate,
        DateTime endDate,
        IReadOnlyList<NormalizedPlant> plants,
        IReadOnlyList<NormalizedTicket> tickets,
        IReadOnlyList<NormalizedTicketLine> ticketLines,
        IReadOnlyList<NormalizedItrn> itrn,
        string outputPath)
    {
        using var package = new ExcelPackage();

        var plantNameByCode = plants
            .GroupBy(p => p.PlantCode)
            .ToDictionary(g => g.Key, g => g.First().ShortName.Length > 0 ? g.First().ShortName : g.First().Name);

        AddCover(package, startDate, endDate);
        AddDispatchPlantDay(package, ticketLines, plantNameByCode);
        AddDispatchPlantMonth(package, ticketLines, plantNameByCode);
        AddDispatchVsArByInvoice(package, tickets, ticketLines, itrn);

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
        package.SaveAs(new FileInfo(outputPath));
        return Task.CompletedTask;
    }

    private static void AddCover(ExcelPackage package, DateTime startDate, DateTime endDate)
    {
        var ws = package.Workbook.Worksheets.Add("Cover");
        ws.Cells["A1"].Value = "TBH Dispatch / Billing Verification Pack";
        ws.Cells["A1"].Style.Font.Bold = true;
        ws.Cells["A1"].Style.Font.Size = 16;

        ws.Cells["A3"].Value = "Period";
        ws.Cells["B3"].Value = $"{startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}";
        ws.Cells["A4"].Value = "Generated";
        ws.Cells["B4"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

        ws.Cells["A6"].Value = "Notes";
        ws.Cells["A6"].Style.Font.Bold = true;
        ws.Cells["A7"].Value = "Dispatch revenue is from TKTL.ext_price_amt.";
        ws.Cells["A8"].Value = "AR invoiced totals are from ITRN (trans_type 11/21) using pretax+tax.";
        ws.Cells["A9"].Value = "This workbook is for validation; exceptions logic is intentionally deferred.";

        ws.Cells.AutoFitColumns();
    }

    private static void AddDispatchPlantDay(ExcelPackage package, IReadOnlyList<NormalizedTicketLine> ticketLines, Dictionary<string, string> plantNameByCode)
    {
        var ws = package.Workbook.Worksheets.Add("Dispatch Plant Day");

        var concreteUoms = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "40003",
            "40005",
            "CY",
            "CYARD",
        };

        var rows = DispatchAnalyticsBuilders.BuildDispatchPlantDay(ticketLines, concreteUoms).ToList();

        var headers = new[] { "Day", "Plant", "Plant Name", "Delivered Qty", "Concrete Delivered Qty", "Revenue", "Ticket Lines" };
        for (var i = 0; i < headers.Length; i++)
        {
            var cell = ws.Cells[1, i + 1];
            cell.Value = headers[i];
            cell.Style.Font.Bold = true;
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
        }

        for (var r = 0; r < rows.Count; r++)
        {
            var row = rows[r];
            var excelRow = r + 2;
            ws.Cells[excelRow, 1].Value = row.Day;
            ws.Cells[excelRow, 1].Style.Numberformat.Format = "yyyy-mm-dd";
            ws.Cells[excelRow, 2].Value = row.PlantCode;
            ws.Cells[excelRow, 3].Value = plantNameByCode.TryGetValue(row.PlantCode, out var name) ? name : "";
            ws.Cells[excelRow, 4].Value = (double)row.DeliveredQty;
            ws.Cells[excelRow, 4].Style.Numberformat.Format = "#,##0.00";
            ws.Cells[excelRow, 5].Value = (double)row.ConcreteDeliveredQty;
            ws.Cells[excelRow, 5].Style.Numberformat.Format = "#,##0.00";
            ws.Cells[excelRow, 6].Value = (double)row.Revenue;
            ws.Cells[excelRow, 6].Style.Numberformat.Format = "$#,##0.00";
            ws.Cells[excelRow, 7].Value = row.TicketLineCount;
        }

        ws.Cells.AutoFitColumns();
    }

    private static void AddDispatchPlantMonth(ExcelPackage package, IReadOnlyList<NormalizedTicketLine> ticketLines, Dictionary<string, string> plantNameByCode)
    {
        var ws = package.Workbook.Worksheets.Add("Dispatch Plant Month");

        var concreteUoms = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "40003",
            "40005",
            "CY",
            "CYARD",
        };

        var rows = DispatchAnalyticsBuilders.BuildDispatchPlantMonth(ticketLines, concreteUoms).ToList();

        var headers = new[] { "Year", "Period", "Plant", "Plant Name", "Delivered Qty", "Concrete Delivered Qty", "Revenue", "Ticket Lines" };
        for (var i = 0; i < headers.Length; i++)
        {
            var cell = ws.Cells[1, i + 1];
            cell.Value = headers[i];
            cell.Style.Font.Bold = true;
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
        }

        for (var r = 0; r < rows.Count; r++)
        {
            var row = rows[r];
            var excelRow = r + 2;
            ws.Cells[excelRow, 1].Value = row.AccountingYear;
            ws.Cells[excelRow, 2].Value = row.AccountingPeriod;
            ws.Cells[excelRow, 3].Value = row.PlantCode;
            ws.Cells[excelRow, 4].Value = plantNameByCode.TryGetValue(row.PlantCode, out var name) ? name : "";
            ws.Cells[excelRow, 5].Value = (double)row.DeliveredQty;
            ws.Cells[excelRow, 5].Style.Numberformat.Format = "#,##0.00";
            ws.Cells[excelRow, 6].Value = (double)row.ConcreteDeliveredQty;
            ws.Cells[excelRow, 6].Style.Numberformat.Format = "#,##0.00";
            ws.Cells[excelRow, 7].Value = (double)row.Revenue;
            ws.Cells[excelRow, 7].Style.Numberformat.Format = "$#,##0.00";
            ws.Cells[excelRow, 8].Value = row.TicketLineCount;
        }

        ws.Cells.AutoFitColumns();
    }

    private static void AddDispatchVsArByInvoice(ExcelPackage package,
        IReadOnlyList<NormalizedTicket> tickets,
        IReadOnlyList<NormalizedTicketLine> ticketLines,
        IReadOnlyList<NormalizedItrn> itrn)
    {
        var ws = package.Workbook.Worksheets.Add("Dispatch vs AR (Invoice)");

        var dispatchByInv = DispatchAnalyticsBuilders.BuildDispatchInvoiceTotals(tickets, ticketLines).ToList();
        var recon = DispatchAnalyticsBuilders.BuildDispatchVsArInvoiceRecon(dispatchByInv, itrn).ToList();

        var headers = new[] { "Invoice Code", "Dispatch Revenue", "AR Total", "Difference" };
        for (var i = 0; i < headers.Length; i++)
        {
            var cell = ws.Cells[1, i + 1];
            cell.Value = headers[i];
            cell.Style.Font.Bold = true;
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
        }

        for (var r = 0; r < recon.Count; r++)
        {
            var row = recon[r];
            var excelRow = r + 2;
            ws.Cells[excelRow, 1].Value = row.InvoiceCode;
            ws.Cells[excelRow, 2].Value = (double)row.DispatchRevenue;
            ws.Cells[excelRow, 2].Style.Numberformat.Format = "$#,##0.00";
            ws.Cells[excelRow, 3].Value = (double)row.ArTotalAmount;
            ws.Cells[excelRow, 3].Style.Numberformat.Format = "$#,##0.00";
            ws.Cells[excelRow, 4].Value = (double)row.Difference;
            ws.Cells[excelRow, 4].Style.Numberformat.Format = "$#,##0.00";
        }

        ws.Cells.AutoFitColumns();
    }
}
