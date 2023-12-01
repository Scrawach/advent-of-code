using System.Collections;
using FluentAssertions;
using NUnit.Framework;
using treetop_tree_house_src.Factory;
using treetop_tree_house_src.Solves;
using treetop_tree_house_src.Storages;

namespace treetop_tree_house_tests.Solves
{
    public class ScenicTreesTests
    {
        [TestCase("example.txt", 8)]
        public void WhenGiveTrees_ThenShouldReturnHighestScenicScore(string fileName, int expected)
        {
            // arrange
            var factory = new SolvesFactory(fileName);
            var scenicTrees = factory.ScenicTrees();
            
            // act
            var count = scenicTrees.HighestScore();

            // answer
            count.Should().Be(expected);
        }
    }
}