using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using MediatR;
using NSubstitute;
using NumberAnalyser.Application.Calculators;
using NumberAnalyser.Application.RequestHandlers;
using NumberAnalyser.Application.Requests;
using NUnit.Framework;
using Shouldly;

namespace NumberAnalyser.Application.Unit.Tests.RequestHandlers
{
    [TestFixture]
    public class RangeFrequenciesRequestHandlerTests
    {
        private readonly IFixture fixture = new Fixture();
        private IRequestHandler<RangeFrequenciesRequest, IDictionary<string, int>> handler = null!;
        private IRangeFrequenciesCalculator calculator = null!;
        
        [SetUp]
        public void SetUp()
        {
            calculator = Substitute.For<IRangeFrequenciesCalculator>();
            handler = new RangeFrequenciesRequestHandler(calculator);
        }

        [Test]
        public async Task Given_ARequest_When_HandleCalled_Then_CallsCalculatorAndReturnsCalculatedValue()
        {
            // Arrange
            var expected = fixture.Create<Dictionary<string, int>>();
            calculator
                .CalculateRangeFrequencies(Arg.Any<IReadOnlyList<decimal>>())
                .Returns(expected);
            
            var request = fixture.Create<RangeFrequenciesRequest>();
            
            // Act
            var actual = await handler.Handle(request, CancellationToken.None);
            
            // Assert
            actual.ShouldBe(expected);
        }
    }
}