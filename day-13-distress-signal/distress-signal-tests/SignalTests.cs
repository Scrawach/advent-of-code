using System.Collections.Generic;
using distress_signal_src;
using distress_signal_src.Data;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace distress_signal_tests
{
    public class SignalTests
    {
        [Test]
        public void WhenHasNotPackets_ThenShouldReturnZero()
        {
            // arrange
            var signal = new Signal();

            // act
            var sum = signal.SumOfIndicesRightPairs();

            // answer
            sum.Should().Be(0);
        }
        
        [Test]
        public void WhenHasOnlyOnePacket_WithCorrectOrder_ThenShouldReturnOne()
        {
            // arrange
            var mockedPacket = Mock.Of<IPacket>(mock => mock.IsRightOrder());
            var signal = new Signal(mockedPacket);

            // act
            var sum = signal.SumOfIndicesRightPairs();

            // answer
            sum.Should().Be(1);
        }

        [Test]
        public void WhenHasOnlyOnePacked_WithIncorrectOrder_ThenShouldReturnZero()
        {
            // arrange
            var mockedPacket = Mock.Of<IPacket>(mock => !mock.IsRightOrder());
            var signal = new Signal(mockedPacket);

            // act
            var sum = signal.SumOfIndicesRightPairs();

            // answer
            sum.Should().Be(0);
        }
        
        [TestCase(1, 1)]
        [TestCase(2, 3)]
        [TestCase(3, 6)]
        [TestCase(4, 10)]
        [TestCase(5, 15)]
        public void WhenPacketPairsHasCorrectOrder_ThenShouldReturnSumOfIndices(int correctPackets, int expectedSum)
        {
            // arrange
            var packets = new List<IPacket>();
            for (var i = 0; i < correctPackets; i++)
                packets.Add(Mock.Of<IPacket>(mock => mock.IsRightOrder()));

            var signal = new Signal(packets.ToArray());
            
            // act
            var sum = signal.SumOfIndicesRightPairs();

            // answer
            sum.Should().Be(expectedSum);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(10)]
        [TestCase(42)]
        public void WhenPacketPairsHasIncorrectOrder_ThenShouldReturnZero(int incorrectPackets)
        {
            // arrange
            var packets = new List<IPacket>();
            for (var i = 0; i < incorrectPackets; i++)
                packets.Add(Mock.Of<IPacket>(mock => !mock.IsRightOrder()));

            var signal = new Signal(packets.ToArray());
            
            // act
            var sum = signal.SumOfIndicesRightPairs();

            // answer
            sum.Should().Be(0);
        }
    }
}