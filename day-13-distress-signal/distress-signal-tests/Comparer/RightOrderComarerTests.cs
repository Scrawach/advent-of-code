using distress_signal_src.Comparer;
using FluentAssertions;
using NUnit.Framework;

namespace distress_signal_tests.Comparer
{
    public class PacketTests
    {
        [TestCase("[3]", "[5]", -1)]
        [TestCase("[5]", "[3]", 1)]
        [TestCase("[1, 3, 1]", "[1, 5, 1]", -1)]
        [TestCase("[1, 5, 1]", "[1, 3, 1]", 1)]
        public void WhenBothValuesAreIntegers_ThenLowerIntegersShouldComeFirst(string left, string right, int expected)
        {
            // arrange
            var comparer = new RightOrderComparer();

            // act
            var isRightOrder = comparer.Compare(left, right);

            // answer
            isRightOrder.Should().Be(expected);
        }

        [TestCase("[7,7,7,7]", "[7,7,7]", 1)]
        [TestCase("[7,7,7]", "[7,7,7,7]", -1)]
        public void WhenBothValuesAreLists_ThenShouldCompareIt_WhileRightListRunOfItemsFirst(string left, string right, int expected)
        {
            // arrange
            var comparer = new RightOrderComparer();

            // act
            var isRightOrder = comparer.Compare(left, right);

            // answer
            isRightOrder.Should().Be(expected);
        }

        [TestCase("[[1],[2,3,4]]", "[[1],4]", -1)]
        [TestCase("[[1],4]", "[[1],[2,3,4]]", 1)]
        public void WhenOneValueIsAnInteger_ThenShouldConvertItToList_AndRetry(string left, string right, int expected)
        {
            // arrange
            var comparer = new RightOrderComparer();

            // act
            var isRightOrder = comparer.Compare(left, right);

            // answer
            isRightOrder.Should().Be(expected);
        }

        [TestCase("[[[]]]", "[[]]", 1)]
        [TestCase("[[]]", "[[[]]]", -1)]
        public void WhenEmptyLists_ThenRightList_ShouldRunOfItemsFirst(string left, string right, int expected)
        {
            // arrange
            var comparer = new RightOrderComparer();

            // act
            var isRightOrder = comparer.Compare(left, right);

            // answer
            isRightOrder.Should().Be(expected);
        }

        [TestCase("[9]", "[[8,7,6]]", 1)]
        [TestCase("[[4,4],4,4]", "[[4,4],4,4,4]", -1)]
        [TestCase("[]", "[3]", -1)]
        [TestCase("[1,[2,[3,[4,[5,6,7]]]],8,9]", "[1,[2,[3,[4,[5,6,0]]]],8,9]", 1)]
        public void WhenOtherExampleCases_ThenShouldReturnExpected(string left, string right, int expected)
        {
            // arrange
            var comparer = new RightOrderComparer();

            // act
            var isRightOrder = comparer.Compare(left, right);

            // answer
            isRightOrder.Should().Be(expected);
        }

        [TestCase("[1,1,1]","[1,1,1]")]
        public void WhenCompareEqualsLines_ThenShouldReturnZero(string left, string right)
        {
            // arrange
            var comparer = new RightOrderComparer();

            // act
            var isRightOrder = comparer.Compare(left, right);

            // answer
            isRightOrder.Should().Be(0);
        }
    }
}