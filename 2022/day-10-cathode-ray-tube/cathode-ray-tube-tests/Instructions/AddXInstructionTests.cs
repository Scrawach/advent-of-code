using cathode_ray_tube_src.Instructions;
using cathode_ray_tube_src.Logic.Abstract;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace cathode_ray_tube_tests.Instructions
{
    public class AddXInstructionTests
    {
        [Test]
        public void WhenExecuteOnce_ThenShouldReturnProcessedResult()
        {
            // arrange
            var mockedMemory = Mock.Of<IRegisterFile>();
            var addX = new AddXInstruction(0);

            // act
            var result = addX.Execute(mockedMemory);

            // answer
            result.Should().Be(InstructionResult.Processed);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void WhenExecuteTwice_ThenShouldReturnFinishedResult_AndChangeMemoryRegister(int addValue)
        {
            // arrange
            var mockedMemory = Mock.Of<IRegisterFile>();
            Mock.Get(mockedMemory).SetupSet(mock => mock.RegisterX = addValue);
            
            var addX = new AddXInstruction(addValue);

            // act
            addX.Execute(mockedMemory);
            var result = addX.Execute(mockedMemory);

            // answer
            result.Should().Be(InstructionResult.Finished);
            Mock.Verify();
        }


        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void WhenExecuteOnce_ThenNotShouldUpdateMemoryRegister(int addValue)
        {
            // arrange
            var mockedMemory = Mock.Of<IRegisterFile>();
            Mock.Get(mockedMemory).SetupSet(mock => mock.RegisterX = 0);

            var addX = new AddXInstruction(1);

            // act
            var result = addX.Execute(mockedMemory);

            // answer
            result.Should().Be(InstructionResult.Processed);
            Mock.Verify();
        }
    }
}