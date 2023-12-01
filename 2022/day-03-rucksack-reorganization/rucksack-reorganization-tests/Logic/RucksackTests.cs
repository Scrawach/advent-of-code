using System.Collections;
using FluentAssertions;
using NUnit.Framework;
using rucksack_reorganization_src.Logic;

namespace rucksack_reorganization_tests.Logic
{
    public class RucksackTests
    {
        [TestCaseSource(typeof(RucksackDataSource))]
        public void WhenGetRepeatedSymbol_ThenShouldReturnIt_FromTwoContentParts(string content, char expected)
        {
            // arrange
            var length = content.Length / 2;
            var rucksack = new Rucksack(content[length..], content[..length]);

            // act
            var symbol = rucksack.RepeatedSymbol();

            // answer
            symbol.Should().Be(expected);
        }
        
        [TestCaseSource(typeof(SeveralRucksacksDataSource))]
        public void WhenGetRepeatedSymbol_ThenShouldReturnIt_FromAllContentsInRucksack(string[] contents, char expected)
        {
            // arrange
            var severalRucksacks = new Rucksack(contents);

            // act
            var repeatedSymbol = severalRucksacks.RepeatedSymbol();

            // answer
            repeatedSymbol.Should().Be(expected);
        }
        
        public class SeveralRucksacksDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return FirstTestCase();
                yield return SecondTestCase();
            }

            private object[] FirstTestCase() =>
                new object[]
                {
                    new[]
                    {
                        "vJrwpWtwJgWrhcsFMMfFFhFp",
                        "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                        "PmmdzqPrVvPwwTWBwg"
                    },
                    'r'
                };
            
            private object[] SecondTestCase() =>
                new object[]
                {
                    new[]
                    {
                        "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                        "ttgJtRGJQctTZtZT",
                        "CrZsJsPPZsGzwwsLwLmpwMDw"
                    },
                    'Z'
                };
        }
        
        public class RucksackDataSource : IEnumerable
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