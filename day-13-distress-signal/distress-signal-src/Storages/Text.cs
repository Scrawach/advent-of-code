using System.Collections.Generic;
using System.IO;
using distress_signal_src.Storages.Abstract;

namespace distress_signal_src.Storages
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