namespace not_enough_minerals_src.Data
{
    public class ResourcePack
    {
        public int Ore;
        public int Clay;
        public int Obsidian;

        public override string ToString() =>
            $"ore x{Ore}, clay x{Clay}, obsidian x{Obsidian}";
        
        public static ResourcePack operator -(ResourcePack left, ResourcePack right) =>
            new ResourcePack
            {
                Ore = left.Ore - right.Ore,
                Clay = left.Clay - right.Clay,
                Obsidian = left.Obsidian - right.Obsidian
            };
        
        public static ResourcePack operator +(ResourcePack left, ResourcePack right) =>
            new ResourcePack
            {
                Ore = left.Ore + right.Ore,
                Clay = left.Clay + right.Clay,
                Obsidian = left.Obsidian + right.Obsidian
            };
    }
}