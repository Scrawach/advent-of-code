using distress_signal_src.Data;
using FluentAssertions;
using NUnit.Framework;

namespace distress_signal_tests
{
    public class PacketTests
    {
        [TestCase("[3]", "[5]", true)]
        [TestCase("[5]", "[3]", false)]
        [TestCase("[1, 3, 1]", "[1, 5, 1]", true)]
        [TestCase("[1, 5, 1]", "[1, 3, 1]", false)]
        public void WhenBothValuesAreIntegers_ThenLowerIntegersShouldComeFirst(string left, string right, bool expected)
        {
            // arrange
            var packet = new Packet(left, right);

            // act
            var isRightOrder = packet.IsRightOrder();

            // answer
            isRightOrder.Should().Be(expected);
        }

        [TestCase("[7,7,7,7]", "[7,7,7]", false)]
        [TestCase("[7,7,7]", "[7,7,7,7]", true)]
        public void WhenBothValuesAreLists_ThenShouldCompareIt_WhileRightListRunOfItemsFirst(string left, string right, bool expected)
        {
            // arrange
            var packet = new Packet(left, right);

            // act
            var isRightOrder = packet.IsRightOrder();

            // answer
            isRightOrder.Should().Be(expected);
        }

        [TestCase("[[1],[2,3,4]]", "[[1],4]", true)]
        [TestCase("[[1],4]", "[[1],[2,3,4]]", false)]
        public void WhenOneValueIsAnInteger_ThenShouldConvertItToList_AndRetry(string left, string right, bool expected)
        {
            // arrange
            var packet = new Packet(left, right);

            // act
            var isRightOrder = packet.IsRightOrder();

            // answer
            isRightOrder.Should().Be(expected);
        }

        [TestCase("[[[]]]", "[[]]", false)]
        [TestCase("[[]]", "[[[]]]", true)]
        public void WhenEmptyLists_ThenRightList_ShouldRunOfItemsFirst(string left, string right, bool expected)
        {
            // arrange
            var packet = new Packet(left, right);

            // act
            var isRightOrder = packet.IsRightOrder();

            // answer
            isRightOrder.Should().Be(expected);
        }

        [TestCase("[9]", "[[8,7,6]]", false)]
        [TestCase("[[4,4],4,4]", "[[4,4],4,4,4]", true)]
        [TestCase("[]", "[3]", true)]
        [TestCase("[1,[2,[3,[4,[5,6,7]]]],8,9]", "[1,[2,[3,[4,[5,6,0]]]],8,9]", false)]
        public void WhenOtherExampleCases_ThenShouldReturnExpected(string left, string right, bool expected)
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