using System.Collections.Generic;

namespace NumberAnalyser.Application.Calculators
{
    internal interface IRangeFrequenciesCalculator
    {
        IDictionary<string, int> CalculateRangeFrequencies(IReadOnlyList<decimal> numbers);
    }
}