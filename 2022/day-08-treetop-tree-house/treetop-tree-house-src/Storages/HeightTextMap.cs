using System.Linq;
using treetop_tree_house_src.Storages.Abstract;

namespace treetop_tree_house_src.Storages
{
    public class HeightTextMap
    {
        private readonly IText _text;

        public HeightTextMap(IText text) =>
            _text = text;
        
        public int[,] Read()
        {
            var lines = _text.Lines().ToArray();
            var map = new int[lines[0].Length, lines.Length];

            for (var i = 0; i < lines[0].Length; i++)
            {
                for (var j = 0; j < lines.Length; j++)
                {
                    map[i, j] = int.Parse(new string(lines[i][j], 1));
                }
            }
            return map;
        }
    }
}