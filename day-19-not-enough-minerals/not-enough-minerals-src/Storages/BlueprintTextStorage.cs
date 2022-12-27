using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using not_enough_minerals_src.Data;
using not_enough_minerals_src.Storages.Abstract;

namespace not_enough_minerals_src.Storages
{
    public class BlueprintTextStorage : IBlueprintStorage
    {
        private readonly IText _text;

        public BlueprintTextStorage(IText text) =>
            _text = text;
        
        public IEnumerable<Blueprint> All()
        {
            const string resourcePattern = @"\d+.\w+";
            var regex = new Regex(resourcePattern);

            foreach (var line in _text.Lines())
            {
                var eachCost = line.Split("Each").Skip(1);

                var resources = eachCost
                    .Select(costLine => ParseResourcePack(regex.Matches(costLine)))
                    .ToArray();

                yield return new Blueprint
                {
                    OreRobotCost = resources[0],
                    ClayRobotCost = resources[1],
                    ObsidianRobotCost = resources[2],
                    GeodeRobotCost = resources[3]
                };
            }
        }
        
        private ResourcePack ParseResourcePack(IEnumerable matches)
        {
            var resourcePack = new ResourcePack();
            
            foreach (Match match in matches)
            {
                var (type, amount) = ParseResource(match.Value);
                AddToResourcePack(resourcePack, type, amount);
            }
            
            return resourcePack;
        }

        private static (string type, int amount) ParseResource(string line)
        {
            var data = line.Split(' ');
            var amount = data[0];
            var type = data[1];
            return (type, int.Parse(amount));
        }

        private void AddToResourcePack(ResourcePack resourcePack, string type, int amount)
        {
            const string ore = "ore";
            const string clay = "clay";
            const string obsidian = "obsidian";
            
            switch (type)
            {
                case ore:
                    resourcePack.Ore += amount;
                    break;
                case clay:
                    resourcePack.Clay += amount;
                    break;
                case obsidian:
                    resourcePack.Obsidian += amount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(AddToResourcePack));
            }
        }
    }
}