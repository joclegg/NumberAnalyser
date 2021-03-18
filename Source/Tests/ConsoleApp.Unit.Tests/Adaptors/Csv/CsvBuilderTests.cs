using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using MediatR;
using NSubstitute;
using NumberAnalyser.ConsoleApp.Adaptors.Csv;
using NUnit.Framework;

namespace NumberAnalyser.ConsoleApp.Unit.Tests.Adaptors.Csv
{
    [TestFixture]
    public class CsvBuilderTests
    {
        private IFixture fixture = new Fixture(); 
        private ICsvBuilder csvBuilder = null!;
        private ICsvFileReader csvFileReader = null!;
        private ICsvFileWriter csvFileWriter = null!;
        private IResultTranslator<decimal> translator = null!;
        private IRowRequestBuilder<decimal> rowRequestBuilder = null!;
        private IMediator mediator = null!;

        [SetUp]
        public void SetUp()
        {
            csvFileReader = Substitute.For<ICsvFileReader>();
            csvFileWriter = Substitute.For<ICsvFileWriter>();
            translator = Substitute.For<IResultTranslator<decimal>>();
            rowRequestBuilder = Substitute.For<IRowRequestBuilder<decimal>>();
            mediator = Substitute.For<IMediator>();
            csvBuilder = new TestCsvBuilder<decimal>(
                csvFileReader,
                csvFileWriter,
                translator,
                rowRequestBuilder,
                mediator);
        }

        [Test]
        public async Task Given_HappyPath_When_BuildCsvCalled_Then_FollowsHappyPath()
        {
            // Arrange
            var row = fixture.CreateMany<decimal>().ToArray();
            var rows = new[] {row}.ToAsyncEnumerable();

            csvFileReader
                .ReadRowsAsync(Arg.Any<CancellationToken>())
                .Returns(rows);

            var request = Substitute.For<IRequest<decimal>>();

            rowRequestBuilder
                .CreateRequest(row)
                .Returns(request);

            var result = fixture.Create<decimal>();

            mediator
                .Send(request)
                .Returns(result);

            // Act    
            await csvBuilder.BuildCsv(CancellationToken.None);

            // Assert    
            await csvFileWriter.Received().WriteCsv(
                Arg.Any<IAsyncEnumerable<decimal>>(),
                translator.Translate,
                Arg.Any<CancellationToken>());
        }
    }
}