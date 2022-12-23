using System.Collections.Generic;
using regolith_reservoir_src.Logic.Abstract;

namespace regolith_reservoir_src.Storages.Abstract
{
    public interface ILineTextStorage
    {
        IEnumerable<ILine> All();
    }
}