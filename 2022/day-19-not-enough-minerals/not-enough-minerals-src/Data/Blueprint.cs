namespace not_enough_minerals_src.Data
{
    public class Blueprint
    {
        public ResourcePack OreRobotCost;
        public ResourcePack ClayRobotCost;
        public ResourcePack ObsidianRobotCost;
        public ResourcePack GeodeRobotCost;

        public override string ToString() =>
            $"Blueprint: Each ore robot costs {OreRobotCost}. Each clay robot costs {ClayRobotCost}. Each obsidian robot costs {ObsidianRobotCost}. Each geode robot costs {GeodeRobotCost}.";
    }
}