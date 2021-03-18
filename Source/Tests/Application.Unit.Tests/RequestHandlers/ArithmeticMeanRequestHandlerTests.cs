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
    public class ArithmeticMeanRequestHandlerTests
    {
        private readonly IFixture fixture = new Fixture();
        private IRequestHandler<ArithmeticMeanRequest, decimal> handler = null!;
        private IArithmeticMeanCalculator calculator = null!;
        
        [SetUp]
        public void SetUp()
        {
            calculator = Substitute.For<IArithmeticMeanCalculator>();
            handler = new ArithmeticMeanRequestHandler(calculator);
        }

        [Test]
        public async Task Given_ARequest_When_HandleCalled_Then_CallsCalculatorAndReturnsCalculatedValue()
        {
            // Arrange
            var expected = fixture.Create<decimal>();
            calculator
                .CalculateArithmeticMean(Arg.Any<IReadOnlyList<decimal>>())
                .Returns(expected);
            
            var request = fixture.Create<ArithmeticMeanRequest>();
            
            // Act
            var actual = await handler.Handle(request, CancellationToken.None);
            
            // Assert
            actual.ShouldBe(expected);
        }
    }
}