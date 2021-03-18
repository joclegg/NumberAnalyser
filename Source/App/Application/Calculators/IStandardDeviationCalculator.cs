using System.Collections.Generic;

namespace NumberAnalyser.Application.Calculators
{
    internal interface IStandardDeviationCalculator
    {
        decimal CalculateStandardDeviation(IReadOnlyList<decimal> numbers);
    }
}