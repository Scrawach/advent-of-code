using System.Collections.Generic;

namespace rope_bridge_src.Storages.Abstract
{
    public interface IText
    {
        IEnumerable<string> All();
    }
}