using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using regolith_reservoir_src.Data;
using regolith_reservoir_src.Logic;
using regolith_reservoir_src.Logic.Abstract;

namespace regolith_reservoir_tests.Logic
{
    public class CaveTests
    {
        [Test]
        public void WhenIsOccupied_AndNoOneCrossLines_ThenShouldReturnFalse()
        {
            // arrange
            var mockedLines = new List<ILine>();
            for (var i = 0; i < 5; i++)
                mockedLines.Add(Mock.Of<ILine>(mock => !mock.IsCross(It.IsAny<Vector2>())));
            
            var cave = new Cave(mockedLines.ToArray());

            // act
            var isOccupied = cave.IsOccupied(new Vector2(0, 0));

            // answer
            isOccupied.Should().Be(false);
        }
        
        [TestCase]
        public void WhenIsOccupied_AndAtLeastCrossOneLine_ThenShouldReturnTrue()
        {
            // arrange
            var mockedLines = new List<ILine>();
            for (var i = 0; i < 5; i++)
                mockedLines.Add(Mock.Of<ILine>(mock => !mock.IsCross(It.IsAny<Vector2>())));
            mockedLines.Add(Mock.Of<ILine>(mock => mock.IsCross(It.IsAny<Vector2>())));
            
            var cave = new Cave(mockedLines.ToArray());

            // act
            var isOccupied = cave.IsOccupied(new Vector2(0, 0));

            // answer
            isOccupied.Should().Be(true);
        }

        [TestCaseSource(nameof(HeightDataSource))]
        public void WhenHeight_ThenShouldReturn_MostHighestPoint_FromLines(ILine[] lines, int expected)
        {
            // arrange
            var cave = new Cave(lines);

            // act
            var height = cave.Height;

            // answer
            height.Should().Be(expected);
        }

        private static IEnumerable HeightDataSource()
        {
            yield return new object[]
            {
                new ILine[]
                {
                    new RectangularLine(new[] { new Vector2(0, 0), new Vector2(0, 2) }),
                    new RectangularLine(new[] { new Vector2(0, 0), new Vector2(0, 10) })
                },
                10
            };
        }
        
    }
}