using rope_bridge_src.Commands.Abstract;
using rope_bridge_src.Data;
using rope_bridge_src.Logic;

namespace rope_bridge_src.Commands
{
    public class MoveCommand : IHeadCommand
    {
        private readonly Vector2 _direction;

        public MoveCommand(Vector2 direction) =>
            _direction = direction;
        
        public void Execute(IHead head) =>
            head.Move(_direction);
    }
}