using clamp_cleanup_src.Factory;
using FluentAssertions;
using NUnit.Framework;

namespace clamp_cleanup_tests.Logic
{
    public class CampTests
    {
        [TestCase("example.txt", 2)]
        public void WhenReadExample_ThenShouldTotalContains(string fileName, int expected)
        {
            // arrange
            var factory = new CampFactory(fileName);
            var camp = factory.Create();

            // act
            var count = camp.TotalContainsPair();

            // answer
            count.Should().Be(expected);
        }
        
        [TestCase("example.txt", 4)]
        public void WhenReadExample_ThenShouldTotalOverlap(string fileName, int expected)
        {
            // arrange
            var factory = new CampFactory(fileName);
            var camp = factory.Create();

            // act
            var count = camp.TotalOverlapPairs();

            // answer
            count.Should().Be(expected);
        }
    }
}