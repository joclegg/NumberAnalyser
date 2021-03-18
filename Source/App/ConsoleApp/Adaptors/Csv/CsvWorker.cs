using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal class CsvWorker : IHostedService
    {
        private CancellationTokenSource? cancellationTokenSource;
        private readonly ICsvBuilder csvBuilder;
        private readonly ILogger<CsvWorker> logger;

        public CsvWorker(
            ICsvBuilder csvBuilder,
            ILogger<CsvWorker> logger)
        {
            this.csvBuilder = csvBuilder;
            this.logger = logger;
        }
        
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("CsvWorker Starting");
            cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            await csvBuilder.BuildCsv(cancellationToken).ConfigureAwait(false);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            cancellationTokenSource?.Cancel();
            return Task.CompletedTask;
        }
    }
}