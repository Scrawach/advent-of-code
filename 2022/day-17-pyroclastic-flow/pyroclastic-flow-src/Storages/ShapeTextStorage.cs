using System.Collections.Generic;
using pyroclastic_flow_src.Logic;
using pyroclastic_flow_src.Storages.Abstract;

namespace pyroclastic_flow_src.Storages
{
    public class ShapeTextStorage : IShapeStorage
    {
        private readonly IText _text;

        public ShapeTextStorage(IText text) =>
            _text = text;
        
        public IEnumerable<Cell[,]> All()
        {
            var shapeLines = new List<Cell[]>();
            foreach (var line in _text.Lines())
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    yield return ConvertToMatrix(shapeLines);
                    shapeLines.Clear();
                    continue;
                }
                
                var shapeLine = new Cell[line.Length];
                for (var i = 0; i < line.Length; i++)
                    shapeLine[i] = ParseSymbol(line[i]);
                shapeLines.Add(shapeLine);
            }

            if (shapeLines.Count > 0)
            {
                yield return ConvertToMatrix(shapeLines);
                shapeLines.Clear();
            }
        }

        private static Cell[,] ConvertToMatrix(IReadOnlyList<Cell[]> shapeLines)
        {
            var result = new Cell[shapeLines.Count, shapeLines[0].Length];
            
            for (var i = 0; i < result.GetLength(0); i++)
            for (var j = 0; j < result.GetLength(1); j++)
                result[i, j] = shapeLines[result.GetLength(0) - 1 - i][j];

            return result;
        }

        private static Cell ParseSymbol(char symbol) =>
            symbol == '.'
                ? Cell.Empty
                : Cell.Rock;
    }
}