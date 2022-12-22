using distress_signal_src.Data;
using FluentAssertions;
using NUnit.Framework;

namespace distress_signal_tests
{
    public class PacketTests
    {
        [TestCase("[3]", "[5]", true)]
        [TestCase("[5]", "[3]", false)]
        public void WhenBothValuesAreIntegers_ThenLowerIntegersShouldComeFirst(string left, string right, bool expected)
        {
            // arrange
            var packet = new Packet(left, right);

            // act
            var isRightOrder = packet.IsRightOrder();

            // answer
            isRightOrder.Should().Be(expected);
        }
    }
}