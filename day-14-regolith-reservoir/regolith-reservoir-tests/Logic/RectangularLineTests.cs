using System.Collections;
using FluentAssertions;
using NUnit.Framework;
using regolith_reservoir_src.Data;
using regolith_reservoir_src.Logic;

namespace regolith_reservoir_tests.Logic
{
    public class RectangularLineTests
    {
        [TestCaseSource(nameof(CrossesDataSource))]
        public void WhenPointInsideLine_ThenShouldReturnTrue(Vector2[] points, Vector2 point, bool expected)
        {
            // arrange
            var line = new RectangularLine(points);

            // act
            var isCross = line.IsCross(point);

            // answer
            isCross.Should().Be(expected);
        }

        private static IEnumerable CrossesDataSource()
        {
            yield return new object[]
            {
                new[] {new Vector2(0, 0), new Vector2(0, 10), new Vector2(5, 10)},
                new Vector2(0, 5),
                true
            };
            yield return new object[]
            {
                new[] {new Vector2(0, 0), new Vector2(10, 0), new Vector2(10, 5)},
                new Vector2(5, 0),
                true
            };
            yield return new object[]
            {
                new[] {new Vector2(0, 0), new Vector2(0, 0)},
                new Vector2(0, 0),
                true
            };
            yield return new object[]
            {
                new[] {new Vector2(0, 0), new Vector2(0, 0)},
                new Vector2(1, 1),
                false
            };
            yield return new object[]
            {
                new[] {new Vector2(0, 0), new Vector2(10, 0), new Vector2(10, 5)},
                new Vector2(7, 5),
                false
            };
            yield return new object[]
            {
                new[] {new Vector2(0, 0), new Vector2(10, 0), new Vector2(10, 5)},
                new Vector2(10, 3),
                true
            };
        }
    }
}