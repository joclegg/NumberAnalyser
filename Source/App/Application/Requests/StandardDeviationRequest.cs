using System.Collections.Generic;
using MediatR;

namespace NumberAnalyser.Application.Requests
{
    public record StandardDeviationRequest(IReadOnlyList<decimal> Numbers) : IRequest<decimal>;
}