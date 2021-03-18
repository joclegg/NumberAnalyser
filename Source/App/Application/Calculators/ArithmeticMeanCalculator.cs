using System.Collections.Generic;

namespace NumberAnalyser.Application.Calculators
{
    internal class ArithmeticMeanCalculator : IArithmeticMeanCalculator
    {
        private readonly ISumCalculator sumCalculator;

        public ArithmeticMeanCalculator(ISumCalculator sumCalculator)
        {
            this.sumCalculator = sumCalculator;
        }
        
        public decimal CalculateArithmeticMean(IReadOnlyList<decimal> numbers)
        {
            if (numbers.Count == 0) return 0;

            var sum = sumCalculator.CalculateSum(numbers);
            
            if (sum == 0) return 0;
            
            return sum / numbers.Count;
        }
    }
}