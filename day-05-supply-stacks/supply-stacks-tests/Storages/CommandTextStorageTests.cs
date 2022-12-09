using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using supply_stacks_src.Storages;
using supply_stacks_src.Storages.Abstract;
using supply_stacks_src.Vehicles.Abstract;

namespace supply_stacks_tests.Storages
{
    public class CommandTextStorageTests
    {
        [TestCaseSource(typeof(CommandTextDataSource))]
        public void WhenReadLine_ShouldReturnCommand_WithCorrectData(string line, int count, int fromIndex, int toIndex)
        {
            // arrange
            var textMock = new Mock<IText>();
            var crateMock = new Mock<ICrateMover>();
            textMock.Setup(mock => mock.Lines()).Returns(new[] {line});
            var storage = new CommandTextStorage(textMock.Object);
            
            // act
            var command = storage.All().First();
            command.Execute(crateMock.Object);

            // answer
            crateMock.Verify(mock => mock.Move(count, fromIndex, toIndex));
        }

        [TestCaseSource(typeof(FileReadingDataSource))]
        public void WhenReadFromTestFile_ThenShouldReturnOnlyCommands(string fileName, string[] commands)
        {
            // arrange
            var path = Path.Combine(Working.Directory, fileName);
            var text = new Text(path);
            var storage = new CommandTextStorage(text);

            // act
            var result = storage.All().Select(command => command.ToString());

            // answer
            result.Should().Equal(commands);
        }

        private class CommandTextDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                var random = new Random(0);
                return GenerateCommands(25, 100, random).GetEnumerator();
            }
        }
        
        private static IEnumerable<object[]> GenerateCommands(int count, int maxValue, Random random)
        {
            for (var i = 0; i < count; i++)
            {
                var boxCount = random.Next(1, maxValue);
                var toIndex = random.Next(1, maxValue);
                var fromIndex = random.Next(1, maxValue);
                yield return new object[] {$"move {boxCount} from {fromIndex} to {toIndex}", boxCount, fromIndex, toIndex};
            }
        }

        public class FileReadingDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {"example.txt", CommandsFromExample()};
            }

            private string[] CommandsFromExample() =>
                new[]
                {
                    "move 1 from 2 to 1",
                    "move 3 from 1 to 3",
                    "move 2 from 2 to 1",
                    "move 1 from 1 to 2"
                };
        }
    }
}