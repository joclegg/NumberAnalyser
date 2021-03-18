using MediatR;
using Microsoft.Extensions.Hosting;
using NumberAnalyser.Application.Calculators;

namespace NumberAnalyser.Application
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureApplication(this IHostBuilder hostBuilder) =>
            hostBuilder
                .ConfigureCalculators()
                .ConfigureServices((context, services) =>
                    services.AddMediatR(typeof(HostBuilderExtensions)));
    }
}