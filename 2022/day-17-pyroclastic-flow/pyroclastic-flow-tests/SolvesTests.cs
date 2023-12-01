using FluentAssertions;
using NUnit.Framework;
using pyroclastic_flow_src.Factory;

namespace pyroclastic_flow_tests
{
    public class SolvesTests
    {
        [TestCase("example.txt", "shapes.txt", 3068)]
        public void WhenTall2022Rocks_ThenShouldReturnExpectedHeight_FromExample(string inputFileName, string shapesFileName, long expected)
        {
            // arrange
            var factory = new SolvesFactory(inputFileName, shapesFileName);
            var tunnel = factory.CreateTunnel();

            // act
            var height = tunnel.AddRocks(2022).Height;

            // answer
            height.Should().Be(expected);
        }
    }
}