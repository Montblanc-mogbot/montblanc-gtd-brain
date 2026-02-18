namespace Tbh.ReportCatalog.Pipeline;

public static class PipelineIo
{
    public static void EnsureDirectories(RunContext ctx)
    {
        Directory.CreateDirectory(ctx.RunDir);
        Directory.CreateDirectory(ctx.RunNormalizedDir);
        Directory.CreateDirectory(ctx.RunAnalyticsDir);
        Directory.CreateDirectory(ctx.RunReportsDir);

        Directory.CreateDirectory(ctx.LatestNormalizedDir);
        Directory.CreateDirectory(ctx.LatestAnalyticsDir);
        Directory.CreateDirectory(ctx.LatestReportsDir);
    }

    public static long? TryGetFileBytes(string path)
    {
        try
        {
            return new FileInfo(path).Length;
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Copy an immutable run artifact to the mutable "latest" folder.
    /// </summary>
    public static void CopyToLatest(string srcPath, string dstPath)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(dstPath)!);
        File.Copy(srcPath, dstPath, overwrite: true);
    }
}
