using System.Collections.Generic;
using System.Threading;

namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal interface ICsvFileReader
    {
        IAsyncEnumerable<IReadOnlyList<decimal>> ReadRowsAsync(CancellationToken cancellationToken);
    }
}