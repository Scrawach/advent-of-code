using System;
using FluentAssertions;
using Moq;
using no_space_left_on_device_src.Commands;
using no_space_left_on_device_src.Disk.Abstract;
using NUnit.Framework;

namespace no_space_left_on_device_tests.Commands
{
    public class ChangeDirectoryTests
    {
        [TestCase("..")]
        public void WhenLineContainsDoublePoints_ThenShouldReturnToPreviousDirectory(string input)
        {
            // arrange
            var mockedDevice = new Mock<IDevice>();
            var command = new ChangeDirectoryCommand(input);

            // act
            command.Execute(mockedDevice.Object);

            // answer
            mockedDevice.Verify(mock => mock.ToPrevious(), Times.Once);
            mockedDevice.VerifyNoOtherCalls();
        }

        [TestCase("/")]
        public void WhenInputContainsSlash_ThenShouldReturnToRootDirectory(string input)
        {
            // arrange
            var mockedDevice = new Mock<IDevice>();
            var command = new ChangeDirectoryCommand(input);

            // act
            command.Execute(mockedDevice.Object);

            // answer
            mockedDevice.Verify(mock => mock.ToRoot(), Times.Once);
            mockedDevice.VerifyNoOtherCalls();
        }

        [TestCase("directoryName")]
        [TestCase("asd123")]
        [TestCase("123")]
        public void WhenInputContainsNotEmptyString_ThenShouldMoveDirectoryToIt(string input)
        {
            // arrange
            var mockedDevice = new Mock<IDevice>();
            var command = new ChangeDirectoryCommand(input);

            // act
            command.Execute(mockedDevice.Object);

            // answer
            mockedDevice.Verify(mock => mock.To(It.Is<string>(data => data == input)), Times.Once);
            mockedDevice.VerifyNoOtherCalls();
        }
    }
}