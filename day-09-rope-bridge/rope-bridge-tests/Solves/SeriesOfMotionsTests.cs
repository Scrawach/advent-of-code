using FluentAssertions;
using NUnit.Framework;
using rope_bridge_src.Factory;

namespace rope_bridge_tests.Solves
{
    public class SeriesOfMotionsTests
    {
        [TestCase("example.txt", 13)]
        public void WhenReadCommands_ThenShouldSimulateIt_AndReturnCountOfUniqueTailPositions(string fileName, int expected)
        {
            // arrange
            var factory = new SolvesFactory(fileName);
            var series = factory.SeriesOfMotions();

            // act
            var count = series.Simulate();

            // answer
            count.Should().Be(expected);
        }

        [TestCase("example-with-9-length-rope.txt", 9, 36)]
        public void WhenReadCommands_ThenShouldSimulateIt_AndReturnCountOfUniqueTailPositions_WithVariousRopeLength(string fileName, int ropeLength, int expected)
        {
            // arrange
            var factory = new SolvesFactory(fileName);
            var series = factory.SeriesOfMotions();

            // act
            var count = series.Simulate(ropeLength);

            // answer
            count.Should().Be(expected);
        }
    }
}