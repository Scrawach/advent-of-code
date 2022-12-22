using System.Collections;
using System.Collections.Generic;
using hill_climbing_algorithm_src.Data;
using hill_climbing_algorithm_src.Storages.Abstract;

namespace hill_climbing_algorithm_src.Storages
{
    public class Heightmap : IHeightmap
    {
        private const char StartPosition = 'S';
        private const char TargetPosition = 'E';
        private const char MinHeight = 'a';
        private const char MaxHeight = 'z';
        
        private readonly IText _text;
        private int[][] _heights;

        public Heightmap(IText text) =>
            _text = text;

        public Vector2 Start { get; private set; }
        
        public Vector2 Target { get; private set; }

        public int this[Vector2 position] => 
            _heights[position.Y][position.X];

        public bool Has(Vector2 position) =>
            InBorder(position);

        public void Load()
        {
            var map = new List<int[]>();
            
            foreach (var line in _text.Lines()) 
                map.Add(ParseLine(line, map));

            _heights = map.ToArray();
        }

        private int[] ParseLine(string line, ICollection map)
        {
            var mapLine = new int[line.Length];
            
            for (var i = 0; i < mapLine.Length; i++)
            {
                switch (line[i])
                {
                    case StartPosition:
                        Start = new Vector2(i, map.Count);
                        mapLine[i] = 0;
                        break;
                    case TargetPosition:
                        Target = new Vector2(i, map.Count);
                        mapLine[i] = MaxHeight - MinHeight;
                        break;
                    default:
                        mapLine[i] = line[i] - MinHeight;
                        break;
                }
            }

            return mapLine;
        }

        private bool InBorder(Vector2 position) =>
            position.Y >= 0 
            && position.Y < _heights.Length
            && position.X >= 0 
            && position.X < _heights[position.Y].Length;
        
    }
}