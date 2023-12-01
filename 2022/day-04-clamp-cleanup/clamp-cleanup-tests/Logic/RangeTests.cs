using System;
using System.Collections;
using FluentAssertions;
using NUnit.Framework;
using Range = clamp_cleanup_src.Logic.Range;

namespace clamp_cleanup_tests.Logic
{
    public class RangeTests
    {
        [TestCaseSource(typeof(ContainsRangeDataSource))]
        public void WhenOneRangeContainAnother_ThenShouldReturnTrue(Range range, Range anotherRange, bool expected)
        {
            // arrange

            // act
            var result = range.Contains(anotherRange);

            // answer
            result.Should().Be(expected);
        }

        [TestCaseSource(typeof(OverlapRangeDataSource))]
        public void WhenOneRangeOverlapAnother_ThenShouldReturnTrue(Range range, Range anotherRange, bool expected)
        {
            // arrange

            // act
            var result = range.IsOverlap(anotherRange);

            // answer
            result.Should().Be(expected);
        }

        [TestCase(10, 2)]
        [TestCase(5, 0)]
        public void WhenCreateInvalidRange_ThenShouldThrowArgumentException(int start, int end)
        {
            // arrange

            // act
            Action act = () =>
            {
                var range = new Range(start, end);
            };

            // answer
            act.Should().Throw<ArgumentException>();
        }

        private class ContainsRangeDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {new Range(0, 1), new Range(2, 3), false};
                yield return new object[] {new Range(0, 4), new Range(3, 6), false};
                yield return new object[] {new Range(0, 10), new Range(2, 5), true};
                yield return new object[] {new Range(5, 6), new Range(5, 8), false};
                yield return new object[] {new Range(10, 20), new Range(10, 20), true};
            }
        }
        
        private class OverlapRangeDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {new Range(0, 1), new Range(2, 3), false};
                yield return new object[] {new Range(0, 4), new Range(3, 6), true};
                yield return new object[] {new Range(0, 10), new Range(2, 5), true};
                yield return new object[] {new Range(5, 6), new Range(5, 8), true};
                yield return new object[] {new Range(10, 20), new Range(10, 20), true};
            }
        }
    }
}