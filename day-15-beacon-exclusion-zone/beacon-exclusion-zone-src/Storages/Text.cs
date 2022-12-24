using System.Collections.Generic;
using System.IO;
using beacon_exclusion_zone_src.Storages.Abstract;

namespace beacon_exclusion_zone_src.Storages
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