using System.Collections.Generic;
using beacon_exclusion_zone_src.Logic;

namespace beacon_exclusion_zone_src.Storages.Abstract
{
    public interface ISensorStorage
    {
        IEnumerable<Sensor> All();
    }
}