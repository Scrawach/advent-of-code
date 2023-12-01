using pyroclastic_flow_src.Logic;
using pyroclastic_flow_src.Storages.Abstract;

namespace pyroclastic_flow_src.Storages
{
    public class CyclicSelectPolicy : IShapeSelectPolicy
    {
        private readonly Cell[][,] _shapes;
        private int _index = -1;
        
        public CyclicSelectPolicy(Cell[][,] shapes) =>
            _shapes = shapes;

        public Cell[,] Next()
        {
            _index++;
            if (_index > _shapes.Length - 1)
                _index = 0;
            return _shapes[_index];
        }
    }
}