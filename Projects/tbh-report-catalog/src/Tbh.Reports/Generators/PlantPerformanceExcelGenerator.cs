using OfficeOpenXml;
using OfficeOpenXml.Style;
using Tbh.Analytics.Models;
using Tbh.Reports.Interfaces;

namespace Tbh.Reports.Generators;

/// <summary>
/// Generates Excel report for Plant Performance analytics.
/// </summary>
public class PlantPerformanceExcelGenerator : IExcelReportGenerator<PlantPerformanceRecord>
{
    public PlantPerformanceExcelGenerator()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    }
    
    public Task GenerateAsync(IEnumerable<PlantPerformanceRecord> data, string outputPath)
    {
        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Plant Performance");
        
        var records = data.OrderBy(r => r.PlantCode).ThenBy(r => r.AccountingPeriod).ToList();
        
        // Title
        worksheet.Cells["A1"].Value = "Plant Performance Report";
        worksheet.Cells["A1"].Style.Font.Bold = true;
        worksheet.Cells["A1"].Style.Font.Size = 16;
        
        worksheet.Cells["A2"].Value = $"Generated: {DateTime.Now:yyyy-MM-dd HH:mm}";
        worksheet.Cells["A3"].Value = $"Data Source: Command Alkon";
        
        // Headers
        var headers = new[]
        {
            "Plant", "Plant Name", "Year", "Period", "Month",
            "Total Volume (yds)", "Tickets", "Avg yds/Ticket",
            "Revenue", "Revenue/yd",
            "Material Cost", "Haul Cost", "Overhead Cost", "Total Est Cost",
            "Contribution Margin", "Margin/yd", "Margin %"
        };
        
        for (int i = 0; i < headers.Length; i++)
        {
            var cell = worksheet.Cells[5, i + 1];
            cell.Value = headers[i];
            cell.Style.Font.Bold = true;
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
        }
        
        // Data
        for (int row = 0; row < records.Count; row++)
        {
            var r = records[row];
            var excelRow = row + 6;
            
            worksheet.Cells[excelRow, 1].Value = r.PlantCode;
            worksheet.Cells[excelRow, 2].Value = r.PlantName;
            worksheet.Cells[excelRow, 3].Value = r.AccountingYear;
            worksheet.Cells[excelRow, 4].Value = r.AccountingPeriod;
            worksheet.Cells[excelRow, 5].Value = new DateTime(r.AccountingYear, r.AccountingPeriod, 1).ToString("MMM yyyy");
            
            worksheet.Cells[excelRow, 6].Value = (double)r.TotalYards;
            worksheet.Cells[excelRow, 6].Style.Numberformat.Format = "#,##0.00";
            
            worksheet.Cells[excelRow, 7].Value = r.TicketCount;
            
            worksheet.Cells[excelRow, 8].Value = (double)r.AverageYardsPerTicket;
            worksheet.Cells[excelRow, 8].Style.Numberformat.Format = "#,##0.00";
            
            worksheet.Cells[excelRow, 9].Value = (double)r.Revenue;
            worksheet.Cells[excelRow, 9].Style.Numberformat.Format = "$#,##0.00";
            
            worksheet.Cells[excelRow, 10].Value = (double)r.RevenuePerYard;
            worksheet.Cells[excelRow, 10].Style.Numberformat.Format = "$#,##0.00";
            
            worksheet.Cells[excelRow, 11].Value = (double)r.EstimatedMaterialCost;
            worksheet.Cells[excelRow, 11].Style.Numberformat.Format = "$#,##0.00";
            
            worksheet.Cells[excelRow, 12].Value = (double)r.EstimatedHaulCost;
            worksheet.Cells[excelRow, 12].Style.Numberformat.Format = "$#,##0.00";
            
            worksheet.Cells[excelRow, 13].Value = (double)r.EstimatedOverheadCost;
            worksheet.Cells[excelRow, 13].Style.Numberformat.Format = "$#,##0.00";
            
            worksheet.Cells[excelRow, 14].Value = (double)r.TotalEstimatedCost;
            worksheet.Cells[excelRow, 14].Style.Numberformat.Format = "$#,##0.00";
            
            worksheet.Cells[excelRow, 15].Value = (double)r.ContributionMargin;
            worksheet.Cells[excelRow, 15].Style.Numberformat.Format = "$#,##0.00";
            
            worksheet.Cells[excelRow, 16].Value = (double)r.MarginPerYard;
            worksheet.Cells[excelRow, 16].Style.Numberformat.Format = "$#,##0.00";
            
            worksheet.Cells[excelRow, 17].Value = (double)r.MarginPercentage / 100;
            worksheet.Cells[excelRow, 17].Style.Numberformat.Format = "0.0%";
        }
        
        // Totals row
        var totalsRow = records.Count + 6;
        worksheet.Cells[totalsRow, 1].Value = "TOTAL";
        worksheet.Cells[totalsRow, 1].Style.Font.Bold = true;
        
        worksheet.Cells[totalsRow, 6].Value = (double)records.Sum(r => r.TotalYards);
        worksheet.Cells[totalsRow, 6].Style.Numberformat.Format = "#,##0.00";
        worksheet.Cells[totalsRow, 6].Style.Font.Bold = true;
        
        worksheet.Cells[totalsRow, 7].Value = records.Sum(r => r.TicketCount);
        worksheet.Cells[totalsRow, 7].Style.Font.Bold = true;
        
        worksheet.Cells[totalsRow, 9].Value = (double)records.Sum(r => r.Revenue);
        worksheet.Cells[totalsRow, 9].Style.Numberformat.Format = "$#,##0.00";
        worksheet.Cells[totalsRow, 9].Style.Font.Bold = true;
        
        worksheet.Cells[totalsRow, 14].Value = (double)records.Sum(r => r.TotalEstimatedCost);
        worksheet.Cells[totalsRow, 14].Style.Numberformat.Format = "$#,##0.00";
        worksheet.Cells[totalsRow, 14].Style.Font.Bold = true;
        
        worksheet.Cells[totalsRow, 15].Value = (double)records.Sum(r => r.ContributionMargin);
        worksheet.Cells[totalsRow, 15].Style.Numberformat.Format = "$#,##0.00";
        worksheet.Cells[totalsRow, 15].Style.Font.Bold = true;
        
        // Auto-fit columns
        worksheet.Cells.AutoFitColumns();
        
        // Save
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
        package.SaveAs(new FileInfo(outputPath));
        
        return Task.CompletedTask;
    }
}
