namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal class DecimalTranslator : IResultTranslator<decimal>
    {
        public string Translate(decimal result) => $"{result}";
    }
}