using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using rope_bridge_src.Data;
using rope_bridge_src.Logic;

namespace rope_bridge_tests.Logic
{
    public class TailTests
    {
        [TestCaseSource(typeof(OneStepDataSource))]
        public void WhenHeadInOneStepDistance_ThenTailShouldNotMoving(Vector2 headPosition, Vector2 expectedTailPosition)
        {
            // arrange
            var mockedHead = new Mock<IHead>();
            mockedHead.SetupGet(mock => mock.Position).Returns(headPosition);

            var tail = new Tail(mockedHead.Object);

            // act
            tail.Update();

            // answer
            tail.Position.Should().Be(expectedTailPosition);
        }

        [TestCaseSource(typeof(TwoStepDataSource))]
        public void WhenHeadInTwoStepDistance_ThenTailShouldUpdateSelfPosition(Vector2 headPosition, Vector2 expectedTailPosition)
        {
            // arrange
            var mockedHead = new Mock<IHead>();
            mockedHead.SetupGet(mock => mock.Position).Returns(headPosition);

            var tail = new Tail(mockedHead.Object);

            // act
            tail.Update();

            // answer
            tail.Position.Should().Be(expectedTailPosition);
        }

        [TestCaseSource(typeof(DiagonallyDataSource))]
        public void WhenHeadInDiagonally_ThenTailShouldUpdateSelfPosition_ToDiagonally(Vector2 headPosition, Vector2 expectedTailPosition)
        {
            // arrange
            var mockedHead = new Mock<IHead>();
            mockedHead.SetupGet(mock => mock.Position).Returns(headPosition);

            var tail = new Tail(mockedHead.Object);

            // act
            tail.Update();

            // answer
            tail.Position.Should().Be(expectedTailPosition);
        }

        [TestCaseSource(typeof(UniquePositionsDataSource))]
        public void WhenTailInUniquePosition_ThenShouldStoreThisPosition(Vector2[] headPosition, Vector2[] uniquePositions)
        {
            // arrange
            var headMock = new HeadMock(headPosition);
            var tail = new Tail(headMock);

            // act
            foreach (var position in headPosition)
            {
                headMock.Next();
                tail.Update();
            }

            // answer
            tail.UniquePositions.Should().Equal(uniquePositions);
        }
        
        private class HeadMock : IHead
        {
            private readonly Vector2[] _path;
            private int _index;

            public HeadMock(Vector2[] path, int index = -1)
            {
                _path = path;
                _index = index;
            }

            public Vector2 Position => _path[_index];

            public void Next() =>
                _index++;

            public void Move(Vector2 direction) =>
                throw new System.NotImplementedException();
        }
        
        private class OneStepDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {Vector2.Zero, Vector2.Zero};
                yield return new object[] {Vector2.Up, Vector2.Zero};
                yield return new object[] {Vector2.Down, Vector2.Zero};
                yield return new object[] {Vector2.Left, Vector2.Zero};
                yield return new object[] {Vector2.Right, Vector2.Zero};
            }
        }
        
        private class TwoStepDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {new Vector2(0, 2), new Vector2(0, 1)};
                yield return new object[] {new Vector2(0, -2), new Vector2(0, -1)};
                yield return new object[] {new Vector2(2, 0), new Vector2(1, 0)};
                yield return new object[] {new Vector2(-2, 0), new Vector2(-1, 0)};
            }
        }
        
        private class DiagonallyDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {new Vector2(1, 2), new Vector2(1, 1)};
                yield return new object[] {new Vector2(-1, -2), new Vector2(-1, -1)};
            }
        }
        
        private class UniquePositionsDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {CreatePath((0, 0), (0, 1)), CreatePath((0, 0))};
                yield return new object[] {CreatePath((0, 0), (0, 1), (1, 1)), CreatePath((0, 0))};
                yield return new object[] {CreatePath((1, 2)), CreatePath((0, 0), (1, 1))};
                yield return new object[] {CreatePath((1, 2), (0, 0)), CreatePath((0, 0), (1, 1))};
                yield return new object[] {CreatePath((1, 2), (1, 3)), CreatePath((0, 0), (1, 1), (1, 2))};
                yield return new object[] {CreatePath((0, 1), (0, 2), (0, 3)), CreatePath((0, 0), (0, 1), (0, 2))};
                yield return new object[] {CreatePath((0, 1), (0, 2), (0, 3), (0, 2), (0, 1), (0, 0)), CreatePath((0, 0), (0, 1), (0, 2))};
                yield return new object[] {CreatePath((0, 1), (1, 1), (1, 2), (2, 2), (1, 1), (0, 1), (0, 0)), CreatePath((0, 0), (1, 1))};
            }

            private Vector2[] CreatePath(params (int x, int y)[] points) =>
                points.Select(x => new Vector2(x.x, x.y)).ToArray();
        }
    }
}