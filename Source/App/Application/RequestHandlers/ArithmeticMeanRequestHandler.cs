using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NumberAnalyser.Application.Calculators;
using NumberAnalyser.Application.Requests;

namespace NumberAnalyser.Application.RequestHandlers
{
    internal class ArithmeticMeanRequestHandler : IRequestHandler<ArithmeticMeanRequest, decimal>
    {
        private readonly IArithmeticMeanCalculator calculator;

        public ArithmeticMeanRequestHandler(IArithmeticMeanCalculator calculator)
        {
            this.calculator = calculator;
        }
        
        public Task<decimal> Handle(ArithmeticMeanRequest request, CancellationToken cancellationToken) => 
            Task.FromResult(calculator.CalculateArithmeticMean(request.Numbers));
    }
}