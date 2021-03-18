using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NumberAnalyser.ConsoleApp.Adaptors.Observability.Logging
{
    internal static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureLogging(this IHostBuilder hostBuilder) =>
            hostBuilder.ConfigureLogging(logging => logging.AddConsole());
    }
}