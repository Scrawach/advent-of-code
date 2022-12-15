using Moq;
using no_space_left_on_device_src.Commands;
using no_space_left_on_device_src.Disk.Abstract;
using NUnit.Framework;

namespace no_space_left_on_device_tests.Commands
{
    public class ListCommandTests
    {
        [TestCase("dir a")]
        [TestCase("dir b")]
        [TestCase("dir c")]
        public void WhenInputContainsDir_ThenShouldCreateDirectory(string input)
        {
            // arrange
            var mockedDevice = new Mock<IDevice>();
            var command = new ListCommand(new []{ input });
            var directoryName = input.Split(" ")[1];

            // act
            command.Execute(mockedDevice.Object);

            // answer
            mockedDevice.Verify(mock => mock.CreateDirectory(It.Is<string>(dir => dir == directoryName)));
        }

        [TestCase("123 a.txt")]
        [TestCase("256 b.txt")]
        [TestCase("1000000 text.txt")]
        public void WhenInputNotContainsDir_ThenShouldCreateFile_WithSize(string input)
        {
            // arrange
            var mockedDevice = new Mock<IDevice>();
            var command = new ListCommand(new []{ input });
            var fileSize = int.Parse(input.Split(" ")[0]);

            // act
            command.Execute(mockedDevice.Object);

            // answer
            mockedDevice.Verify(mock => mock.CreateFile(It.Is<int>(size => size == fileSize)));
        }
    }
}