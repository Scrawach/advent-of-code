using System;
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
    public class SumRulesTests
    {
        [TestCaseSource(typeof(SumRulesDataSource))]
        public void WhenGetScore_ThenShouldReturnSumAllScoreRules(int[] scores, int expected)
        {
            // arrange
            var sumRules = new SumRules(CreateMockRules(scores));

            // act
            var result = sumRules.Score(new Round());

            // answer
            result.Should().Be(expected);
        }

        private static IGameRule[] CreateMockRules(IEnumerable<int> returnValues)
        {
            var rules = new List<IGameRule>();

            foreach (var score in returnValues)
            {
                var ruleMock = new Mock<IGameRule>();
                ruleMock.Setup(mock => mock.Score(It.IsAny<Round>())).Returns<Round>(round => score);
                rules.Add(ruleMock.Object);
            }

            return rules.ToArray();
        }

        private class SumRulesDataSource : IEnumerable
        {
            private readonly Random _random = new Random(0);

            public IEnumerator GetEnumerator()
            {
                yield return TestCase(new[] {1, 2, 3, 4, 5});
                yield return TestCase(new[] {1, 1});
                yield return TestCase(new[] {0});
                yield return Generate(10, _random);
                yield return Generate(100, _random);
                yield return Generate(69, _random);
            }

            private static object[] Generate(int valuesCount, Random random)
            {
                var array = new int[valuesCount];
                for (var i = 0; i < array.Length; i++)
                    array[i] = random.Next(-10000, 10000);
                return TestCase(array);
            }

            private static object[] TestCase(int[] values) =>
                new object[] {values, values.Sum()};
        }
    }
}