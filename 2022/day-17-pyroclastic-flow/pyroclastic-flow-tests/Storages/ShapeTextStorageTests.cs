using System.Collections;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using pyroclastic_flow_src.Logic;
using pyroclastic_flow_src.Storages;
using pyroclastic_flow_src.Storages.Abstract;

namespace pyroclastic_flow_tests.Storages
{
    public class ShapeTextStorageTests
    {
        [TestCaseSource(nameof(SharpSymbolDataSource))]
        public void WhenReadLines_ThenShouldConvertSharpSymbols_ToRockCell(string[] lines, Cell[,] expected)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == lines);
            var storage = new ShapeTextStorage(mockedText);

            // act
            var first = storage.All().First();

            // answer
            first.Should().BeEquivalentTo(expected);
        }
        
        [TestCaseSource(nameof(PointSymbolDataSource))]
        public void WhenReadLines_ThenShouldConvertPointSymbols_ToEmptyCell(string[] lines, Cell[,] expected)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == lines);
            var storage = new ShapeTextStorage(mockedText);

            // act
            var first = storage.All().First();

            // answer
            first.Should().BeEquivalentTo(expected);
        }

        private static IEnumerable SharpSymbolDataSource()
        {
            for (var i = 1; i < 10; i++)
            {
                yield return new object[]
                {
                    new[]  { new string('#', i) },
                    ArrayRepeatedCells(Cell.Rock, i)
                };
            }
        }

        private static IEnumerable PointSymbolDataSource()
        {
            for (var i = 1; i < 10; i++)
            {
                yield return new object[]
                {
                    new[]  { new string('.', i) },
                    ArrayRepeatedCells(Cell.Empty, i)
                };
            }
        }

        private static Cell[,] ArrayRepeatedCells(Cell cell, int count)
        {
            var result = new Cell[1, count];
            for (var i = 0; i < result.Length; i++)
                result[0, i] = cell;
            return result;
        }
    }
}