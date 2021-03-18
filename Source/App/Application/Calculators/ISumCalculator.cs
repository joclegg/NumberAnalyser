using System.Collections.Generic;

namespace NumberAnalyser.Application.Calculators
{
    internal interface ISumCalculator
    {
        decimal CalculateSum(IReadOnlyList<decimal> numbers);
    }
}