using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureCsvManagement(this IHostBuilder hostBuilder) =>
            hostBuilder
                .ConfigureServices((context, services) =>
                {
                    services
                        .AddOptions<CsvConfiguration>()
                        .Bind(context.Configuration.GetSection(nameof(CsvConfiguration)));

                    services
                        .AddSingleton<IRowTranslator, RowTranslator>()
                        .AddSingleton<ICsvFileReader, CsvFileReader>()
                        .AddSingleton<ICsvFileWriter, CsvFileWriter>()
                        .AddSingleton<ArithmeticMeanCsvBuilder>()
                        .AddSingleton<StandardDeviationCsvBuilder>()
                        .AddSingleton<RangeFrequencyCsvBuilder>()
                        .AddSingleton<ICsvBuilder>(provider =>
                        {
                            var option = provider.GetRequiredService<IOptions<CsvConfiguration>>().Value.CsvOption;
                            return option switch
                            {
                                CsvOption.ArithmeticMean => provider.GetRequiredService<ArithmeticMeanCsvBuilder>(),
                                CsvOption.StandardDeviation =>
                                    provider.GetRequiredService<StandardDeviationCsvBuilder>(),
                                CsvOption.RangeFrequency => provider.GetRequiredService<RangeFrequencyCsvBuilder>(),
                                _ => throw new ArgumentOutOfRangeException(nameof(option), option,
                                    "CsvOption not recognised")
                            };
                        })
                        .AddHostedService<CsvWorker>();
                });
    }
}