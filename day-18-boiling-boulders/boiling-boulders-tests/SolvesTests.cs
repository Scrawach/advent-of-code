using boiling_boulders_src.Factory;
using FluentAssertions;
using NUnit.Framework;

namespace boiling_boulders_tests
{
    public class SolvesTests
    {
        [TestCase("example.txt", 64)]
        public void WhenReadCubesCoords_ThenShouldCalculate_SurfaceArea(string fileName, int expected)
        {
            // arrange
            var factory = new SolvesFactory(fileName);
            var droplet = factory.CreateDroplet();

            // act
            var area = droplet.SurfaceArea();

            // answer
            area.Should().Be(expected);
        }
    }
}