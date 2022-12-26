using System.Collections.Generic;
using boiling_boulders_src.Data;

namespace boiling_boulders_src.Storages.Abstract
{
    public interface ICubeStorage
    {
        IEnumerable<Vector3> All();
    }
}