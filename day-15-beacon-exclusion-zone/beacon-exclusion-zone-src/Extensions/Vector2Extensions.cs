using System;
using beacon_exclusion_zone_src.Data;

namespace beacon_exclusion_zone_src.Extensions
{
    public static class Vector2Extensions
    {
        public static int ManhattanDistance(this Vector2 self, Vector2 to) => 
            Math.Abs(self.X - to.X) + Math.Abs(self.Y - to.Y);
    }
}