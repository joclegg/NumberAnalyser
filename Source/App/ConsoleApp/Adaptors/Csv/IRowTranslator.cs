using System.Collections.Generic;

namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal interface IRowTranslator
    {
        IReadOnlyList<decimal> Translate(string row);
    }
}