using System.Collections.Generic;

namespace grove_positioning_system_src.Logic.Abstract
{
    public interface IItemStorage
    {
        IEnumerable<Item> All();
    }
}