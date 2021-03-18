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
    public class ArithmeticMeanCalculatorTests
    {
        private readonly IFixture fixture = new Fixture();
        private IArithmeticMeanCalculator calculator = null!;
        
        [SetUp]
        public void SetUp()
        {
            var sumCalculator = Substitute.For<ISumCalculator>();
            sumCalculator
                .CalculateSum(Arg.Any<IReadOnlyList<decimal>>())
                .Returns(info => ((IReadOnlyList<decimal>) info.Args()[0]).Sum());
            
            calculator = new ArithmeticMeanCalculator(sumCalculator);
        }

        [Test]
        public void Given_ANumber_When_CalculateArithmeticMeanCalled_Then_ReturnsNumber()
        {
            // Arrange
            var expected = fixture.Create<decimal>(); 
            var numbers = new[] {expected};
            
            // Act    
            var actual = calculator.CalculateArithmeticMean(numbers);

            // Assert    
            actual.ShouldBe(expected);
        }

        [Test]
        public void Given_SomeNumbers_When_CalculateArithmeticMeanCalled_Then_ReturnsMean()
        {
            // Arrange
            var numbers = fixture.CreateMany<decimal>().ToArray();
            var expected = numbers.Average();
            
            // Act
            var actual = calculator.CalculateArithmeticMean(numbers);
            
            // Assert    
            actual.ShouldBe(expected);
        }

        [Test]
        public void Given_EmptyCollection_When_CalculateArithmeticMeanCalled_Then_ReturnsZero()
        {
            // Arrange
            var numbers = Array.Empty<decimal>();
            const decimal expected = 0;

            // Act    
            var actual = calculator.CalculateArithmeticMean(numbers);
            
            // Assert
            actual.ShouldBe(expected);
        }
    }
}