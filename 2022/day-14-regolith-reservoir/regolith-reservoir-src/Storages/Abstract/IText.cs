using System.Collections.Generic;

namespace regolith_reservoir_src.Storages.Abstract
{
    public interface IText
    {
        IEnumerable<string> Lines();
    }
}