using System.Collections.Generic;

namespace no_space_left_on_device_src.Storages.Abstract
{
    public interface IText
    {
        IEnumerable<string> Lines();
    }
}