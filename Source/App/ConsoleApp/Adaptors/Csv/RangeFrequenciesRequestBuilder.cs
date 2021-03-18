using System.Collections.Generic;
using MediatR;
using NumberAnalyser.Application.Requests;

namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal class RangeFrequenciesRequestBuilder : IRowRequestBuilder<IDictionary<string, int>>
    {
        public IRequest<IDictionary<string, int>> CreateRequest(IReadOnlyList<decimal> row) =>
            new RangeFrequenciesRequest(row);
    }
}