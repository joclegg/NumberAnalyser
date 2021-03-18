using System.Collections.Generic;
using MediatR;
using NumberAnalyser.Application.Requests;

namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal class ArithmeticMeanRequestBuilder : IRowRequestBuilder<decimal>
    {
        public IRequest<decimal> CreateRequest(IReadOnlyList<decimal> row) => new ArithmeticMeanRequest(row);
    }
}