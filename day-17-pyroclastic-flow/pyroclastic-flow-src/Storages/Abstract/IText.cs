using System.Collections.Generic;

namespace pyroclastic_flow_src.Storages.Abstract
{
    public interface IText
    {
        IEnumerable<string> Lines();
    }
}