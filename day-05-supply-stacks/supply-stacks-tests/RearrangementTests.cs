using FluentAssertions;
using NUnit.Framework;
using supply_stacks_src.Factory;

namespace supply_stacks_tests
{
    public class RearrangementTests
    {
        [TestCase("example.txt", "CMZ")]
        public void WhenReadFromTestFile_WithDefaultMover_ThenShouldReturnExpectedResult(string fileName, string expected)
        {
            // arrange
            var factory = new RearrangementFactory(fileName);
            var rearrangement = factory.CreateWithDefaultMover();

            // act
            var result = rearrangement.WorkResult();

            // answer
            result.Should().Be(expected);
        }
        
        [TestCase("example.txt", "MCD")]
        public void WhenReadFromTestFile_WithMover9001_ThenShouldReturnExpectedResult(string fileName, string expected)
        {
            // arrange
            var factory = new RearrangementFactory(fileName);
            var rearrangement = factory.CreateWithMover9001();

            // act
            var result = rearrangement.WorkResult();

            // answer
            result.Should().Be(expected);
        }
    }
}