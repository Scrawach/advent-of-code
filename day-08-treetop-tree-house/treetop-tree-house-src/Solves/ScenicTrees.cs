using System.Collections.Generic;
using System.Linq;
using treetop_tree_house_src.Extensions;
using treetop_tree_house_src.Storages;
using treetop_tree_house_src.Storages.Abstract;

namespace treetop_tree_house_src.Solves
{
    public class ScenicTrees
    {
        private readonly ITrees _trees;

        public ScenicTrees(ITrees trees) =>
            _trees = trees;

        public int HighestScore() =>
            _trees
                .All()
                .Select(ScenicScore)
                .Max();

        private int ScenicScore(Tree tree) =>
            _trees
                .AllLinesFrom(tree)
                .Aggregate(1, (current, line) => current * CountOfVisibleTrees(tree, line));

        private static int CountOfVisibleTrees(Tree origin, IEnumerable<Tree> line) =>
            line
                .TakeWhileIncluding(origin.IsVisibleFrom)
                .Count();
    }
}