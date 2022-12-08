using System.Collections;
using System.Linq;
using clamp_cleanup_src.Logic;
using clamp_cleanup_src.Storages;
using clamp_cleanup_src.Storages.Abstract;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Range = clamp_cleanup_src.Logic.Range;

namespace clamp_cleanup_tests.Storages
{
    public class PairRangeTextStorageTests
    {
        [TestCaseSource(typeof(SingleRangeStorageDataSource))]
        public void WhenReadLine_ThenShouldReturnCorrectRange(string line, PairRange expected)
        {
            // arrange
            var textMock = new Mock<IText>();
            textMock.Setup(mock => mock.Lines()).Returns(new[] {line});
            
            var storage = new PairRangeTextStorage(textMock.Object);

            // act
            var range = storage.All().First();

            // answer
            range.Should().Be(expected);
        }
    }

    public class SingleRangeStorageDataSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] {"2-4,6-8", new PairRange(new Range(2, 4), new Range(6, 8))};
            yield return new object[] {"2-3,4-5", new PairRange(new Range(2, 3), new Range(4, 5))};
            yield return new object[] {"5-7,7-9", new PairRange(new Range(5, 7), new Range(7, 9))};
            yield return new object[] {"2-8,3-7", new PairRange(new Range(2, 8), new Range(3, 7))};
            yield return new object[] {"6-6,4-6", new PairRange(new Range(6, 6), new Range(4, 6))};
            yield return new object[] {"2-6,4-8", new PairRange(new Range(2, 6), new Range(4, 8))};
        }
    }
}