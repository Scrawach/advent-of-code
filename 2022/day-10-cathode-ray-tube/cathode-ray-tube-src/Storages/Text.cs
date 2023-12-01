using System.Collections.Generic;
using System.IO;
using cathode_ray_tube_src.Storages.Abstract;

namespace cathode_ray_tube_src.Storages
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