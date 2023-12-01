using FluentAssertions;
using hill_climbing_algorithm_src.Factory;
using NUnit.Framework;

namespace hill_climbing_algorithm_tests.Solves
{
    public class SearchPathTests
    {
        [TestCase("example.txt", 31)]
        public void WhenCalculateTotalSteps_FromExampleFile_ThenShouldReturnExpectedValue(string fileName, int expected)
        {
            // arrange
            var factory = new PathFactory(fileName);
            var path = factory.SearchPath();

            // act
            var steps = path.TotalSteps();

            // answer
            steps.Should().Be(expected);
        }
    }
}