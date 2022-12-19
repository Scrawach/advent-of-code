using System.Collections;
using FluentAssertions;
using NUnit.Framework;
using treetop_tree_house_src.Factory;
using treetop_tree_house_src.Solves;
using treetop_tree_house_src.Storages;

namespace treetop_tree_house_tests.Solves
{
    public class VisibleTreesTests
    {
        [TestCase("example.txt", 21)]
        public void WhenGiveMap_ThenShouldReturnTotalCountVisibleTrees(string fileName, int expected)
        {
            // arrange
            var factory = new SolvesFactory(fileName);
            var visibleTrees = factory.VisibleTrees();
            
            // act
            var count = visibleTrees.TotalCount();

            // answer
            count.Should().Be(expected);
        }
    }
}