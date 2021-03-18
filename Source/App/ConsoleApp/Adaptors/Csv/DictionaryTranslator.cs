using System.Collections.Generic;
using System.Text.Json;

namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal class DictionaryTranslator : IResultTranslator<IDictionary<string, int>>
    {
        public string Translate(IDictionary<string, int> result) => JsonSerializer.Serialize(result);
    }
}