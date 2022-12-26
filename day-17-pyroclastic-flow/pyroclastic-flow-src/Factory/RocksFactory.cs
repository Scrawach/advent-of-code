using pyroclastic_flow_src.Data;
using pyroclastic_flow_src.Logic;
using pyroclastic_flow_src.Logic.Abstract;
using pyroclastic_flow_src.Storages.Abstract;

namespace pyroclastic_flow_src.Factory
{
    public class RocksFactory : IRockFactory
    {
        private readonly IShapeSelectPolicy _shapes;

        public RocksFactory(IShapeSelectPolicy shapes) =>
            _shapes = shapes;
        
        public Rock Create(Vector2 at) =>
            new Rock(at, _shapes.Next());
    }
}