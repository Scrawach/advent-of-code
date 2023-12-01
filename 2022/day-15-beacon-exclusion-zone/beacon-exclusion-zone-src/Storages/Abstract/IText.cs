using System.Collections.Generic;

namespace beacon_exclusion_zone_src.Storages.Abstract
{
    public interface IText
    {
        IEnumerable<string> Lines();
    }
}