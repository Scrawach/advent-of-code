using System.Collections.Generic;

namespace distress_signal_src.Storages.Abstract
{
    public interface IText
    {
        IEnumerable<string> Lines();
    }
}