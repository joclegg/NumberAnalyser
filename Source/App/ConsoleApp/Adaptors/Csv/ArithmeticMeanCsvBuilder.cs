using MediatR;

namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal class ArithmeticMeanCsvBuilder : CsvBuilder<decimal>
    {
        public ArithmeticMeanCsvBuilder(
            ICsvFileReader csvFileReader,
            ICsvFileWriter csvFileWriter,
            IMediator mediator) : 
            base(
                csvFileReader, 
                csvFileWriter, 
                new DecimalTranslator(),
                new ArithmeticMeanRequestBuilder(),
                mediator)
        { }
    }
}