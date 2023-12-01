using FluentAssertions;
using monkey_in_the_middle_src.Logic.Modifiers;
using NUnit.Framework;

namespace monkey_in_the_middle_tests.Logic.Modifiers
{
    public class SquaringWorryModifierTests
    {
        [TestCase(1, 1)]
        [TestCase(0, 0)]
        [TestCase(2, 4)]
        [TestCase(3, 9)]
        [TestCase(6, 36)]
        [TestCase(10, 100)]
        public void WhenCalculateResult_ThenShouldReturnSquare(long input, long expected)
        {
            // arrange
            var modifier = new SquaringWorryModifier();

            // act
            var result = modifier.Calculate(input);

            // answer
            result.Should().Be(expected);
        }
    }

    public class ModuleWorryModifierTests
    {
        [TestCase(10, 15, 10)]
        [TestCase(52, 5, 2)]
        [TestCase(10, 5, 0)]
        [TestCase(120, 42, 36)]
        public void WhenCalculateResult_ThenShouldReturnMod(long input, long modulate, long expected)
        {
            // arrange
            var modifier = new ModuleWorryModifier(modulate);
            
            // act
            var result = modifier.Calculate(input);

            // answer
            result.Should().Be(expected);
        }
    }
}