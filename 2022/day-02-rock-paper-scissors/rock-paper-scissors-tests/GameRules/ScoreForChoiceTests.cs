using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using rock_paper_scissors_src.GameRules;
using rock_paper_scissors_src.GameRules.Abstract;
using rock_paper_scissors_src.Rounds;

namespace rock_paper_scissors_tests.GameRules
{
    public class ScoreForChoiceTests
    {
        [TestCaseSource(typeof(ScoreForChoiceDataSource))]
        public void WhenScoreChoices_ThenShouldReturnConstantValueForChoice(string choice, string[] choices, int expected)
        {
            // arrange
            var choicesMock = new Mock<IChoicesStorage>();
            choicesMock.Setup(mock => mock.AvailableChoices()).Returns(choices);
            var scoreForChoice = new ScoreForChoice(choicesMock.Object);

            // act
            var score = scoreForChoice.Score(new Round(choice, choice));

            // answer
            score.Should().Be(expected);
        }

        private class ScoreForChoiceDataSource : IEnumerable
        {
            private static readonly List<string> Choices = new List<string> {"a", "b", "c", "d", "e"};

            public IEnumerator GetEnumerator() =>
                Choices
                    .Select(TestCase)
                    .GetEnumerator();

            private object[] TestCase(string key) =>
                new object[] {key, Choices.ToArray(), Choices.IndexOf(key) + 1};
        }
    }
}