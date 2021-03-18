using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace NumberAnalyser.ConsoleApp.Adaptors.ApplicationConfiguration
{
    internal static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureApplicationConfiguration(this IHostBuilder hostBuilder) =>
            hostBuilder
                .ConfigureHostConfiguration(configuration =>
                    configuration.SetBasePath(Directory.GetCurrentDirectory()))
                .ConfigureAppConfiguration((_, configuration) =>
                    configuration.AddJsonFile("appsettings.json"));
    }
}