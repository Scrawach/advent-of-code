using beacon_exclusion_zone_src.Data;
using beacon_exclusion_zone_src.Extensions;

namespace beacon_exclusion_zone_src.Logic
{
    public class Sensor
    {
        public Sensor(Vector2 position, Vector2 beaconPosition)
        {
            Position = position;
            BeaconPosition = beaconPosition;
        }
        
        public Vector2 Position { get; }
        
        public Vector2 BeaconPosition { get; }

        public int Radius => Position.ManhattanDistance(BeaconPosition);
    }
}