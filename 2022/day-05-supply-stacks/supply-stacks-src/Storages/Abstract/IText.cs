using System.Collections.Generic;

namespace supply_stacks_src.Storages.Abstract
{
    public interface IText
    {
        IEnumerable<string> Lines();
    }
}