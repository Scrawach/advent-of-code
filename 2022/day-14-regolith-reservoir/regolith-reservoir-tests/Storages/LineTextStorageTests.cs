using System.Collections;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using regolith_reservoir_src.Data;
using regolith_reservoir_src.Storages;
using regolith_reservoir_src.Storages.Abstract;

namespace regolith_reservoir_tests.Storages
{
    public class LineTextStorageTests
    {
        [TestCaseSource(nameof(StorageDataSource))]
        public void WhenReadOneLine_WithPointCoords_ThenShouldReturnLineWithThisCoords(string input, Vector2[] expected)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == new[] { input });
            var storage = new LineTextStorage(mockedText);

            // act
            var linePoints = storage.All().First().Points;

            // answer
            linePoints.Should().Equal(expected);
        }

        private static IEnumerable StorageDataSource()
        {
            yield return new object[]
            {
                "0,1 -> 0,2",
                new [] { new Vector2(0,1), new Vector2(0,2)}
            };
            yield return new object[]
            {
                "498,4 -> 498,6 -> 496,6",
                new [] { new Vector2(498,4), new Vector2(498,6), new Vector2(496,6)}
            };
            yield return new object[]
            {
                "503,4 -> 502,4 -> 502,9 -> 494,9",
                new [] { new Vector2(503,4), new Vector2(502, 4), new Vector2(502,9), new Vector2(494, 9)}
            };
        }
    }
}