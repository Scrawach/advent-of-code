using FluentAssertions;
using NUnit.Framework;
using rock_paper_scissors_src.Factory;

namespace rock_paper_scissors_tests
{
    public class StrategyGuideTests
    {
        private const string TestFile = "example.txt";

        [TestCase(TestFile, 15)]
        public void WhenReadTestData_ThenShouldConvertXYZ_AsTargetChoice(string fileName, int expected)
        {
            // arrange
            var strategy = new StrategyFactory(fileName).ChoiceBased();

            // act
            var score = strategy.TotalScore();

            // answer
            score.Should().Be(expected);
        }

        [TestCase(TestFile, 12)]
        public void WhenReadTestData_ThenShouldConvertXYZ_AsRoundResult(string fileName, int expected)
        {
            // arrange
            var strategy = new StrategyFactory(fileName).ResultBased();

            // act
            var score = strategy.TotalScore();

            // answer
            score.Should().Be(expected);
        }
    }
}