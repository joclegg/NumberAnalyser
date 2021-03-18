using System.Collections.Generic;
using MediatR;

namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal interface IRowRequestBuilder<out T>
    {
        IRequest<T> CreateRequest(IReadOnlyList<decimal> row);
    }
}