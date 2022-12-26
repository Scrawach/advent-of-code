using System.Collections.Generic;
using System.Linq;
using beacon_exclusion_zone_src.Data;
using beacon_exclusion_zone_src.Extensions;

namespace beacon_exclusion_zone_src.Logic
{
    public class PositionsWithoutBeacon
    {
        private readonly int _row;
        private readonly IReadOnlyCollection<Sensor> _sensors;

        public PositionsWithoutBeacon(int row, IReadOnlyCollection<Sensor> sensors)
        {
            _row = row;
            _sensors = sensors;
        }

        public int TotalCount()
        {
            var radius = _sensors.Max(sensor => sensor.Radius);
            var left = _sensors.Min(sensor => sensor.Position.X);
            var right = _sensors.Max(sensor => sensor.Position.X);
            var range = new Vector2(left - radius, right + radius);
            
            return FindAllAvailablePositions(range, _row)
                .Count();
        }

        private IEnumerable<Vector2> FindAllAvailablePositions(Vector2 range, int row) =>
            from index in Enumerable.Range(range.X, range.Y - range.X)
            let checkedPosition = new Vector2(index, row)
            where _sensors.Any(sensor => sensor.Position.ManhattanDistance(to: checkedPosition) <= sensor.Radius
                                         && sensor.BeaconPosition != checkedPosition)
            select checkedPosition;
    }
}