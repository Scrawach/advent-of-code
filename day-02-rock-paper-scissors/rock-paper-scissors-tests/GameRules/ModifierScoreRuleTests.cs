using System.Collections;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using rock_paper_scissors_src.GameRules;
using rock_paper_scissors_src.GameRules.Abstract;
using rock_paper_scissors_src.Rounds;

namespace rock_paper_scissors_tests.GameRules
{
    public class ModifierScoreRuleTests
    {
        [TestCaseSource(typeof(ModifierScoreDataSource))]
        public void WhenScoreSomething_ThenShouldAppliesModifierFunction(int score, int expected)
        {
            // arrange
            var mockRule = new Mock<IGameRule>();
            mockRule.Setup(mock => mock.Score(It.IsAny<Round>())).Returns<Round>(round => score);
            var modifierRule = new ModifierScoreRule(mockRule.Object, ModifierFunction);

            // act
            var result = modifierRule.Score(new Round());

            // answer
            result.Should().Be(expected);
        }

        private static int ModifierFunction(int value) =>
            value * 2 - 100 / 12;

        private class ModifierScoreDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {0, ModifierFunction(0)};
                yield return new object[] {10, ModifierFunction(10)};
                yield return new object[] {-10, ModifierFunction(-10)};
                yield return new object[] {2500, ModifierFunction(2500)};
                yield return new object[] {int.MinValue, ModifierFunction(int.MinValue)};
                yield return new object[] {int.MaxValue, ModifierFunction(int.MaxValue)};
            }
        }
    }
}