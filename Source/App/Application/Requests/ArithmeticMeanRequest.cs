using System.Collections.Generic;
using MediatR;

namespace NumberAnalyser.Application.Requests
{
    public record ArithmeticMeanRequest(IReadOnlyList<decimal> Numbers) : IRequest<decimal>;
}