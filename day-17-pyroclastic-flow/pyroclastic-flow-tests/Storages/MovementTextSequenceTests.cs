using System.Collections;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using pyroclastic_flow_src.Data;
using pyroclastic_flow_src.Storages;
using pyroclastic_flow_src.Storages.Abstract;

namespace pyroclastic_flow_tests.Storages
{
    public class MovementTextSequenceTests
    {
        [Test]
        public void WhenFindLeftArrow_ThenShouldReturn_Vector2Left()
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == new[] {"<"});
            var sequence = new MovementTextSequence(mockedText);

            // act
            var next = sequence.NextDirection();

            // answer
            next.Should().Be(Vector2.Left);
        }
        
        [Test]
        public void WhenFindRightArrow_ThenShouldReturn_Vector2Right()
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == new[] {">"});
            var sequence = new MovementTextSequence(mockedText);

            // act
            var next = sequence.NextDirection();

            // answer
            next.Should().Be(Vector2.Right);
        }
        
        [TestCaseSource(nameof(SequenceDataSource))]
        public void WhenFindSequenceOfArrow_ShouldReturnSequenceOfVectors(string arrows, Vector2[] expected)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == new[] { arrows });
            var sequence = new MovementTextSequence(mockedText);

            // act

            // answer
            for (var i = 0; i < arrows.Length; i++) 
                sequence.NextDirection().Should().Be(expected[i]);
        }

        private static IEnumerable SequenceDataSource()
        {
            yield return new object[]
            {
                ">>><<><",
                new[]
                {
                    Vector2.Right,
                    Vector2.Right,
                    Vector2.Right,
                    Vector2.Left,
                    Vector2.Left,
                    Vector2.Right,
                    Vector2.Left,
                }
            };
        }
    }
}