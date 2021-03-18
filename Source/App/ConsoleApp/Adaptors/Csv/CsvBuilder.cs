using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal abstract class CsvBuilder<T> : ICsvBuilder
    {
        private readonly ICsvFileReader csvFileReader;
        private readonly ICsvFileWriter csvFileWriter;
        private readonly IResultTranslator<T> translator;
        private readonly IRowRequestBuilder<T> rowRequestBuilder;
        private readonly IMediator mediator;

        protected CsvBuilder(
            ICsvFileReader csvFileReader,
            ICsvFileWriter csvFileWriter,
            IResultTranslator<T> translator,
            IRowRequestBuilder<T> rowRequestBuilder,
            IMediator mediator)
        {
            this.csvFileReader = csvFileReader;
            this.csvFileWriter = csvFileWriter;
            this.translator = translator;
            this.rowRequestBuilder = rowRequestBuilder;
            this.mediator = mediator;
        }

        public async Task BuildCsv(CancellationToken cancellationToken)
        {
            var rows = csvFileReader.ReadRowsAsync(cancellationToken);
            var results = GetResults(rows, cancellationToken);
            await csvFileWriter.WriteCsv(results, translator.Translate, cancellationToken).ConfigureAwait(false);
        }

        private async IAsyncEnumerable<T> GetResults(IAsyncEnumerable<IReadOnlyList<decimal>> rows, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            await foreach (var row in rows.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                var request = rowRequestBuilder.CreateRequest(row);
                yield return await mediator.Send(request, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}