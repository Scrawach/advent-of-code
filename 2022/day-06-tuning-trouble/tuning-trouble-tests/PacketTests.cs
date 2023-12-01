using System.Collections;
using FluentAssertions;
using NUnit.Framework;
using tuning_trouble_src;

namespace tuning_trouble_tests
{
    public class PacketTests
    {
        [TestCase("abcda", 4,4)]
        [TestCase("aabcd", 4,5)]
        [TestCaseSource(typeof(PacketDataSource))]
        public void WhenTakeMarker_ThenShouldReturnProcessedSymbolsCount_BeforeFindUniqueSubsequence(string sequence, int uniqueLength, int expected)
        {
            // arrange
            var packet = new Packet(sequence);

            // act
            var result = packet.Marker(uniqueLength);

            // answer
            result.Should().Be(expected);
        }

        private class PacketDataSource : IEnumerable
        {
            private readonly object[][] _testCases = 
            {
                new object[] {"mjqjpqmgbljsphdztnvjfqwrcgsmlb", 4, 7},
                new object[] {"bvwbjplbgvbhsrlpgdmjqwftvncz", 4, 5},
                new object[] {"nppdvjthqldpwncqszvftbrmjlhg", 4, 6},
                new object[] {"nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 4, 10},
                new object[] {"zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 4, 11},
                new object[] {"mjqjpqmgbljsphdztnvjfqwrcgsmlb", 14, 19},
                new object[] {"bvwbjplbgvbhsrlpgdmjqwftvncz", 14, 23},
                new object[] {"nppdvjthqldpwncqszvftbrmjlhg", 14, 23},
                new object[] {"nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 14, 29},
                new object[] {"zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 14, 26},
            };
            
            public IEnumerator GetEnumerator()
            {
                foreach (var testCase in _testCases)
                    yield return testCase;
            }
        }
    }
}