using System.Collections;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using treetop_tree_house_src.Storages;
using treetop_tree_house_src.Storages.Abstract;

namespace treetop_tree_house_tests.Storages
{
    public class HeightTextMapTests
    {
        [TestCaseSource(typeof(HeightMapDataSource))]
        public void WhenTakeStingLines_ThenShouldReturnHeightMap(string[] input, int[,] expected)
        {
            // arrange
            var mockedText = Mock.Of<IText>(text => text.Lines() == input);
            var heightMap = new HeightTextMap(mockedText);

            // act
            var map = heightMap.Read();

            // answer
            map.Should().BeEquivalentTo(expected);
        }
        
        private class HeightMapDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new[] {"1234", "1234", "1234", "1234"}, new [,] { { 1,2,3,4 }, { 1,2,3,4 }, { 1,2,3,4 }, { 1,2,3,4 }}};
                yield return new object[] { new[] {"1334", "1234", "1234", "1334"}, new [,] { { 1,3,3,4 }, { 1,2,3,4 }, { 1,2,3,4 }, { 1,3,3,4 }}};
                yield return new object[] { new[] {"4234", "4234", "1234", "1234"}, new [,] { { 4,2,3,4 }, { 4,2,3,4 }, { 1,2,3,4 }, { 1,2,3,4 }}};
            }
        }
    }
}