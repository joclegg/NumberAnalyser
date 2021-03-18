using MediatR;
using NumberAnalyser.ConsoleApp.Adaptors.Csv;

namespace NumberAnalyser.ConsoleApp.Unit.Tests.Adaptors.Csv
{
    internal class TestCsvBuilder<T> : CsvBuilder<T>
    {
        public TestCsvBuilder(
            ICsvFileReader csvFileReader, 
            ICsvFileWriter csvFileWriter, 
            IResultTranslator<T> translator, 
            IRowRequestBuilder<T> rowRequestBuilder, 
            IMediator mediator) : 
            base(csvFileReader, 
                csvFileWriter,
                translator,
                rowRequestBuilder, 
                mediator)
        {
        }
    }
}