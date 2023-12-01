using System.Collections.Generic;
using no_space_left_on_device_src.Storages.Abstract;

namespace no_space_left_on_device_src.Storages
{
    public class Text : IText
    {
        private readonly string _path;

        public Text(string path) =>
            _path = path;
        
        public IEnumerable<string> Lines() =>
            System.IO.File.ReadAllLines(_path);
    }
}