using FluentAssertions;
using NUnit.Framework;
using rucksack_reorganization_src;

namespace rucksack_reorganization_tests
{
    public class RepeatedSymbolTests
    {
        [TestCase("abc", "bum", 'b')]
        public void WhenArgsContainsRepeatedSymbol_ThenShouldReturnIt(string first, string second, char expected)
        {
            // arrange
            var repeatedSymbol = new RepeatedSymbol();

            // act
            var symbol = repeatedSymbol.Find(first, second);

            // answer
            symbol.Should().Be(expected);
        }
    }
}