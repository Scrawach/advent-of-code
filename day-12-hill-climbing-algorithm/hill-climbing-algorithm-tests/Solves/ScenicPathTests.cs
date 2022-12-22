using FluentAssertions;
using hill_climbing_algorithm_src.Factory;
using NUnit.Framework;

namespace hill_climbing_algorithm_tests.Solves
{
    public class ScenicPathTests
    {
        [TestCase("example.txt", 29)]
        public void WhenCalculateTotalSteps_FromExampleFile_ThenShouldReturnExpectedValue(string fileName, int expected)
        {
            // arrange
            var factory = new PathFactory(fileName);
            var path = factory.ScenicPath();

            // act
            var steps = path.TotalSteps();

            // answer
            steps.Should().Be(expected);
        }
    }
}