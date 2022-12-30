using System.Collections.Generic;

namespace grove_positioning_system_src.Storages.Abstract
{
    public interface IText
    {
        IEnumerable<string> Lines();
    }
}