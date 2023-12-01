using System.Collections;
using System.Linq;
using boiling_boulders_src.Data;
using boiling_boulders_src.Storages;
using boiling_boulders_src.Storages.Abstract;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace boiling_boulders_tests.Storages
{
    public class CubeTextStorageTests
    {
        [TestCaseSource(nameof(CoordsDataSource))]
        public void WhenReadCoords_ThenShouldReturnVector3(string[] lines, Vector3[] expected)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == lines);
            var storage = new CubeTextStorage(mockedText);

            // act
            var vectors = storage.All().ToArray();

            // answer
            vectors.Should().Equal(expected);
        }

        private static IEnumerable CoordsDataSource()
        {
            yield return new object[]
            {
                new[] { "0,0,0" },
                new[] { new Vector3(0,0,0), }
            };
            yield return new object[]
            {
                new[] {"1,2,3", "4,5,6", "7,8,9"},
                new[] { new Vector3(1,2,3), new Vector3(4,5,6), new Vector3(7,8,9) }
            };
        }
    }
}