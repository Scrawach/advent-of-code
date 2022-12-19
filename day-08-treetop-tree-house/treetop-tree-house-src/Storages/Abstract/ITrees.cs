using System.Collections.Generic;

namespace treetop_tree_house_src.Storages.Abstract
{
    public interface ITrees
    {
        IEnumerable<Tree> All();
        IEnumerable<IEnumerable<Tree>> AllLinesFrom(Tree origin);
    }
}