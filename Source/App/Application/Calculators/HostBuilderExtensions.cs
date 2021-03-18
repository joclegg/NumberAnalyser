using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NumberAnalyser.Application.Calculators
{
    internal static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureCalculators(this IHostBuilder hostBuilder) =>
            hostBuilder.ConfigureServices((context, services) => 
                services
                    .AddSingleton<ISumCalculator, SumCalculator>()
                    .AddSingleton<IArithmeticMeanCalculator, ArithmeticMeanCalculator>()
                    .AddSingleton<IStandardDeviationCalculator, StandardDeviationCalculator>()
                    .AddSingleton<IRangeFrequenciesCalculator, RangeFrequenciesCalculator>());
    }
}