using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal interface ICsvFileWriter
    {
        Task WriteCsv<T>(IAsyncEnumerable<T> results, Func<T, string> translationDelegate,
            CancellationToken cancellationToken);
    }
}