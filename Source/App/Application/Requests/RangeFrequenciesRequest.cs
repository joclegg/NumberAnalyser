using System.Collections.Generic;
using MediatR;

namespace NumberAnalyser.Application.Requests
{
    public record RangeFrequenciesRequest(IReadOnlyList<decimal> Numbers) : IRequest<IDictionary<string, int>>;
}