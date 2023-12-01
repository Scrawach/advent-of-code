using System.Collections.Generic;

namespace treetop_tree_house_src.Storages.Abstract
{
    public interface IText
    {
        IEnumerable<string> Lines();
    }
}