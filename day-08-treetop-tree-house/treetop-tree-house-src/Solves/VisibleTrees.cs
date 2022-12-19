using System.Collections.Generic;
using System.Linq;
using treetop_tree_house_src.Storages;
using treetop_tree_house_src.Storages.Abstract;

namespace treetop_tree_house_src.Solves
{
    public class VisibleTrees
    {
        private readonly ITrees _trees;

        public VisibleTrees(ITrees trees) =>
            _trees = trees;

        public int TotalCount() =>
            _trees.All().Count(IsVisible);

        private bool IsVisible(Tree tree) =>
            _trees.AllLinesFrom(tree).Any(line => IsVisibleFromLine(tree, line));

        private static bool IsVisibleFromLine(Tree height, IEnumerable<Tree> line) =>
            line.All(height.IsVisibleFrom);
    }
}