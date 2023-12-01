using FluentAssertions;
using NUnit.Framework;
using regolith_reservoir_src.Data;
using regolith_reservoir_src.Factory;

namespace regolith_reservoir_tests
{
    public class SecondSolveTests
    {
        [TestCase("example.txt", 93)]
        public void WhenSetup_FromExampleFile_ThenShouldReturnExpectedCountOfRestSand(string fileName, int expected)
        {
            // arrange
            var pouringPoint = new Vector2(500, 0);
            var factory = new SolvesFactory(fileName);
            var solve = factory.SecondSolve(pouringPoint);

            // act
            var count = solve.CountOfRestSands();

            // answer
            count.Should().Be(expected);
        }
    }
}