using System.Collections.Generic;

namespace boiling_boulders_src.Storages.Abstract
{
    public interface IText
    {
        IEnumerable<string> Lines();
    }
}