using System.Collections.Generic;
using System.IO;

namespace tuning_trouble_src.Storages
{
    public class Text
    {
        private readonly string _path;

        public Text(string path) =>
            _path = path;

        public IEnumerable<string> Lines() =>
            File.ReadAllLines(_path);
    }
}