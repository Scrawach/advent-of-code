using beacon_exclusion_zone_src.Data;
using beacon_exclusion_zone_src.Factory;
using FluentAssertions;
using NUnit.Framework;

namespace beacon_exclusion_zone_tests
{
    public class SolvesTests
    {
        [TestCase("example.txt", 10, 26)]
        public void WhenReadFile_ThenShouldReturn_HowManyPositions_WithoutBeacon(string fileName, int row, int expected)
        {
            // arrange
            var factory = new SolvesFactory(fileName);
            var positions = factory.PositionsWithoutBeacon(row);

            // act
            var totalCount = positions.TotalCount();

            // answer
            totalCount.Should().Be(expected);
        }
        
        [TestCase("example.txt", 0, 20, 56000011)]
        [Test]
        public void WhenReadFile_ThenShouldReturn_TuningFrequency_WhereExistHiddenBeacon(string fileName, int min, int max, int expected)
        {
            // arrange
            var factory = new SolvesFactory(fileName);
            var positions = factory.PositionsWithHiddenBeacon(new Vector2(min, min), new Vector2(max, max));

            // act
            var frequency = positions.TuningFrequency();

            // answer
            frequency.Should().Be(expected);
        }
    }
}