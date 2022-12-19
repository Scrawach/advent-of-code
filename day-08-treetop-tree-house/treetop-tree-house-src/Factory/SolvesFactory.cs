using System;
using System.IO;
using treetop_tree_house_src.Solves;
using treetop_tree_house_src.Storages;

namespace treetop_tree_house_src.Factory
{
    public class SolvesFactory
    {
        private static readonly string Directory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];

        private readonly string _path;

        public SolvesFactory(string path) =>
            _path = path;

        public VisibleTrees VisibleTrees() =>
            new VisibleTrees(CreateTrees());

        public ScenicTrees ScenicTrees() =>
            new ScenicTrees(CreateTrees());

        private Trees CreateTrees()
        {
            var path = Path.Combine(Directory, _path);
            var map = new HeightTextMap(new Text(path));
            return new Trees(map.Read());
        }
    }
}