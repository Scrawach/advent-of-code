using FluentAssertions;
using monkey_in_the_middle_src.Logic.Modifiers;
using NUnit.Framework;

namespace monkey_in_the_middle_tests.Logic.Modifiers
{
    public class MultiplyWorryModifierTests
    {
        [TestCase(1, 1, 1)]
        [TestCase(1, 0, 0)]
        [TestCase(2, 2, 4)]
        [TestCase(6, 7, 42)]
        public void WhenCalculateResult_ThenShouldReturnMultiply(long input, long mult, long expected)
        {
            // arrange
            var modifier = new MultiplyWorryModifier(mult);

            // act
            var result = modifier.Calculate(input);

            // answer
            result.Should().Be(expected);
        }
    }
}