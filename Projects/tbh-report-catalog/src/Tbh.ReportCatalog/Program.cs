namespace Tbh.ReportCatalog;

class Program
{
    static async Task<int> Main(string[] args)
    {
        // Project root
        var projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", ".."));

        // DB path
        var dbCandidates = new[]
        {
            Path.Combine(projectRoot, "data", "command_alkon_dummy.db"),
            Path.Combine(projectRoot, "data", "tbh_dummy.sqlite"),
        };

        var dbPath = dbCandidates.FirstOrDefault(File.Exists);
        if (dbPath is null)
        {
            Console.WriteLine("No dummy database found. Expected one of:");
            foreach (var p in dbCandidates) Console.WriteLine($"  - {p}");
            Console.WriteLine("Hint: run: python scripts/sqlite/build_dummy_db.py");
            return 1;
        }

        // Dates
        DateTime startDate, endDate;
        if (args.Length >= 2 && DateTime.TryParse(args[0], out var s) && DateTime.TryParse(args[1], out var e))
        {
            startDate = s;
            endDate = e;
        }
        else
        {
            startDate = new DateTime(2025, 1, 1);
            endDate = new DateTime(2025, 2, 1);
        }

        static bool IsWholeMonthWindow(DateTime start, DateTime end) =>
            start.Day == 1 && end.Day == 1 && end == start.AddMonths(1);

        var prefix = IsWholeMonthWindow(startDate, endDate)
            ? startDate.ToString("yyyyMM")
            : startDate.ToString("yyyyMMdd");

        var runDir = Path.Combine(projectRoot, "runs", $"{DateTime.Now:yyyyMMdd_HHmmss}_{prefix}");

        var ctx = new Pipeline.RunContext
        {
            StartDate = startDate,
            EndDate = endDate,
            ProjectRoot = projectRoot,
            DbPath = dbPath,
            Prefix = prefix,
            RunDir = runDir,
        };

        return await Pipeline.PipelineRunner.RunAsync(ctx);
    }
}
