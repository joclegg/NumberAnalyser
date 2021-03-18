using System.Collections.Generic;
using MediatR;

namespace NumberAnalyser.ConsoleApp.Adaptors.Csv
{
    internal class RangeFrequencyCsvBuilder : CsvBuilder<IDictionary<string, int>>
    {
        public RangeFrequencyCsvBuilder(
            ICsvFileReader csvFileReader,
            ICsvFileWriter csvFileWriter,
            IMediator mediator) : 
            base(
                csvFileReader,
                csvFileWriter,
                new DictionaryTranslator(),
                new RangeFrequenciesRequestBuilder(),
                mediator)
        { }
    }
}