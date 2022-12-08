using System.Collections;
using FluentAssertions;
using NUnit.Framework;
using rucksack_reorganization_src;

namespace rucksack_reorganization_tests
{
    public class PriorityTests
    {
        [TestCaseSource(typeof(PriorityDataSource))]
        public void WhenConvertSymbol_ThenShouldReturnItPriority(char input, int expected)
        {
            // act
            var code = Priority.Convert(input);

            // answer
            code.Should().Be(expected);
        }
        
        private class PriorityDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                var priority = 1;
                
                for (var i = 'a'; i <= 'z'; i++, priority++)
                    yield return new object[] {i, priority};

                for (var i = 'A'; i <= 'Z'; i++, priority++)
                    yield return new object[] {i, priority};
            }
        }
    }
}