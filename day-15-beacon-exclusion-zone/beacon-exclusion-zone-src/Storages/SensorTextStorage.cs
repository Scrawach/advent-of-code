using System.Collections.Generic;
using System.Text.RegularExpressions;
using beacon_exclusion_zone_src.Data;
using beacon_exclusion_zone_src.Extensions;
using beacon_exclusion_zone_src.Logic;
using beacon_exclusion_zone_src.Storages.Abstract;

namespace beacon_exclusion_zone_src.Storages
{
    public class SensorTextStorage : ISensorStorage
    {
        private readonly IText _text;

        public SensorTextStorage(IText text) => 
            _text = text;
        
        public IEnumerable<Sensor> All()
        {
            const string onlyNumberPattern = "(-?\\d+)";
            var regex = new Regex(onlyNumberPattern);
            
            foreach (var line in _text.Lines())
            {
                var (sensorPosition, beaconPosition) = Parse(regex.Matches(line));
                var sensorRadius = sensorPosition.ManhattanDistance(to: beaconPosition);
                yield return new Sensor(sensorPosition, sensorRadius);
            }
        }

        private static (Vector2 sensor, Vector2 beacon) Parse(MatchCollection matches)
        {
            var sensor = new Vector2(int.Parse(matches[0].Value), int.Parse(matches[1].Value));
            var beacon = new Vector2(int.Parse(matches[2].Value), int.Parse(matches[3].Value));
            return (sensor, beacon);
        }
    }
}