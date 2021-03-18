using MediatR;

namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal class StandardDeviationCsvBuilder : CsvBuilder<decimal>
    {
        public StandardDeviationCsvBuilder(
            ICsvFileReader csvFileReader,
            ICsvFileWriter csvFileWriter,
            IMediator mediator): 
            base(
                csvFileReader, 
                csvFileWriter, 
                new DecimalTranslator(),
                new StandardDeviationRequestBuilder(),
                mediator)
        {  }
    }
}