using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NumberAnalyser.Application.Calculators;
using NumberAnalyser.Application.Requests;

namespace NumberAnalyser.Application.RequestHandlers
{
    internal class RangeFrequenciesRequestHandler : IRequestHandler<RangeFrequenciesRequest, IDictionary<string, int>>
    {
        private readonly IRangeFrequenciesCalculator calculator;

        public RangeFrequenciesRequestHandler(IRangeFrequenciesCalculator calculator)
        {
            this.calculator = calculator;
        }
        
        public Task<IDictionary<string, int>> Handle(RangeFrequenciesRequest request, CancellationToken cancellationToken) => 
            Task.FromResult(calculator.CalculateRangeFrequencies(request.Numbers));
    }
}