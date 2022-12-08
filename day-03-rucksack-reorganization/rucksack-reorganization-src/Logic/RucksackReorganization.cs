using System.Linq;
using rucksack_reorganization_src.Logic.Abstract;
using rucksack_reorganization_src.Storages.Abstract;

namespace rucksack_reorganization_src.Logic
{
    public class RucksackReorganization
    {
        private readonly IRucksackStorage _storage;
        private readonly IPriority _priority;

        public RucksackReorganization(IRucksackStorage storage, IPriority priority)
        {
            _storage = storage;
            _priority = priority;
        }

        public int TotalPriorityScore() =>
            _storage.All()
                .Select(rucksack => rucksack.RepeatedSymbol())
                .Sum(_priority.Convert);
    }
}