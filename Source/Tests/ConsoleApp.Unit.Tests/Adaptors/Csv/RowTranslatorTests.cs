using System.Linq;
using AutoFixture;
using Microsoft.Extensions.Logging.Abstractions;
using NumberAnalyser.ConsoleApp.Adaptors.Csv;
using NUnit.Framework;
using Shouldly;

namespace NumberAnalyser.ConsoleApp.Unit.Tests.Adaptors.Csv
{
    [TestFixture]
    public class RowTranslatorTests
    {
        private readonly IFixture fixture = new Fixture();
        private IRowTranslator translator;

        [SetUp]
        public void SetUp()
        {
            translator = new RowTranslator(NullLogger<RowTranslator>.Instance);
        }

        [Test]
        public void Given_ACsvOfDecimals_When_TranslateCalled_Then_TranslatesToList()
        {
            // Arrange
            var expected = fixture.CreateMany<decimal>().ToArray();
            var row = string.Join(',', expected);

            // Act    
            var actual = translator.Translate(row);
            
            // Assert
            actual.Count.ShouldBe(expected.Length);
            for (var i = 0; i < expected.Length; i++)
            {
                actual[i].ShouldBe(expected[i]);
            }
        }

        [Test]
        public void Given_ABadDecimal_WhenTranslateCalled_Then_IgnoresBadOne()
        {
            // Arrange
            var expected = new [] {0.1m, 0.2m};
            var row = $"{expected[0]},a,{expected[1]}";

            // Act    
            var actual = translator.Translate(row);
            
            // Assert
            actual.Count.ShouldBe(expected.Length);
            for (var i = 0; i < expected.Length; i++)
            {
                actual[i].ShouldBe(expected[i]);
            }
        }

        [Test]
        public void Given_EmptyRow_WhenTranslateCalled_Then_ReturnsEmpty()
        {
            // Arrange
            var row = string.Empty;

            // Act    
            var actual = translator.Translate(row);
            
            // Assert
            actual.ShouldBeEmpty();
        }
    }
}