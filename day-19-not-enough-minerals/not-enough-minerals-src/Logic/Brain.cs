using System.Linq;
using not_enough_minerals_src.Data;
using not_enough_minerals_src.Logic.Abstract;

namespace not_enough_minerals_src.Logic
{
    public class Brain : IBrain
    {
        private readonly int _simulatedMinutes;

        public Brain(int simulatedMinutes) =>
            _simulatedMinutes = simulatedMinutes;

        private int _requiredOreMax;
        private int _requiredClayMax;

        public int BestNumberOfGeodes(Blueprint forBlueprint)
        {
            _requiredOreMax = new[] {forBlueprint.OreRobotCost.Ore, forBlueprint.ClayRobotCost.Ore, forBlueprint.ObsidianRobotCost.Ore, forBlueprint.GeodeRobotCost.Ore}.Max();
            _requiredClayMax = new[] {forBlueprint.OreRobotCost.Clay, forBlueprint.ClayRobotCost.Clay, forBlueprint.ObsidianRobotCost.Clay, forBlueprint.GeodeRobotCost.Clay}.Max();
            return Bruteforce(0, new AmountOfRobots(1, 0, 0, 0), new ResourcePack(), forBlueprint);
        }

        private int Bruteforce(int elapsedMinutes, AmountOfRobots robots, ResourcePack resources, Blueprint cost)
        {
            if (elapsedMinutes >= _simulatedMinutes)
                return resources.Geodes;

            var nextResources = robots.Mining() + resources;
            var timeStep = elapsedMinutes + 1;

            var hasResourcesForOreCollectingRobot = resources >= cost.OreRobotCost && robots.OreCollecting < _requiredOreMax;
            var hasResourcesForClayCollectingRobot = resources >= cost.ClayRobotCost && robots.ClayCollecting < _requiredClayMax;
            var hasResourcesForObsidianCollectingRobot = resources >= cost.ObsidianRobotCost && robots.ObsidianCollecting < cost.GeodeRobotCost.Obsidian;
            var hasResourcesForGeogeCrackingRobot = resources >= cost.GeodeRobotCost;
            
            var action = new int[5];

            if (hasResourcesForGeogeCrackingRobot)
                action[4] = Bruteforce(timeStep, robots.AddGeoge(), nextResources - cost.GeodeRobotCost, cost);
            
            if (hasResourcesForObsidianCollectingRobot)
                action[3] = Bruteforce(timeStep, robots.AddObsidian(), nextResources - cost.ObsidianRobotCost, cost);

            if (hasResourcesForClayCollectingRobot)
                action[2] = Bruteforce(timeStep, robots.AddClay(), nextResources - cost.ClayRobotCost, cost);

            if (hasResourcesForOreCollectingRobot)
                action[1] = Bruteforce(timeStep, robots.AddOre(), nextResources - cost.OreRobotCost, cost);

            if (!hasResourcesForGeogeCrackingRobot && !hasResourcesForObsidianCollectingRobot)
                action[0] = Bruteforce(timeStep, robots, nextResources, cost);

            return action.Max();
        }
    }
}