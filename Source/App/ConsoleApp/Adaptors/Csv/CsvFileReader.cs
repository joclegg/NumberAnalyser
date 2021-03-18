using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal class CsvFileReader : ICsvFileReader
    {
        private readonly IRowTranslator translator;
        private readonly CsvConfiguration configuration;
        
        public CsvFileReader(
            IOptions<CsvConfiguration> options,
            IRowTranslator translator)
        {
            this.translator = translator;
            configuration = options.Value;
        }
        
        public async IAsyncEnumerable<IReadOnlyList<decimal>> ReadRowsAsync([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            await foreach (var line in ReadLinesAsync().WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                yield return translator.Translate(line);
            }
        }

        private async IAsyncEnumerable<string> ReadLinesAsync()
        {
            await using var stream = new FileStream(
                configuration.CsvInputFilePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                32768,
                FileOptions.Asynchronous | FileOptions.SequentialScan);
            
            using var reader = new StreamReader(stream);
            
            while (true)
            {
                var line = await reader.ReadLineAsync().ConfigureAwait(false);
                if (line == null) break;
                yield return line;
            }
        }
    }
}