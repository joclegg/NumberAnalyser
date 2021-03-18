using System.Collections.Generic;

namespace NumberAnalyser.Application.Calculators
{
    internal interface IArithmeticMeanCalculator
    {
        decimal CalculateArithmeticMean(IReadOnlyList<decimal> numbers);
    }
}