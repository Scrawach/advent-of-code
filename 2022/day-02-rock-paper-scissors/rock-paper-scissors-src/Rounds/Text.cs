using System.Collections.Generic;
using System.IO;
using rock_paper_scissors_src.Rounds.Abstract;

namespace rock_paper_scissors_src.Rounds
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