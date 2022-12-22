
using System.Collections.Generic;
using System.IO;

namespace hill_climbing_algorithm_src.Storages
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