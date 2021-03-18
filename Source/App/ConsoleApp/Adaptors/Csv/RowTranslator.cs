using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal class RowTranslator : IRowTranslator
    {
        private readonly ILogger<RowTranslator> logger;

        public RowTranslator(ILogger<RowTranslator> logger)
        {
            this.logger = logger;
        }
        
        public IReadOnlyList<decimal> Translate(string row)
        {
            var numbers = new List<decimal>();
            var decimalStrings = row.Split(",");
            foreach (var decimalString in decimalStrings)
            {
                if (decimal.TryParse(decimalString, out var number))
                {
                    numbers.Add(number);
                }
                else
                {
                    logger.LogWarning($"Could not parse number {decimalString}");
                }
            }

            return numbers;
        }
    }
}