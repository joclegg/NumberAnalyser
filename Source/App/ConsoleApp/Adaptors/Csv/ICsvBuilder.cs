using System.Threading;
using System.Threading.Tasks;

namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal interface ICsvBuilder
    {
        Task BuildCsv(CancellationToken cancellationToken);
    }
}