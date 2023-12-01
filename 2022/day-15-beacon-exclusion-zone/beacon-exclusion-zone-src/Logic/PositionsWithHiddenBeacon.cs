using System;
using System.Collections.Generic;
using System.Linq;
using beacon_exclusion_zone_src.Data;
using beacon_exclusion_zone_src.Extensions;

namespace beacon_exclusion_zone_src.Logic
{
    public class PositionsWithHiddenBeacon
    {
        private readonly Vector2 _min;
        private readonly Vector2 _max;
        private readonly IReadOnlyCollection<Sensor> _sensors;

        public PositionsWithHiddenBeacon(Vector2 min, Vector2 max, IReadOnlyCollection<Sensor> sensors)
        {
            _min = min;
            _max = max;
            _sensors = sensors;
        }

        public long TuningFrequency()
        {
            var hiddenBeacon = All().First();
            return 4000000L * hiddenBeacon.X + hiddenBeacon.Y;
        }

        private IEnumerable<Vector2> All()
        {
            for (var y = _min.Y; y <= _max.Y; y++)
            for (var x = _min.X; x < _max.X;)
            {
                var checkedPosition = new Vector2(x, y);

                if (IsOverlappedBySensor(checkedPosition, out var sensor))
                    x = EndOfOverlappingPosition(sensor, y);
                else
                    yield return checkedPosition;
            }
        }

        private static int EndOfOverlappingPosition(Sensor sensor, int row) =>
            sensor.Position.X + sensor.Radius - Math.Abs(sensor.Position.Y - row) + 1;

        private bool IsOverlappedBySensor(Vector2 position, out Sensor sensor)
        {
            sensor = _sensors.FirstOrDefault(s => position.ManhattanDistance(s.Position) <= s.Radius);
            return sensor != null;
        }
    }
}