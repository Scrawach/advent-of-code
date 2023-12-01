using System.Linq;
using FluentAssertions;
using Moq;
using no_space_left_on_device_src.Commands;
using no_space_left_on_device_src.Storages;
using no_space_left_on_device_src.Storages.Abstract;
using NUnit.Framework;

namespace no_space_left_on_device_tests.Storages
{
    public class CommandTextStorageTests
    {
        [TestCase("$ cd a")]
        [TestCase("$ cd /")]
        [TestCase("$ cd ..")]
        public void WhenLineContainsChangeDirectorySymbols_ThenShouldReturnChangeDirectoryCommand(string line)
        {
            // arrange
            var mockedText = new Mock<IText>();
            mockedText.Setup(mock => mock.Lines()).Returns(() => new []{line});
            var storage = new CommandTextStorage(mockedText.Object);

            // act
            var command = storage.All().First();

            // answer
            command.Should().BeOfType<ChangeDirectoryCommand>();
            command.ToString().Should().Be($"Change Directory Command (to {line.Split( )[2]})");
        }
        
        [TestCase("$ ls a\ndir a\ndir b\n123 a.txt\n$ ls b")]
        public void WhenLineContainsListSymbols_ThenShouldReturnListCommand_WithArgumentsBeforeNextCommand(string line)
        {
            // arrange
            var mockedText = new Mock<IText>();
            mockedText.Setup(mock => mock.Lines()).Returns(() => line.Split('\n'));
            var storage = new CommandTextStorage(mockedText.Object);

            // act
            var command = storage.All().First();

            // answer
            command.Should().BeOfType<ListCommand>();
            command.ToString().Should().Be(
                line.Split('\n')
                    .Skip(1)
                    .Take(3)
                    .Aggregate("List Command: ", (first, second) => $"{first} {second}"));
        }
    }
}