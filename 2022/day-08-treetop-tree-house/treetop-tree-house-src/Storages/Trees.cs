using System.Collections.Generic;
using treetop_tree_house_src.Storages.Abstract;

namespace treetop_tree_house_src.Storages
{
    public class Trees : ITrees
    {
        private readonly int[,] _map;

        public Trees(int[,] map) =>
            _map = map;

        public IEnumerable<Tree> All()
        {
            for (var i = 0; i < _map.GetLength(0); i++)
            for (var j = 0; j < _map.GetLength(1); j++)
                yield return new Tree(i, j, _map[i, j]);
        }
        
        public IEnumerable<IEnumerable<Tree>> AllLinesFrom(Tree origin)
        {
            var directions = new (int x, int y)[] { (0, 1), (0, -1), (1, 0), (-1, 0) };
            foreach (var (x, y) in directions)
                yield return Line(origin.X, origin.Y, x, y);
        }

        private IEnumerable<Tree> Line(int startX, int startY, int directionX, int directionY)
        {
            startX += directionX;
            startY += directionY;

            while (InsideHorizontalBorders() 
                   && InsideVerticalBorders())
            {
                yield return new Tree(startX, startY, _map[startX, startY]);
                startX += directionX;
                startY += directionY;
            }

            bool InsideHorizontalBorders() =>
                startX >= 0 && startX < _map.GetLength(0);

            bool InsideVerticalBorders() =>
                startY >= 0 && startY < _map.GetLength(1);
        }
    }
}