using System.Collections.Generic;

namespace NumberAnalyser.Application.Calculators
{
    internal class SumCalculator : ISumCalculator
    {
        public decimal CalculateSum(IReadOnlyList<decimal> numbers)
        {
            var sum = 0M;
            
            for (var i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }
    }
}