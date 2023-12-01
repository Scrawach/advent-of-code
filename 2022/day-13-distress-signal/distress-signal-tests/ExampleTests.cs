using distress_signal_src.Factory;
using FluentAssertions;
using NUnit.Framework;

namespace distress_signal_tests
{
    public class ExampleTests
    {
        [TestCase("example.txt", 13)]
        public void WhenReadPackets_FromExample_ThenShouldReturnExpectedResult(string fileName, int expected)
        {
            // arrange
            var factory = new SolvesFactory(fileName);
            var signal = factory.CreateSignal();

            // act
            var sum = signal.SumOfIndicesRightPairs();

            // answer
            sum.Should().Be(expected);
        }

        [TestCase("example.txt", 140)]
        public void WhenReadPackets_FromExample_ThenShouldReturnExpected_DecoderKey(string fileName, int expected)
        {
            // arrange
            var factory = new SolvesFactory(fileName);
            var decoder = factory.CreateDecoder();

            // act
            var key = decoder.Key();

            // answer
            key.Should().Be(expected);
        }
    }
}