using FluentAssertions;
using NUnit.Framework;
using rock_paper_scissors_src.GameRules.Abstract;
using rock_paper_scissors_src.Rounds;

namespace rock_paper_scissors_tests.GameRules
{
    public class FirstMoreThanSecondTest
    {
        [Test]
        public void WhenScoreFirstAndSecond_ThenShouldReturnOnePoint()
        {
            // arrange
            var rule = new FirstMoreThanSecond("a", "b");

            // act
            var score = rule.Score(new Round("a", "b"));

            // answer
            score.Should().Be(1);
        }

        [Test]
        public void WhenScoreSecondAndFirst_ThenShouldReturnNegativeOnePoint()
        {
            // arrange
            var rule = new FirstMoreThanSecond("a", "b");

            // act
            var score = rule.Score(new Round("b", "a"));

            // answer
            score.Should().Be(-1);
        }

        [TestCase("a")]
        [TestCase("b")]
        public void WhenScoreSameChoices_ThenShouldReturnZeroPoint(string choice)
        {
            // arrange
            var rule = new FirstMoreThanSecond("a", "b");

            // act
            var score = rule.Score(new Round(choice, choice));

            // answer
            score.Should().Be(0);
        }

        [TestCase("a", "c")]
        [TestCase("c", "b")]
        [TestCase("c", "c")]
        public void WhenChoicesNotExist_ThenShouldReturnZeroPoint(string first, string second)
        {
            // arrange
            var rule = new FirstMoreThanSecond("a", "b");

            // act
            var score = rule.Score(new Round(first, second));

            // answer
            score.Should().Be(0);
        }
    }
}