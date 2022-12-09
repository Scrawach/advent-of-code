using System.Collections;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using supply_stacks_src.Storages;
using supply_stacks_src.Storages.Abstract;
using supply_stacks_tests.Utils;

namespace supply_stacks_tests.Storages
{
    public class InitialTextStorageTests
    {
        [TestCaseSource(typeof(InitialTextStorageDataSource))]
        public void WhenReadFormattedLines_ThenShouldReturnInitialStateInStacks(string[] lines, Stack<char>[] expected)
        {
            // arrange
            var textMock = new Mock<IText>();
            textMock.Setup(mock => mock.Lines()).Returns(lines);
            var storage = new InitialTextStorage(textMock.Object);

            // act
            var result = storage.InitialState();

            // answer
            for (var i = 0; i < result.Length; i++) 
                result[i].Should().Equal(expected[i]);
        }

        [TestCaseSource(typeof(FileReadingDataSource))]
        public void WhenReadFromTestFile_ThenShouldReturnInitialState_WithoutCommands(string fileName, Stack<char>[] expected)
        {
            // arrange
            var path = Path.Combine(Working.Directory, fileName);
            var text = new Text(path);
            var storage = new InitialTextStorage(text);

            // act
            var result = storage.InitialState();

            // answer
            for (var i = 0; i < result.Length; i++) 
                result[i].Should().Equal(expected[i]);
        }
        
        private class InitialTextStorageDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {new[] {"[Z] [M] [P]"}, new[] {NewStack('Z'), NewStack('M'), NewStack('P')}};
                yield return new object[] {new[] {"    [M] [P]"}, new[] {new Stack<char>(), NewStack('M'), NewStack('P')}};
                yield return new object[] {new[] {"    [D] [T]", "[H] [Q] [P]"}, new[] {NewStack('H'), NewStack('Q', 'D'), NewStack('P', 'T')}};
                yield return new object[] {new[] {"    [D]    ", "[N] [C]    ", "[Z] [M] [P]"}, new[] {NewStack('Z', 'N'), NewStack('M', 'C', 'D'), NewStack('P')}};
                yield return new object[] {new[] {"[Z] [M] [P]", " 1   2   3 "}, new[] {NewStack('Z'), NewStack('M'), NewStack('P')}};
            }
        }

        private class FileReadingDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {"example.txt", new[] {NewStack('Z', 'N'), NewStack('M', 'C', 'D'), NewStack('P')}};
            }
        }
        
        private static Stack<char> NewStack(params char[] content) =>
            new Stack<char>(content);

    }
}