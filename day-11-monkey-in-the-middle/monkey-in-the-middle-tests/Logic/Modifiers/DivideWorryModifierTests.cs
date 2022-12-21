using FluentAssertions;
using monkey_in_the_middle_src.Logic.Modifiers;
using NUnit.Framework;

namespace monkey_in_the_middle_tests.Logic.Modifiers
{
    public class DivideWorryModifierTests
    {
        [TestCase(1, 1, 1)]
        [TestCase(0, 1, 0)]
        [TestCase(100, 2, 50)]
        [TestCase(1000, 3, 333)]
        public void WhenCalculateResult_ThenShouldReturnDivide(long input, long divider, long expected)
        {
            // arrange
            var modifier = new DivideWorryModifier(divider);

            // act
            var result = modifier.Calculate(input);

            // answer
            result.Should().Be(result);
        }

        [TestCase(10, 3, 3)]
        [TestCase(1000, 3, 333)]
        public void WhenCalculateResult_ThenShouldReturn_RoundedNumber(long input, long divider, long expected)
        {
            // arrange
            var modifier = new DivideWorryModifier(divider);

            // act
            var result = modifier.Calculate(input);

            // answer
            result.Should().Be(result);
        }
    }
}