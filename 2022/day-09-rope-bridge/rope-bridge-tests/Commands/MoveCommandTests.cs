using System.Collections;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using rope_bridge_src.Commands;
using rope_bridge_src.Data;
using rope_bridge_src.Logic;

namespace rope_bridge_tests.Commands
{
    public class MoveCommandTests
    {
        [TestCaseSource(typeof(MoveCommandDataSource))]
        public void WhenExecuteMoveCommand_ThenShouldChangePosition(Vector2 direction)
        {
            // arrange
            var mockedHead = Mock.Of<IHead>();
            var moveCommand = new MoveCommand(direction);

            // act
            moveCommand.Execute(mockedHead);

            // answer
            Mock.Get(mockedHead).Verify(mock => mock.Move(It.Is<Vector2>(pos => pos.X == direction.X && pos.Y == direction.Y)));
        }
        
        private class MoveCommandDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return Vector2.Down;
                yield return Vector2.Up;
                yield return Vector2.Right;
                yield return Vector2.Left;
                yield return Vector2.Zero;
            }
        }
    }
}