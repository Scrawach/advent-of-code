using System.Collections;
using System.Collections.Generic;
using System.Linq;
using distress_signal_src.Comparer;
using distress_signal_src.Storages;
using distress_signal_src.Storages.Abstract;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace distress_signal_tests.Storages
{
    public class PacketTextStorageTests
    {
        [TestCaseSource(nameof(PacketStorageDataSource))]
        public void WhenReadLines_ThenShouldReturnPackets_WithExpectedOrder(string[] lines, bool expected)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == lines);
            var storage = new PacketTextStorage(mockedText, new RightOrderComparer());

            // act
            var packet = storage.All().First();
            var isRightOrder = packet.IsRightOrder();

            // answer
            isRightOrder.Should().Be(expected);
        }

        private static IEnumerable PacketStorageDataSource()
        {
            yield return new object[]
            {
                new[]
                {
                    "[7,7,7,7]",
                    "[7,7,7]"
                },
                false
            };
            yield return new object[]
            {
                new[]
                {
                    "[7,7,7]",
                    "[7,7,7,7]"
                },
                true
            };
        }
    }
}