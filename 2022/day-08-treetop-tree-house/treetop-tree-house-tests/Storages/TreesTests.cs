using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using treetop_tree_house_src.Storages;

namespace treetop_tree_house_tests.Storages
{
    public class TreesTests
    {
        [TestCaseSource(typeof(TreesDataSource))]
        public void WhenTakeAllTrees_ThenShouldReturnCorrectTrees_FromMap(int[,] map, Tree[] expectedTrees)
        {
            // arrange
            var trees = new Trees(map);

            // act
            var allTrees = trees.All();

            // answer
            allTrees.Should().Equal(expectedTrees);
        }
        
        private class TreesDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {new[,] {{5}}, new[] {new Tree(0, 0, 5)}};
                
                var simpleMap = new[,]
                {
                    {1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}
                };
                
                yield return new object[] {simpleMap, CreateTrees(simpleMap).ToArray()};
            }

            private static IEnumerable<Tree> CreateTrees(int[,] map)
            {
                for (var i = 0; i < map.GetLength(0); i++)
                for (var j = 0; j < map.GetLength(1); j++)
                    yield return new Tree(i, j, map[i, j]);
            }
        }
    }
}