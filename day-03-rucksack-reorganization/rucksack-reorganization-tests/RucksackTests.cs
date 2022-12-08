using System.Collections;
using FluentAssertions;
using NUnit.Framework;
using rucksack_reorganization_src;

namespace rucksack_reorganization_tests
{
    public class RucksackTests
    {
        [TestCaseSource(typeof(RucksackDataSource))]
        public void WhenGetRepeatedSymbol_ThenShouldReturnIt_FromTwoContentParts(string content, char expected)
        {
            // arrange
            var rucksack = new Rucksack(content);

            // act
            var symbol = rucksack.RepeatedSymbol();

            // answer
            symbol.Should().Be(expected);
        }
        
        private class RucksackDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {"abca", 'a'};
                yield return new object[] {"JrwpWtwJgWrhcsFMMfFFhFp", 'p'};
                yield return new object[] {"jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L'};
                yield return new object[] {"PmmdzqPrVvPwwTWBwg", 'P'};
                yield return new object[] {"wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 'v'};
                yield return new object[] {"ttgJtRGJQctTZtZT", 't'};
                yield return new object[] {"CrZsJsPPZsGzwwsLwLmpwMDw", 's'};
            }
        }
    }
}