using FluentAssertions;
using monkey_in_the_middle_src.Logic.TestPolicy;
using NUnit.Framework;

namespace monkey_in_the_middle_tests.Logic.TestPolicy
{
    public class DivisibleWorryLevelPolicyTests
    {
        [TestCase(1, 1, true)]
        [TestCase(4, 2, true)]
        [TestCase(9, 3, true)]
        [TestCase(192, 3, true)]
        [TestCase(11, 4, false)]
        [TestCase(42, 13, false)]
        public void WhenCheckCriticalLevel_ThenShouldReturnTrue_WhenItDivisible(long input, long div, bool expected)
        {
            // arrange
            var policy = new DivisibleWorryLevelPolicy(div);

            // act
            var result = policy.IsCriticalLevel(input);

            // answer
            result.Should().Be(expected);
        }
    }
}