using System.Collections.Generic;
using not_enough_minerals_src.Data;

namespace not_enough_minerals_src.Storages.Abstract
{
    public interface IBlueprintStorage
    {
        IEnumerable<Blueprint> All();
    }
}