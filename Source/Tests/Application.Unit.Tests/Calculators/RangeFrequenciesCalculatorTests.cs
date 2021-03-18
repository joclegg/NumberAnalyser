using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using NumberAnalyser.Application.Calculators;
using NUnit.Framework;
using Shouldly;

namespace NumberAnalyser.Application.Unit.Tests.Calculators
{
    [TestFixture]
    public class RangeFrequenciesCalculatorTests
    {
        private readonly IFixture fixture = new Fixture();
        private IRangeFrequenciesCalculator calculator = null!;
        
        [SetUp]
        public void SetUp()
        {
            calculator = new RangeFrequenciesCalculator();
        }

        [Test]
        public void Given_ANumber_When_CalculateRangeFrequenciesCalled_Then_Returns_OneRangeFrequency()
        {
            // Arrange
            var numbers = new[] { 1.2M };
            const string expectedBucket = "0 - 10";
            const int expectedFrequency = 1;
            
            // Act
            var actual = calculator.CalculateRangeFrequencies(numbers);
            
            // Assert  
            actual.Count.ShouldBe(1);
            actual[expectedBucket].ShouldBe(expectedFrequency);
        }

        [Test]
        public void Given_SomeNumbers_When_CalculateRangeFrequenciesCalled_Then_ReturnsRangeFrequencies()
        {
            // Arrange
            var numbers = fixture.CreateMany<decimal>().ToArray();
            var expectedDictionary = CreateExpectedDictionary(numbers);

            // Act    
            var actualDictionary = calculator.CalculateRangeFrequencies(numbers);
            
            // Assert
            actualDictionary.Count.ShouldBe(expectedDictionary.Count);
            
            foreach (var (expectedKey, expectedValue) in expectedDictionary)
            {
                actualDictionary[expectedKey].ShouldBe(expectedValue);
            }
        }

        [Test]
        public void Given_EmptyCollection_When_CalculateRangeFrequenciesCalled_Then_ReturnsEmptyCollection()
        {
            // Arrange
            var numbers = Array.Empty<decimal>();
            
            // Act
            var actual = calculator.CalculateRangeFrequencies(numbers);
            
            // Assert
            actual.ShouldBeEmpty();
        }

        private static IDictionary<string,int> CreateExpectedDictionary(IEnumerable<decimal> numbers)
        {
            var result = new Dictionary<string, int>();
            
            foreach (var number in numbers)
            {
                var floor = (int) number / 10 * 10;

                var range = $"{floor} - {floor + 10}";
                
                if(result.ContainsKey(range))
                {
                    result[range]++;
                }
                else
                {
                    result[range] = 1;
                }
            }

            return result;
        }
    }
}