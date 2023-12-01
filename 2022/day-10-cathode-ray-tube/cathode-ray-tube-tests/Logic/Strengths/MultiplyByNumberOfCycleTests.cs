using cathode_ray_tube_src.Logic.Strengths;
using FluentAssertions;
using NUnit.Framework;

namespace cathode_ray_tube_tests.Logic.Strengths
{
    public class MultiplyByNumberOfCycleTests
    {
        [TestCase(10, 1, 10)]
        [TestCase(25, 1, 25)]
        [TestCase(42, 1, 42)]
        [TestCase(42, 2, 84)]
        [TestCase(42, 3, 126)]
        [TestCase(42, 4, 168)]
        public void WhenCalculateWithCorrectNumberOfCycle_ThenShouldReturnMultiplyValue(int numberOfCycle, int value, int expected)
        {
            // arrange
            var multiply = new MultiplyByNumberOfCycle(numberOfCycle);

            // act
            var score = multiply.Calculate(numberOfCycle, value);

            // answer
            score.Should().Be(expected);
        }
    }
}