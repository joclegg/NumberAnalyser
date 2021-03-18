namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal interface IResultTranslator<in T>
    {
        string Translate(T result);
    }
}