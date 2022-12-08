using System.Collections.Generic;
using System.IO;
using rucksack_reorganization_src.Storages.Abstract;

namespace rucksack_reorganization_src.Storages
{
    public class Text : IText
    {
        private readonly string _path;

        public Text(string path) =>
            _path = path;

        public IEnumerable<string> Lines() =>
            File.ReadAllLines(_path);
    }
}