using pyroclastic_flow_src.Data;

namespace pyroclastic_flow_src.Logic.Abstract
{
    public interface IRockFactory
    {
        Rock Create(Vector2 at);
    }
}