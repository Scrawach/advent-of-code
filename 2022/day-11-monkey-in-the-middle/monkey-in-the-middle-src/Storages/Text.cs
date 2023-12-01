using System.Collections.Generic;
using System.IO;
using monkey_in_the_middle_src.Storages.Abstract;

namespace monkey_in_the_middle_src.Storages
{
    public class Text : IText
    {
        private readonly string _path;

        public Text(string path) =>
            _path = path;

        public string All() =>
            File.ReadAllText(_path);

        public IEnumerable<string> Lines() =>
            File.ReadAllLines(_path);
    }
}