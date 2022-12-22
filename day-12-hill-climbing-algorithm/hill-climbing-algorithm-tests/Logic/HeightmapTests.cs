using System.Collections;
using FluentAssertions;
using hill_climbing_algorithm_src.Data;
using hill_climbing_algorithm_src.Logic;
using hill_climbing_algorithm_src.Storages;
using Moq;
using NUnit.Framework;

namespace hill_climbing_algorithm_tests.Logic
{
    public class HeightmapTests
    {
        [TestCaseSource(nameof(MapDataSource))]
        public void WhenLoadMapWithSymbol_ThenShouldConvertItToIntegerHeight(string[] lines, int[,] expected)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == lines);
            var heightmap = new Heightmap(mockedText);

            // act
            heightmap.Load();

            // answer
            for (var y = 0; y < expected.GetLength(0); y++)
            for (var x = 0; x < expected.GetLength(1); x++)
                heightmap[new Vector2(x, y)].Should().Be(expected[y, x]);
        }
        
        [TestCaseSource(nameof(MapStartDataSource))]
        public void WhenMapContainsSymbol_S_ThenShouldReadIt_AsStartPoint(string[] lines, Vector2 expected)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == lines);
            var heightmap = new Heightmap(mockedText);

            // act
            heightmap.Load();
            var startPoint = heightmap.Start;

            // answer
            startPoint.Should().Be(expected);
        }

        [TestCaseSource(nameof(MapTargetDataSource))]
        public void WhenMapContainsSymbol_E_ThenShouldReadIt_AsTargetPoint(string[] lines, Vector2 expected)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == lines);
            var heightmap = new Heightmap(mockedText);

            // act
            heightmap.Load();
            var startPoint = heightmap.Target;

            // answer
            startPoint.Should().Be(expected);
        }

        [TestCaseSource(nameof(SymbolEDataSource))]
        public void WhenMapContainsSymbol_E_ThenItShouldHas_Z_Height(string[] lines, Vector2 zPosition)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == lines);
            var heightmap = new Heightmap(mockedText);

            // act
            heightmap.Load();
            var zPoint = heightmap[zPosition];
            var endPoint = heightmap[heightmap.Target];

            // answer
            endPoint.Should().Be(zPoint);
        }

        [TestCaseSource(nameof(HasDataSource))]
        public void WhenHas_ThenShouldReturnTrue_IfPointInBorder(string[] lines, Vector2 coords, bool expected)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == lines);
            var heightmap = new Heightmap(mockedText);
            
            // act
            heightmap.Load();
            var has = heightmap.Has(coords);

            // answer
            has.Should().Be(expected);
        }

        private static IEnumerable HasDataSource()
        {
            yield return new object[] { new[] {"ab", "cd"}, new Vector2(0, 0), true };
            yield return new object[] { new[] {"ab", "cd"}, new Vector2(1, 0), true };
            yield return new object[] { new[] {"ab", "cd"}, new Vector2(1, 1), true };
            yield return new object[] { new[] {"ab", "cd"}, new Vector2(0, 1), true };
            yield return new object[] { new[] {"ab", "cd"}, new Vector2(2, 0), false };
        }

        private static IEnumerable SymbolEDataSource()
        {
            yield return new object[]
            {
                new[] {"zE"},
                new Vector2(0, 0)
            };
        }

        private static IEnumerable MapDataSource()
        {
            yield return new object[]
            {
                new[] {"ab", "cd"},
                new[,] { {0, 1}, {2, 3} }
            };
            yield return new object[]
            {
                new[] {"abc", "def", "ghi"},
                new[,] { {0,1,2}, {3,4,5}, {6,7,8}}
            };
        }
        
        private static IEnumerable MapStartDataSource()
        {
            yield return new object[]
            {
                new[] {"An", "bS"},
                new Vector2(1, 1)
            };
        }
        
        private static IEnumerable MapTargetDataSource()
        {
            yield return new object[]
            {
                new[] {"An", "ES"},
                new Vector2(0, 1)
            };
        }
    }
}