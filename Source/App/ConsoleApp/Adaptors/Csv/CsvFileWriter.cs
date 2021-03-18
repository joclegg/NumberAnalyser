using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal class CsvFileWriter : ICsvFileWriter
    {
        private readonly CsvConfiguration configuration;

        public CsvFileWriter(IOptions<CsvConfiguration> options)
        {
            configuration = options.Value;
        }

        public async Task WriteCsv<T>(IAsyncEnumerable<T> results, Func<T, string> translationDelegate, CancellationToken cancellationToken)
        {
            await using var stream = new FileStream(
                configuration.CsvOutputFilePath,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None,
                32768,
                true);

            await using var writer = new StreamWriter(stream);
            
            await foreach (var result in results.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                await writer.WriteLineAsync(translationDelegate(result)).ConfigureAwait(false);
            }
        }

        public async Task WriteDecimalFile(IAsyncEnumerable<decimal> results, CancellationToken cancellationToken)
        {
            await WriteCsv(results, x => x.ToString(CultureInfo.InvariantCulture), cancellationToken).ConfigureAwait(false);
        }

        public async Task WriteDictionaryFile(IAsyncEnumerable<IDictionary<string, int>> results, CancellationToken cancellationToken)
        {
            await WriteCsv(results, x => JsonSerializer.Serialize(x), cancellationToken).ConfigureAwait(false);
        }
    }
}