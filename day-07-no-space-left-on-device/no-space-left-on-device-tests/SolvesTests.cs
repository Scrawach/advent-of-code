using FluentAssertions;
using no_space_left_on_device_src.Solves;
using NUnit.Framework;

namespace no_space_left_on_device_tests
{
    public class SolvesTests
    {
        [TestCase("example.txt", 100000, 95437)]
        public void WhenSolveSumOfTotalSize_ThenShouldReturnExpectedExampleValue(string fileName, int maxDirectorySize, int expectedSize)
        {
            // arrange
            var factory = new SolveFactory(fileName);

            // act
            var result = factory.SumOfTotalSize(maxDirectorySize).Solve();

            // answer
            result.Should().Be(expectedSize);
        }

        [TestCase("example.txt", 70000000, 30000000, 24933642)]
        public void WhenSolveSmallestDirectory_ThenShouldReturnExpectedExampleValue(string fileName, int totalDiskSpace, int targetUnusedSpace, int expectedSize)
        {
            // arrange
            var factory = new SolveFactory(fileName);

            // act
            var result = factory.SmallestDirectory(totalDiskSpace, targetUnusedSpace).Solve();

            // answer
            result.Should().Be(expectedSize);
        }
    }
}