using not_enough_minerals_src.Data;

namespace not_enough_minerals_src.Logic
{
    public readonly struct AmountOfRobots
    {
        public readonly int OreCollecting;
        public readonly int ClayCollecting;
        public readonly int ObsidianCollecting;
        public readonly int GeogeCracking;

        public AmountOfRobots(int oreCollecting, int clayCollecting, int obsidianCollecting, int geogeCracking)
        {
            OreCollecting = oreCollecting;
            ClayCollecting = clayCollecting;
            ObsidianCollecting = obsidianCollecting;
            GeogeCracking = geogeCracking;
        }

        public AmountOfRobots AddOre() =>
            this + new AmountOfRobots(1, 0, 0, 0);

        public AmountOfRobots AddClay() =>
            this + new AmountOfRobots(0, 1, 0, 0);

        public AmountOfRobots AddObsidian() =>
            this + new AmountOfRobots(0, 0, 1, 0);

        public AmountOfRobots AddGeoge() =>
            this + new AmountOfRobots(0, 0, 0, 1);

        public ResourcePack Mining() =>
            new ResourcePack()
            {
                Ore = OreCollecting,
                Clay = ClayCollecting,
                Obsidian = ObsidianCollecting,
                Geodes = GeogeCracking
            };

        public static AmountOfRobots operator +(AmountOfRobots left, AmountOfRobots right) =>
            new AmountOfRobots
            (
                left.OreCollecting + right.OreCollecting,
                left.ClayCollecting + right.ClayCollecting,
                left.ObsidianCollecting + right.ObsidianCollecting,
                left.GeogeCracking + right.GeogeCracking
            );
    }
}