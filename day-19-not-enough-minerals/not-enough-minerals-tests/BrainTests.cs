using System.Collections;
using FluentAssertions;
using Moq;
using not_enough_minerals_src;
using not_enough_minerals_src.Data;
using not_enough_minerals_src.Logic;
using NUnit.Framework;

namespace not_enough_minerals_tests
{
    public class BrainTests
    {
        [TestCaseSource(nameof(ExampleBlueprintDataSource))]
        public void WhenBlueprint_ThenShouldCalculateBestNumberOfGeodes(Blueprint blueprint, int expected)
        {
            // arrange
            var brain = new Brain(24);

            // act
            var numberOfGeodes = brain.BestNumberOfGeodes(blueprint);

            // answer
            numberOfGeodes.Should().Be(expected);
        }

        private static IEnumerable ExampleBlueprintDataSource()
        {
            yield return new object[]
            {
                new Blueprint
                {
                    OreRobotCost = new ResourcePack { Ore = 4},
                    ClayRobotCost = new ResourcePack { Ore = 2},
                    ObsidianRobotCost = new ResourcePack {Ore = 3, Clay = 14},
                    GeodeRobotCost = new ResourcePack {Ore = 2, Obsidian = 7}
                },
                9
            };
        }
    }
}