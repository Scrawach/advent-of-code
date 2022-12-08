using System.Linq;

namespace rucksack_reorganization_src
{
    public class Rucksack
    {
        private readonly string _content;

        public Rucksack(string content) =>
            _content = content;

        public char RepeatedSymbol()
        {
            var length = _content.Length / 2;
            var first = _content[..length];
            var second = _content[length..];
            return first.Intersect(second).First();
        }
    }
}