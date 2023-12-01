using pyroclastic_flow_src.Data;

namespace pyroclastic_flow_src.Storages.Abstract
{
    public interface IMovementSequence
    {
        Vector2 NextDirection();
    }
}