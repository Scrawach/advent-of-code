using System;
using System.Collections;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using rock_paper_scissors_src.GameRules.Abstract;
using rock_paper_scissors_src.Rounds;
using rock_paper_scissors_src.Rounds.Convert;

namespace rock_paper_scissors_tests.Rounds.Convert
{
    public class AsRoundResultConverterTests
    {
        [TestCaseSource(typeof(RoundResultDataSource))]
        public void WhenArgsContainsXYZ_WhereCodedRoundResult_ThenShouldReturnThisResult(string opponent, string resultCode, Round expected)
        {
            // arrange
            var choicesMock = new Mock<IChoicesStorage>();
            var rulesMock = new Mock<IGameRule>();

            choicesMock
                .Setup(mock => mock.AvailableChoices())
                .Returns(new[] {"a", "b", "c"});

            rulesMock
                .Setup(mock => mock.Score(It.IsAny<Round>()))
                .Returns<Round>(SimpleScore);

            var convert = new AsRoundResultConverter(choicesMock.Object, rulesMock.Object);

            // act
            var result = convert.Convert(opponent, resultCode);

            // answer
            result.Should().Be(expected);
        }

        private static int SimpleScore(Round round) =>
            round.Player switch
            {
                "a" => 0,
                "b" => 1,
                "c" => -1,
                _ => throw new Exception()
            };

        private class RoundResultDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {"a", "x", new Round("c", "a")};
                yield return new object[] {"b", "y", new Round("a", "b")};
                yield return new object[] {"c", "z", new Round("b", "c")};
            }
        }
    }
}