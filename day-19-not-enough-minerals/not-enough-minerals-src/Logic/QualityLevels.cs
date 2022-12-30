using System.Collections.Generic;
using not_enough_minerals_src.Logic.Abstract;
using not_enough_minerals_src.Storages.Abstract;

namespace not_enough_minerals_src.Logic
{
    public class QualityLevels
    {
        private readonly IBrain _brain;
        private readonly IBlueprintStorage _storage;

        public QualityLevels(IBrain brain, IBlueprintStorage storage)
        {
            _brain = brain;
            _storage = storage;
        }

        public IEnumerable<int> All()
        {
            var index = 0;
            foreach (var blueprint in _storage.All())
            {
                index++;
                var numberOfGeodes = _brain.BestNumberOfGeodes(blueprint);
                yield return numberOfGeodes * index;
            }
        }
    }
}