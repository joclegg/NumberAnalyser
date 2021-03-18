namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal class CsvConfiguration
    {
        public string CsvInputFilePath { get; set; } = null!;
        public string CsvOutputFilePath { get; set; } = null!;
        public CsvOption CsvOption { get; set; }
    }
}