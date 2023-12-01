using System.Collections;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using rock_paper_scissors_src.Rounds;
using rock_paper_scissors_src.Rounds.Abstract;
using rock_paper_scissors_src.Rounds.Convert;

namespace rock_paper_scissors_tests.Rounds
{
    public class RoundsTextStorageTests
    {
        [TestCaseSource(typeof(RoundsSourceData))]
        public void WhenReadLine_ThenShouldConvertItToRound(string input, Round[] expected)
        {
            // arrange
            var text = new Mock<IText>();
            text.Setup(mock => mock.Lines()).Returns(input.Split('\n'));

            var converter = new Mock<IConverter>();
            converter
                .Setup(mock => mock.Convert(It.IsAny<string>(), It.IsAny<string>()))
                .Returns<string, string>((x, y) => new Round(x, y));

            var choices = new RoundsTextStorage(converter.Object, text.Object);

            // act
            var result = choices.Rounds().ToArray();

            // answer
            result.Should().Equal(expected);
        }

        private class RoundsSourceData : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return RoundTestCase("a", "z");
                yield return RoundTestCase("b", "y");
                yield return RoundTestCase("c", "z");
                yield return SeveralRoundsTestCase("a x\nb z");
                yield return SeveralRoundsTestCase("a z\nc x");
                yield return SeveralRoundsTestCase("a y\nb y\nc x");
            }

            private static object[] RoundTestCase(string first, string second) =>
                new object[] {$"{first} {second}", new[] {new Round(first, second)}};

            private static object[] SeveralRoundsTestCase(string rounds)
            {
                var arrayRounds = rounds.Split('\n')
                    .Select(splitRound => splitRound.Split(' '))
                    .Select(round => new Round(round[0], round[1]))
                    .ToArray();

                return new object[] {rounds, arrayRounds};
            }
        }
    }
}