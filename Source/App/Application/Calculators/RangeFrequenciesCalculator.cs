using System.Collections.Generic;

namespace NumberAnalyser.Application.Calculators
{
    internal class RangeFrequenciesCalculator : IRangeFrequenciesCalculator
    {
        public IDictionary<string, int> CalculateRangeFrequencies(IReadOnlyList<decimal> numbers)
        {
            var rangeFrequencies = new Dictionary<string, int>();

            for (var i = 0; i < numbers.Count; i++)
            {
                var number = numbers[i];
                var range = GetRange(number);
                if (rangeFrequencies.ContainsKey(range))
                {
                    rangeFrequencies[range]++;
                }
                else
                {
                    rangeFrequencies[range] = 1;
                }
            }

            return rangeFrequencies;
        }

        public string GetRange(decimal number)
        {
            var lowerBound = (int) number / 10 * 10;
            return $"{lowerBound} - {lowerBound + 10}";
        }
    }
}