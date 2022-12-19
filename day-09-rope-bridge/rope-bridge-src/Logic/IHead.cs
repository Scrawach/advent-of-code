using rope_bridge_src.Data;

namespace rope_bridge_src.Logic
{
    public interface IHead : IMovable
    {
        void Move(Vector2 direction);
    }
}