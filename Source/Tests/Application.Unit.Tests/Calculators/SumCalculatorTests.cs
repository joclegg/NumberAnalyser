using System;
using System.Linq;
using AutoFixture;
using NumberAnalyser.Application.Calculators;
using NUnit.Framework;
using Shouldly;

namespace NumberAnalyser.Application.Unit.Tests.Calculators
{
    [TestFixture]
    public class SumCalculatorTests
    {
        private readonly IFixture fixture = new Fixture();
        private ISumCalculator calculator = null!;
        
        [SetUp]
        public void SetUp()
        {
            calculator = new SumCalculator();
        }
        
        [Test]
        public void Given_SomeNumbers_When_CalculateSumCalled_Then_CalculatesSum()
        {
            // Arrange
            var numbers = fixture.CreateMany<decimal>().ToArray();
            var expected = numbers.Sum();

            // Act    
            var actual = calculator.CalculateSum(numbers);
            
            // Assert
            actual.ShouldBe(expected);
        }

        [Test]
        public void Given_EmptyCollection_When_CalculateSumCalled_Then_ReturnsZero()
        {
            // Arrange
            var numbers = Array.Empty<decimal>();
            const int expected = 0;
            
            // Act
            var actual = calculator.CalculateSum(numbers);
            
            // Assert
            actual.ShouldBe(expected);
        }
    }
}