using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using NumberAnalyser.Application;
using NumberAnalyser.ConsoleApp.Adaptors.ApplicationConfiguration;
using NumberAnalyser.ConsoleApp.Adaptors.Csv;
using NumberAnalyser.ConsoleApp.Adaptors.Observability.Logging;

namespace NumberAnalyser.ConsoleApp
{
    internal static class Program
    {
        private static async Task Main()
        {
            await new HostBuilder()
                .ConfigureApplicationConfiguration()
                .ConfigureLogging()
                .ConfigureCsvManagement()
                .ConfigureApplication()
                .RunConsoleAsync();
        }
    }
}