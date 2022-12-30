using System.Collections.Generic;
using System.IO;
using grove_positioning_system_src.Storages.Abstract;

namespace grove_positioning_system_src.Storages
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