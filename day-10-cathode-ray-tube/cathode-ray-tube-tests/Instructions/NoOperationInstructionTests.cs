using cathode_ray_tube_src.Instructions;
using cathode_ray_tube_src.Logic.Abstract;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace cathode_ray_tube_tests.Instructions
{
    public class NoOperationInstructionTests
    {
        [Test]
        public void WhenExecuteInstruction_ThenShouldReturnFinishedResult()
        {
            // arrange
            var mockedMemory = Mock.Of<IRegisterFile>();
            var noop = new NoOperationInstruction();

            // act
            var result = noop.Execute(mockedMemory);

            // answer
            result.Should().Be(InstructionResult.Finished);
        }
    }
}