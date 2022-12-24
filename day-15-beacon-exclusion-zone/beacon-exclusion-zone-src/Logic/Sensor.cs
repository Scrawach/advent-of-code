using beacon_exclusion_zone_src.Data;

namespace beacon_exclusion_zone_src.Logic
{
    public class Sensor
    {
        public Sensor(Vector2 position, int radius)
        {
            Position = position;
            Radius = radius;
        }
        
        public Vector2 Position { get; }
        
        public int Radius { get; }
    }
}