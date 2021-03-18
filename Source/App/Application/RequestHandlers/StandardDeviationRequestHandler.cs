using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NumberAnalyser.Application.Calculators;
using NumberAnalyser.Application.Requests;

namespace NumberAnalyser.Application.RequestHandlers
{
    internal class StandardDeviationRequestHandler : IRequestHandler<StandardDeviationRequest, decimal>
    {
        private readonly IStandardDeviationCalculator calculator;

        public StandardDeviationRequestHandler(IStandardDeviationCalculator calculator)
        {
            this.calculator = calculator;
        }
        
        public Task<decimal> Handle(StandardDeviationRequest request, CancellationToken cancellationToken) =>
            Task.FromResult(calculator.CalculateStandardDeviation(request.Numbers));
    }
}