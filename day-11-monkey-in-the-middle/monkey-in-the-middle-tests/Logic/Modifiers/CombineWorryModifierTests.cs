using FluentAssertions;
using monkey_in_the_middle_src.Logic.Modifiers;
using monkey_in_the_middle_src.Logic.Modifiers.Abstract;
using Moq;
using NUnit.Framework;

namespace monkey_in_the_middle_tests.Logic.Modifiers
{
    public class CombineWorryModifierTests
    {
        [TestCase(0, 0)]
        [TestCase(2, 2)]
        [TestCase(42, 42)]
        public void WhenCalculateResult_AndCombineEmpty_ThenShouldReturnThisNumber(long input, long expected)
        {
            // arrange
            var modifier = new CombineWorryModifier();

            // act
            var result = modifier.Calculate(input);

            // answer
            result.Should().Be(expected);
        }

        [TestCase(0, 0)]
        [TestCase(2, 0)]
        [TestCase(42, 0)]
        [TestCase(521, 0)]
        public void WhenCalculateResult_WithCombineZeroModifier_ThenShouldReturnZero(long input, long expected)
        {
            // arrange
            var mocked = Mock.Of<IWorryLevelModifier>(mock => mock.Calculate(It.IsAny<long>()) == 0);
            var modifier = new CombineWorryModifier(mocked);

            // act
            var result = modifier.Calculate(input);

            // answer
            result.Should().Be(expected);
        }

        [TestCase(0, 0)]
        [TestCase(1, 4)]
        [TestCase(2, 16)]
        [TestCase(3, 36)]
        [TestCase(4, 64)]
        public void WhenCalculateResult_WithCombineModifiers_ThenShouldReturnCorrectResult(long input, long expected)
        {
            // arrange
            var add = Mock.Of<IWorryLevelModifier>();
            var mult = Mock.Of<IWorryLevelModifier>();
            Mock.Get(add).Setup(mock => mock.Calculate(It.IsAny<long>())).Returns<long>(x => x + x);
            Mock.Get(mult).Setup(mock => mock.Calculate(It.IsAny<long>())).Returns<long>(x => x * x);

            var modifier = new CombineWorryModifier(add, mult);
            
            // act
            var result = modifier.Calculate(input);

            // answer
            result.Should().Be(expected);
        }
    }
}