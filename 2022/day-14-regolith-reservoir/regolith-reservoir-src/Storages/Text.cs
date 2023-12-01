using System.Collections.Generic;
using System.IO;
using regolith_reservoir_src.Storages.Abstract;

namespace regolith_reservoir_src.Storages
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