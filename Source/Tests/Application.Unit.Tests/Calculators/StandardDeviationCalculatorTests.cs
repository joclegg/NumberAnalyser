using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using NSubstitute;
using NumberAnalyser.Application.Calculators;
using NUnit.Framework;
using Shouldly;

namespace NumberAnalyser.Application.Unit.Tests.Calculators
{
    [TestFixture]
    public class StandardDeviationCalculatorTests
    {
        private readonly IFixture fixture = new Fixture();
        private IStandardDeviationCalculator calculator = null!;

        [SetUp]
        public void SetUp()
        {
            var meanCalculator = Substitute.For<IArithmeticMeanCalculator>();
            meanCalculator
                .CalculateArithmeticMean(Arg.Any<IReadOnlyList<decimal>>())
                .Returns(info => ((IReadOnlyList<decimal>) info.Args()[0]).Average());

            calculator = new StandardDeviationCalculator(meanCalculator);
        }

        [Test]
        public void Given_ANumber_When_CalculateStandardDeviationCalled_Then_ReturnsZero()
        {
            // Arrange
            var numbers = new[] {fixture.Create<decimal>()};
            const decimal expected = 0;
            
            // Act    
            var actual = calculator.CalculateStandardDeviation(numbers);

            // Assert    
            actual.ShouldBe(expected);
        }

        [Test]
        public void Given_SomeNumbers_When_CalculateStandardDeviationCalled_Then_ReturnsStandardDeviation()
        {
            // Arrange
            var numbers = fixture.CreateMany<decimal>().ToArray();
            var mean = numbers.Average();
            var sumOfSquareDifferences = CalculateSumOfSquareDifferences(numbers, mean);
            var variance = sumOfSquareDifferences / numbers.Length;
            var expected = (decimal)Math.Sqrt((double)variance);
            
            // Act
            var actual = calculator.CalculateStandardDeviation(numbers);
            
            // Assert    
            actual.ShouldBe(expected);
        }

        [Test]
        public void Given_EmptyCollection_When_CalculateStandardDeviationCalled_Then_ReturnsZero()
        {
            // Arrange
            var numbers = Array.Empty<decimal>();
            const decimal expected = 0M;

            // Act    
            var actual = calculator.CalculateStandardDeviation(numbers);
            
            // Assert
            actual.ShouldBe(expected);
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