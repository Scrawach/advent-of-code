using System;
using System.Collections.Generic;
using System.IO;
using not_enough_minerals_src.Storages.Abstract;

namespace not_enough_minerals_src.Storages
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