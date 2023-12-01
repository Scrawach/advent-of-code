using System.Collections;
using System.Linq;
using FluentAssertions;
using Moq;
using not_enough_minerals_src.Data;
using not_enough_minerals_src.Storages;
using not_enough_minerals_src.Storages.Abstract;
using NUnit.Framework;

namespace not_enough_minerals_tests.Storages
{
    public class BlueprintTextStorageTests
    {
        [TestCaseSource(nameof(BlueprintDaraSource))]
        public void WhenReadLine_ThenShouldReturnBlueprint(string inputLine, Blueprint expected)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == new[] {inputLine});
            var storage = new BlueprintTextStorage(mockedText);

            // act
            var firstBlueprint = storage.All().First();

            // answer
            firstBlueprint.Should().BeEquivalentTo(expected);
        }

        [TestCaseSource(nameof(FewBlueprintDaraSource))]
        public void WhenReadFewLines_ThenShouldReturnFewBlueprints(string[] lines, Blueprint[] expected)
        {
            // arrange
            var mockedText = Mock.Of<IText>(mock => mock.Lines() == lines);
            var storage = new BlueprintTextStorage(mockedText);

            // act
            var blueprints = storage.All().ToArray();

            // answer
            blueprints.Should().BeEquivalentTo(expected);
        }

        private static IEnumerable BlueprintDaraSource()
        {
            yield return new object[]
            {
                "Blueprint 0: Each ore robot costs 1 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 4 clay. Each geode robot costs 5 ore and 6 obsidian.",
                new Blueprint
                {
                    OreRobotCost = new ResourcePack {Ore = 1},
                    ClayRobotCost = new ResourcePack {Ore = 2},
                    ObsidianRobotCost = new ResourcePack {Ore = 3, Clay = 4},
                    GeodeRobotCost = new ResourcePack {Ore = 5, Obsidian = 6}
                }
            };
            yield return new object[]
            {
                "Blueprint 1: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 17 clay. Each geode robot costs 2 ore and 13 obsidian.",
                new Blueprint
                {
                    OreRobotCost = new ResourcePack {Ore = 3},
                    ClayRobotCost = new ResourcePack {Ore = 3},
                    ObsidianRobotCost = new ResourcePack {Ore = 3, Clay = 17},
                    GeodeRobotCost = new ResourcePack {Ore = 2, Obsidian = 13}
                }
            };
            yield return new object[]
            {
                "Blueprint ??: Each ore robot costs 999 ore. Each clay robot costs 999 ore. Each obsidian robot costs 999 ore and 999 clay. Each geode robot costs 999 ore and 999 obsidian.",
                new Blueprint
                {
                    OreRobotCost = new ResourcePack {Ore = 999},
                    ClayRobotCost = new ResourcePack {Ore = 999},
                    ObsidianRobotCost = new ResourcePack {Ore = 999, Clay = 999},
                    GeodeRobotCost = new ResourcePack {Ore = 999, Obsidian = 999}
                }
            };
        }
        
        private static IEnumerable FewBlueprintDaraSource()
        {
            yield return new object[]
            {
                new[] 
                {
                    "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 8 clay. Each geode robot costs 2 ore and 18 obsidian.",
                    "Blueprint 2: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 19 clay. Each geode robot costs 4 ore and 15 obsidian.",
                    "Blueprint 3: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 17 clay. Each geode robot costs 3 ore and 8 obsidian.",
                },
                new []
                {
                    new Blueprint
                    {
                        OreRobotCost = new ResourcePack {Ore = 4}, 
                        ClayRobotCost = new ResourcePack {Ore = 4}, 
                        ObsidianRobotCost = new ResourcePack {Ore = 4, Clay = 8}, 
                        GeodeRobotCost = new ResourcePack {Ore = 2, Obsidian = 18}
                    },
                    new Blueprint
                    {
                        OreRobotCost = new ResourcePack {Ore = 4}, 
                        ClayRobotCost = new ResourcePack {Ore = 4}, 
                        ObsidianRobotCost = new ResourcePack {Ore = 3, Clay = 19}, 
                        GeodeRobotCost = new ResourcePack {Ore = 4, Obsidian = 15}
                    },
                    new Blueprint
                    {
                        OreRobotCost = new ResourcePack {Ore = 3}, 
                        ClayRobotCost = new ResourcePack {Ore = 4}, 
                        ObsidianRobotCost = new ResourcePack {Ore = 3, Clay = 17}, 
                        GeodeRobotCost = new ResourcePack {Ore = 3, Obsidian = 8}
                    }
                }
            };
        }
    }
}