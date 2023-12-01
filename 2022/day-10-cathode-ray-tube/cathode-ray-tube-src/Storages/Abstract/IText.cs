using System.Collections.Generic;

namespace cathode_ray_tube_src.Storages.Abstract
{
    public interface IText
    {
        IEnumerable<string> Lines();
    }
}