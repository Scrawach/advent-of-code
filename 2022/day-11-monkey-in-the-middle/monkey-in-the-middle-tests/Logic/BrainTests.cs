using System.Collections;
using FluentAssertions;
using monkey_in_the_middle_src.Logic;
using monkey_in_the_middle_src.Logic.Data;
using monkey_in_the_middle_src.Logic.Modifiers.Abstract;
using monkey_in_the_middle_src.Logic.TestPolicy.Abstract;
using Moq;
using NUnit.Framework;

namespace monkey_in_the_middle_tests.Logic
{
    public class BrainTests
    {
        [TestCaseSource(nameof(BrainPolicyDataSource))]
        public void WhenPolicyTrue_ThenShouldReturnPassedTargetId(int passedId)
        {
            // arrange
            var mockedModifier = Mock.Of<IWorryLevelModifier>();
            var mockedPolicy = Mock.Of<IWorryLevelPolicy>(mock => mock.IsCriticalLevel(It.IsAny<long>()));
            var brain = new Brain(passedId, int.MinValue, mockedModifier, mockedPolicy);

            // act
            var item = new Item(0);
            var nextTarget = brain.NextTarget(item);

            // answer
            nextTarget.Should().Be(passedId);
        }
        
        [TestCaseSource(nameof(BrainPolicyDataSource))]
        public void WhenPolicyFalse_ThenShouldReturnFailedTargetId(int failedId)
        {
            // arrange
            var mockedModifier = Mock.Of<IWorryLevelModifier>();
            var mockedPolicy = Mock.Of<IWorryLevelPolicy>(mock => !mock.IsCriticalLevel(It.IsAny<long>()));
            var brain = new Brain(int.MinValue, failedId, mockedModifier, mockedPolicy);

            // act
            var item = new Item(0);
            var nextTarget = brain.NextTarget(item);

            // answer
            nextTarget.Should().Be(failedId);
        }

        private static IEnumerable BrainPolicyDataSource()
        {
            yield return 0;
            yield return 1;
            yield return 2;
            yield return 13;
            yield return 42;
        }
    }
}