using System.Collections.Generic;

namespace clamp_cleanup_src.Storages.Abstract
{
    public interface IText
    {
        IEnumerable<string> Lines();
    }
}