using System.Collections.Generic;

namespace rucksack_reorganization_src.Storages.Abstract
{
    public interface IText
    {
        IEnumerable<string> Lines();
    }
}