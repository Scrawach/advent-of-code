using System.Collections;
using FluentAssertions;
using NUnit.Framework;
using tuning_trouble_src.Storages;

namespace tuning_trouble_tests.Storages
{
    public class ConstantQueueTests
    {
        [TestCaseSource(typeof(ConstantQueueDataSource))]
        public void WhenEnqueueUniqueSymbols_ThenShouldReturnUniqueFlag(string symbols, int capacity, bool expected)
        {
            // arrange
            var queue = new ConstantQueue<char>(capacity);

            // act
            foreach (var symbol in symbols) 
                queue.Enqueue(symbol);
            var isUnique = queue.IsUnique();

            // answer
            isUnique.Should().Be(expected);
        }

        private class ConstantQueueDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {"abcd", 4, true};
                yield return new object[] {"abca", 4, false};
                yield return new object[] {"abaa", 4, false};
                yield return new object[] {"abqq", 4, false};
                yield return new object[] {"abcd", 14, false};
                yield return new object[] {"qnmp", 4, true};
                yield return new object[] {"qnpmabcd", 8, true};
                yield return new object[] {"aaaa", 4, false};
                yield return new object[] {"aaaabcd", 4, true};
            }
        }
    }
}