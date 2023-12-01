using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using rock_paper_scissors_src.GameRules.Abstract;
using rock_paper_scissors_src.Rounds;
using rock_paper_scissors_src.Rounds.Convert;

namespace rock_paper_scissors_tests.Rounds.Convert
{
    public class AsChoiceConverterTests
    {
        private static readonly string[] Choices = {"aaa", "bbb", "ccc"};

        [TestCaseSource(typeof(ConverterSourceData))]
        public void WhenArgsContainsXYZ_ThenShouldReturnChoice_FromAvailableChoices(string input, Round expected)
        {
            // arrange
            var mockChoices = new Mock<IChoicesStorage>();
            mockChoices.Setup(mock => mock.AvailableChoices()).Returns(Choices);
            var converter = new AsChoiceConverter(mockChoices.Object);
            var choices = input.Split(' ');

            // act
            var result = converter.Convert(choices[0], choices[1]);

            // answer
            result.Should().Be(expected);
        }

        [TestCase("X", "A")]
        [TestCase("Y", "C")]
        [TestCase("Z", "B")]
        public void WhenArgsContainsCapitalXYZ_ThenShouldThrowKeyNotFoundException(string first, string second)
        {
            // arrange
            var mockChoices = new Mock<IChoicesStorage>();
            mockChoices.Setup(mock => mock.AvailableChoices()).Returns(Choices);
            var converter = new AsChoiceConverter(mockChoices.Object);

            // act
            Action act = () => converter.Convert(first, second);

            // answer
            act.Should().Throw<KeyNotFoundException>();
        }

        private class ConverterSourceData : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {"a x", new Round(Choices[0], Choices[0])};
                yield return new object[] {"b y", new Round(Choices[1], Choices[1])};
                yield return new object[] {"c z", new Round(Choices[2], Choices[2])};
            }
        }
    }
}