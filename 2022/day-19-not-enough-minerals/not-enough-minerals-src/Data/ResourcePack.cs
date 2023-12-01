namespace not_enough_minerals_src.Data
{
    public class ResourcePack
    {
        public int Ore;
        public int Clay;
        public int Obsidian;
        public int Geodes;

        public override string ToString() =>
            $"ore x{Ore}, clay x{Clay}, obsidian x{Obsidian}";
        
        public static ResourcePack operator -(ResourcePack left, ResourcePack right) =>
            new ResourcePack
            {
                Ore = left.Ore - right.Ore,
                Clay = left.Clay - right.Clay,
                Obsidian = left.Obsidian - right.Obsidian,
                Geodes = left.Geodes - right.Geodes
            };
        
        public static ResourcePack operator +(ResourcePack left, ResourcePack right) =>
            new ResourcePack
            {
                Ore = left.Ore + right.Ore,
                Clay = left.Clay + right.Clay,
                Obsidian = left.Obsidian + right.Obsidian,
                Geodes = left.Geodes + right.Geodes
            };

        public static bool operator >=(ResourcePack left, ResourcePack right) =>
            left.Ore >= right.Ore && left.Clay >= right.Clay && left.Obsidian >= right.Obsidian && left.Geodes >= right.Geodes;

        public static bool operator <=(ResourcePack left, ResourcePack right) =>
            right >= left;
    }
}