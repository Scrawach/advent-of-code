using System.Collections.Generic;
using rucksack_reorganization_src.Logic.Abstract;

namespace rucksack_reorganization_src.Storages.Abstract
{
    public interface IRucksackStorage
    {
        IEnumerable<IRucksack> All();
    }
}