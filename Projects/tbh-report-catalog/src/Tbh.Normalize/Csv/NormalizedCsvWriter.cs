using System.Text;

namespace Tbh.Normalize.Csv;

public static class NormalizedCsvWriter
{
    public static async Task WriteAsync<T>(
        IEnumerable<T> rows,
        string path,
        IReadOnlyList<(string Header, Func<T, string> Value)> columns,
        CancellationToken cancellationToken = default)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path) ?? ".");

        await using var stream = File.Create(path);
        await using var writer = new StreamWriter(stream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));

        await writer.WriteLineAsync(string.Join(',', columns.Select(c => Escape(c.Header))));

        foreach (var row in rows)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var line = string.Join(',', columns.Select(c => Escape(c.Value(row))));
            await writer.WriteLineAsync(line);
        }
    }

    private static string Escape(string? value)
    {
        var s = value ?? string.Empty;
        var mustQuote = s.Contains(',') || s.Contains('"') || s.Contains('\n') || s.Contains('\r');
        if (!mustQuote) return s;
        return '"' + s.Replace("\"", "\"\"") + '"';
    }
}
