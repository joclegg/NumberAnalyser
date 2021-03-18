using System;
using System.Collections.Generic;

namespace NumberAnalyser.Application.Calculators
{
    internal class StandardDeviationCalculator : IStandardDeviationCalculator
    {
        private readonly IArithmeticMeanCalculator meanCalculator;

        public StandardDeviationCalculator(IArithmeticMeanCalculator meanCalculator)
        {
            this.meanCalculator = meanCalculator;
        }
        
        public decimal CalculateStandardDeviation(IReadOnlyList<decimal> numbers)
        {
            if (numbers.Count == 0) return 0;
            var mean = meanCalculator.CalculateArithmeticMean(numbers);
            var sumOfSquareDifferences = CalculateSumOfSquareDifferences(numbers, mean);
            var variance = sumOfSquareDifferences / numbers.Count;
            return (decimal)Math.Sqrt((double)variance);
        }

        private static decimal CalculateSumOfSquareDifferences(IReadOnlyList<decimal> numbers, decimal mean)
        {
            var sum = 0M;
            
            for (var i = 0; i < numbers.Count; i++)
            {
                var difference = numbers[i] - mean;
                sum += difference * difference;
            }

            return sum;
        }
    }
}