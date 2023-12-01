using System.Collections;
using FluentAssertions;
using monkey_in_the_middle_src.Logic.Modifiers;
using NUnit.Framework;

namespace monkey_in_the_middle_tests.Logic.Modifiers
{
    public class SumWorryModifierTests
    {
        [TestCaseSource(nameof(SumDataSource))]
        public void WhenCalculateResult_ThenShouldReturnSum(long input, long addValue, long expected)
        {
            // arrange
            var modifier = new SumWorryModifier(addValue);

            // act
            var result = modifier.Calculate(input);

            // answer
            result.Should().Be(expected);
        }

        private static IEnumerable SumDataSource()
        {
            yield return TestCase(1, 1);
            yield return TestCase(2, 3);
            yield return TestCase(12, 30);
            yield return TestCase(63, -12);
        }

        private static object[] TestCase(int a, int b) =>
            new object[] {a, b, a + b};
    }
}