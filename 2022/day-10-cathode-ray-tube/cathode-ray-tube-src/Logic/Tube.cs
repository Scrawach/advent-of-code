using System.Collections.Generic;
using cathode_ray_tube_src.Logic.Abstract;

namespace cathode_ray_tube_src.Logic
{
    public class Tube : IWaitCycle
    {
        private readonly char[,] _screen = new char[6, 40];
        
        public void OnCycleDone(int numberOfCycle, int registerValue)
        {
            var row = (numberOfCycle - 1) / _screen.GetLength(1);
            var column = (numberOfCycle - 1) % _screen.GetLength(1);

            if (row >= 6)
                return;

            _screen[row, column] = IsHighlightedPosition(column, registerValue)
                ? '#'
                : '.';
        }

        public IEnumerable<char> Screen()
        {
            for (var i = 0; i < _screen.GetLength(0); i++)
            {
                for (var j = 0; j < _screen.GetLength(1); j++)
                    yield return _screen[i, j];
                yield return '\n';
            }
        }
        
        private static bool IsHighlightedPosition(int pixelPosition, int registerValue) =>
            registerValue + 1 == pixelPosition
            || registerValue - 1 == pixelPosition
            || registerValue == pixelPosition;
    }
}