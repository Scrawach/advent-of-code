using System.Collections.Generic;
using pyroclastic_flow_src.Logic;

namespace pyroclastic_flow_src.Storages.Abstract
{
    public interface IShapeStorage
    {
        IEnumerable<Cell[,]> All();
    }
}