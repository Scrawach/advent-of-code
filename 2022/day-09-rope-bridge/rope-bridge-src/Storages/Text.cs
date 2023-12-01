using System.Collections.Generic;
using System.IO;
using rope_bridge_src.Storages.Abstract;

namespace rope_bridge_src.Storages
{
    public class Text : IText
    {
        private readonly string _path;

        public Text(string path) =>
            _path = path;
        
        public IEnumerable<string> All() =>
            File.ReadAllLines(_path);
    }
}