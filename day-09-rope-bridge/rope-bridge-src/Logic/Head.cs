using rope_bridge_src.Data;

namespace rope_bridge_src.Logic
{
    public class Head : IHead
    {
        public Vector2 Position { get; private set; }

        public void Move(Vector2 direction) =>
            Position += direction;
    }
}