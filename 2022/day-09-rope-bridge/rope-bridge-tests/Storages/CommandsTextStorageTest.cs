using System.Collections;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using rope_bridge_src.Data;
using rope_bridge_src.Logic;
using rope_bridge_src.Storages;
using rope_bridge_src.Storages.Abstract;

namespace rope_bridge_tests.Storages
{
    public class CommandsTextStorageTest
    {
        [TestCaseSource(typeof(DirectionsDataSource))]
        public void WhenParseText_ThenHeadShouldExecuteCorrectDirection(string[] lines, Vector2 expected)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.All() == lines);
            var mockedHead = new Mock<IHead>();
            var storage = new CommandsTextStorage(mockedText);

            // act
            storage.All().First().Execute(mockedHead.Object);

            // answer
            mockedHead.Verify(mock => mock.Move(expected));
        }

        [TestCaseSource(typeof(CountDataSource))]
        public void WhenParseText_WithStepCounts_ThenShouldReturnCorrectCommandsCount(string[] lines, int expectedCommandsCount)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.All() == lines);
            var storage = new CommandsTextStorage(mockedText);

            // act
            var count = storage.All().Count();

            // answer
            count.Should().Be(expectedCommandsCount);
        }

        [TestCaseSource(typeof(CorrectnessCommandsDataSource))]
        public void WhenParseText_ThenShouldReturnCorrectCommands(string[] lines, Vector2 expectedPosition)
        {
            // arrange
            var position = Vector2.Zero;
            var mockedText = Mock.Of<IText>(mock => mock.All() == lines);
            var mockedHead = new Mock<IHead>();
            
            mockedHead
                .Setup(mock => mock.Move(It.IsAny<Vector2>()))
                .Callback<Vector2>(direction => position += direction)
                .Verifiable();
            
            var storage = new CommandsTextStorage(mockedText);
            
            // act
            foreach (var command in storage.All()) 
                command.Execute(mockedHead.Object);

            // answer
            position.Should().Be(expectedPosition);
        }
        
        private class DirectionsDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {new[] {"R 1"}, Vector2.Right};
                yield return new object[] {new[] {"U 1"}, Vector2.Up};
                yield return new object[] {new[] {"D 1"}, Vector2.Down};
                yield return new object[] {new[] {"L 1"}, Vector2.Left};
            }
        }
        
        private class CountDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                for (var i = 0; i < 10; i++)
                    yield return new object[] {new[] {$"R {i}"}, i};
                yield return new object[] {new[] {"R 3", "L 3"}, 6};
                yield return new object[] {new[] {"R 3", "L 3", "R 3"}, 9};
                yield return new object[] {new[] {"R 1", "L 2", "R 3"}, 6};
            }
        }
        
        private class CorrectnessCommandsDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {new[] {"R 1"}, Vector2.Right};
                yield return new object[] {new[] {"R 1", "L 1"}, Vector2.Zero};
                yield return new object[] {new[] {"R 1", "L 1", "U 1", "D 1"}, Vector2.Zero};
                yield return new object[] {new[] {"R 1", "L 1", "U 1"}, Vector2.Up};
                yield return new object[] {new[] {"R 1", "L 1", "U 1", "U 2"}, new Vector2(0, 3)};
            }
        }
    }
}