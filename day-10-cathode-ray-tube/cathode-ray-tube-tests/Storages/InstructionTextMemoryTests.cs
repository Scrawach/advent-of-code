using System;
using System.Linq;
using cathode_ray_tube_src.Instructions;
using cathode_ray_tube_src.Storages;
using cathode_ray_tube_src.Storages.Abstract;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace cathode_ray_tube_tests.Storages
{
    public class InstructionTextMemoryTests
    {
        [TestCase("noop")]
        public void WhenTextContains_NoOpInstruction_ThenShouldReturnThis(string line)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == new [] {line});
            var storage = new InstructionTextMemory(mockedText);

            // act
            var noop = storage.All().First();

            // answer
            noop.Should().BeOfType<NoOperationInstruction>();
        }
        
        [TestCase("addx 0")]
        public void WhenTextContains_AddXInstruction_ThenShouldReturnThis(string line)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == new [] {line});
            var storage = new InstructionTextMemory(mockedText);

            // act
            var noop = storage.All().First();

            // answer
            noop.Should().BeOfType<AddXInstruction>();
        }

        [TestCase("addx")]
        public void WhenTextLineContainsAddInstruction_AndNotHasValue_ThenShouldThrowException(string line)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == new [] {line});
            var storage = new InstructionTextMemory(mockedText);

            // act
            Action act = () => storage.All().First();

            // answer
            act.Should().Throw<IndexOutOfRangeException>();
        }
    }
}