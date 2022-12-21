using FluentAssertions;
using monkey_in_the_middle_src.Factory;
using NUnit.Framework;

namespace monkey_in_the_middle_tests
{
    public class SolvesTests
    {
        [TestCase("example.txt", 10605)]
        public void WhenSimulateFirstTask_With20Rounds_ThenShouldReturnExpectedResult(string fileName, int expected)
        {
            // arrange
            var factory = new MonkeyBusinessFactory(fileName);
            var task = factory.FirstTask();

            // act
            var result = task.Simulate(20);

            // answer
            result.Should().Be(expected);
        }

        [TestCase("example.txt", 2713310158)]
        public void WhenSimulateSecondTask_With10000Rounds_AndSpecialWorryTarget_ThenShouldReturnExpectedResult(string fileName, long expected)
        {
            // arrange
            var factory = new MonkeyBusinessFactory(fileName);
            var task = factory.SecondTask();

            // act
            var result = task.Simulate(10000);

            // answer
            result.Should().Be(expected);
        }
    }
}