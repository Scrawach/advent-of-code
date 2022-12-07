using FluentAssertions;
using NUnit.Framework;
using rock_paper_scissors_src;

namespace rock_paper_scissors_tests
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
            defaultRules.AvailableChoices().Should().Equal("Rock", "Paper", "Scissors");
        }

        [TestCase("Rock")]
        [TestCase("Paper")]
        [TestCase("Scissors")]
        public void WhenScoreSameChoices_ThenShouldReturnZeroPoints(string choice)
        {
            // arrange
            var defaultRules = new DefaultRules();

            // act
            var score = defaultRules.Score(choice, choice);

            // answer
            score.Should().Be(0);
        }

        [TestCase("Rock", "Scissors")]
        [TestCase("Paper", "Rock")]
        [TestCase("Scissors", "Paper")]
        public void WhenScoreStrong_AndWeakChoices_ThenShouldReturnPositiveOnePoints(string strong, string weak)
        {
            // arrange
            var defaultRules = new DefaultRules();

            // act
            var score = defaultRules.Score(strong, weak);

            // answer
            score.Should().Be(1);
        }

        [TestCase("Rock", "Paper")]
        [TestCase("Paper", "Scissors")]
        [TestCase("Scissors", "Rock")]
        public void WhenScoreWeak_AndStrongChoices_ThenShouldReturnNegativeOnePoints(string weak, string strong)
        {
            // arrange
            var defaultRules = new DefaultRules();

            // act
            var score = defaultRules.Score(weak, strong);

            // answer
            score.Should().Be(-1);
        }
    }
}