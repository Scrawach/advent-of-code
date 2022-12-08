using System.Collections;
using clamp_cleanup_src;
using FluentAssertions;
using NUnit.Framework;

namespace clamp_cleanup_tests
{
    public class RangeTests
    {
        [TestCaseSource(typeof(RangeDataSource))]
        public void WhenOneRangeContainAnother_ThenShouldReturnTrue(Range range, Range anotherRange, bool expected)
        {
            // arrange

            // act
            bool result = range.Contains(anotherRange);

            // answer
            result.Should().Be(expected);
        }
        
        private class RangeDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {new Range(0, 1), new Range(2, 3), false};
            }
        }
    }
}