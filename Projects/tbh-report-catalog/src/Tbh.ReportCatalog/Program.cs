using Tbh.ReportCatalog;

namespace Tbh.ReportCatalog;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("TBH Report Catalog");
        Console.WriteLine("==================");
        Console.WriteLine();
        
        // TODO: Configure dependency injection and run orchestrator
        // This will be implemented once the extractor implementations are created
        
        Console.WriteLine("This is a scaffold project. Next steps:");
        Console.WriteLine("1. Implement ICommandAlkonExtractor (you write the SQL queries)");
        Console.WriteLine("2. Implement IExcelReportGenerator (Excel formatting)");
        Console.WriteLine("3. Configure connection strings");
        Console.WriteLine("4. Run the orchestrator");
        
        await Task.CompletedTask;
    }
}
