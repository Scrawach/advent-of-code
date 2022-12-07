using FluentAssertions;
using NUnit.Framework;
using rock_paper_scissors_src.GameRules;
using rock_paper_scissors_src.Rounds;

namespace rock_paper_scissors_tests.GameRules
{
    public class DefaultRulesTests
    {
        [Test]
        public void WhenGetAvailableChoices_ThenShouldReturn_RockAndPaperAndScissors()
        {
            // arrange
            var defaultRules = new DefaultRules();

            // act

            // answer
            defaultRules.AvailableChoices().Should().Equal(DefaultRules.Rock, DefaultRules.Paper, DefaultRules.Scissors);
        }

        [TestCase(DefaultRules.Rock)]
        [TestCase(DefaultRules.Paper)]
        [TestCase(DefaultRules.Scissors)]
        public void WhenScoreSameChoices_ThenShouldReturnZeroPoints(string choice)
        {
            // arrange
            var defaultRules = new DefaultRules();

            // act
            var score = defaultRules.Score(new Round(choice, choice));

            // answer
            score.Should().Be(0);
        }

        [TestCase(DefaultRules.Rock, DefaultRules.Scissors)]
        [TestCase(DefaultRules.Paper, DefaultRules.Rock)]
        [TestCase(DefaultRules.Scissors, DefaultRules.Paper)]
        public void WhenScoreStrong_AndWeakChoices_ThenShouldReturnPositiveOnePoints(string strong, string weak)
        {
            // arrange
            var defaultRules = new DefaultRules();

            // act
            var score = defaultRules.Score(new Round(strong, weak));

            // answer
            score.Should().Be(1);
        }

        [TestCase(DefaultRules.Rock, DefaultRules.Paper)]
        [TestCase(DefaultRules.Paper, DefaultRules.Scissors)]
        [TestCase(DefaultRules.Scissors, DefaultRules.Rock)]
        public void WhenScoreWeak_AndStrongChoices_ThenShouldReturnNegativeOnePoints(string weak, string strong)
        {
            // arrange
            var defaultRules = new DefaultRules();

            // act
            var score = defaultRules.Score(new Round(weak, strong));

            // answer
            score.Should().Be(-1);
        }
    }
}