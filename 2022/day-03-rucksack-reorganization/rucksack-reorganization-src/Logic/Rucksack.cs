using System.Linq;
using rucksack_reorganization_src.Logic.Abstract;

namespace rucksack_reorganization_src.Logic
{
    public class Rucksack : IRucksack
    {
        private readonly string[] _contents;

        public Rucksack(params string[] contents) =>
            _contents = contents;

        public char RepeatedSymbol()
        {
            var intersects = _contents[0].AsEnumerable();
            for (var i = 1; i < _contents.Length; i++)
                intersects = intersects.Intersect(_contents[i]);
            return intersects.First();
        }
    }
}