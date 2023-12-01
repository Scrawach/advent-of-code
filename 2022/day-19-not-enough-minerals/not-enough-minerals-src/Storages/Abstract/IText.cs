using System.Collections.Generic;

namespace not_enough_minerals_src.Storages.Abstract
{
    public interface IText
    {
        IEnumerable<string> Lines();
    }
}