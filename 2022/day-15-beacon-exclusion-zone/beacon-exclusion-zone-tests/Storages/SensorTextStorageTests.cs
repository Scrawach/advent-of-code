using System.Collections;
using beacon_exclusion_zone_src.Data;
using beacon_exclusion_zone_src.Logic;
using beacon_exclusion_zone_src.Storages;
using beacon_exclusion_zone_src.Storages.Abstract;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace beacon_exclusion_zone_tests.Storages
{
    public class SensorTextStorageTests
    {
        [TestCaseSource(nameof(StorageDataSource))]
        public void WhenReadLines_ThenShouldReturnSensor_WithValidProperties(string[] lines, Sensor[] expected)
        {
            // arrange
            var text = Mock.Of<IText>(mock => mock.Lines() == lines);
            var storage = new SensorTextStorage(text);

            // act
            var sensors = storage.All();

            // answer
            sensors.Should().Equal(expected, (left, right) => 
                left.Position == right.Position && left.Radius == right.Radius && left.BeaconPosition == right.BeaconPosition);
        }

        private static IEnumerable StorageDataSource()
        {
            yield return new object[]
            {
                new [] {"Sensor at x=2, y=18: closest beacon is at x=-2, y=15"},
                new [] {new Sensor(new Vector2(2, 18), new Vector2(-2, 15))}
            };
            yield return new object[]
            {
                new []
                {
                    "Sensor at x=2, y=18: closest beacon is at x=-2, y=15", 
                    "Sensor at x=9, y=16: closest beacon is at x=10, y=16", 
                    "Sensor at x=13, y=2: closest beacon is at x=15, y=3"
                },
                new []
                {
                    new Sensor(new Vector2(2, 18), new Vector2(-2, 15)),
                    new Sensor(new Vector2(9, 16), new Vector2(10, 16)),
                    new Sensor(new Vector2(13, 2), new Vector2(15, 3))
                }
            };
        }
    }
}