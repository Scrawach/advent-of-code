using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using hill_climbing_algorithm_src.Data;
using hill_climbing_algorithm_src.Logic;
using hill_climbing_algorithm_src.Storages;
using Moq;
using NUnit.Framework;

namespace hill_climbing_algorithm_tests.Logic
{
    public class BreadthFirstSearchTests
    {
        [TestCaseSource(nameof(SearchDataSource))]
        public void WhenCondition_ThenExpectation(string[] map, Vector2 fromPoint, Dictionary<Vector2, int> expected)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == map);
            var heightMap = new Heightmap(mockedText);
            heightMap.Load();
            var search = new BreadthFirstSearch(heightMap);

            // act
            var distances = search.Distances(fromPoint);

            // answer
            distances.Should().Equal(expected);
        }

        private static IEnumerable SearchDataSource()
        {
            yield return new object[]
            {
                new[] {"aaa", "aaa", "aaa"},
                new Vector2(1, 1),
                new Dictionary<Vector2, int>
                {
                    [new Vector2(1, 1)] = 0,
                    [new Vector2(0, 1)] = 1,
                    [new Vector2(1, 0)] = 1,
                    [new Vector2(1, 2)] = 1,
                    [new Vector2(2, 1)] = 1,
                    [new Vector2(0, 0)] = 2,
                    [new Vector2(2, 0)] = 2,
                    [new Vector2(2, 2)] = 2,
                    [new Vector2(0, 2)] = 2
                }
            };
        }
    }
}