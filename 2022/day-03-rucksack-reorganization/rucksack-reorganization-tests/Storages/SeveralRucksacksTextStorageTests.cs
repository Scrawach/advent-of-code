using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using rucksack_reorganization_src.Storages;
using rucksack_reorganization_src.Storages.Abstract;
using rucksack_reorganization_tests.Logic;

namespace rucksack_reorganization_tests.Storages
{
    public class SeveralRucksacksTextStorageTests
    {
        [TestCaseSource(typeof(RucksackTests.SeveralRucksacksDataSource))]
        public void WhenReadLines_ThenShouldReturnRucksacks_WithCorrectRepeatedSymbols(string[] content, char expected)
        {
            // arrange
            var textMock = new Mock<IText>();
            textMock.Setup(mock => mock.Lines()).Returns(content);
            var storage = new SeveralRucksacksTextStorage(textMock.Object);

            // act
            var firstRepeatedSymbol = storage.All().First().RepeatedSymbol();

            // answer
            firstRepeatedSymbol.Should().Be(expected);
        }
    }
}