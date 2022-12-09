using supply_stacks_src.Commands.Abstract;
using supply_stacks_src.Vehicles.Abstract;

namespace supply_stacks_src.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly int _count;
        private readonly int _fromStack;
        private readonly int _toStack;

        public MoveCommand(int count, int fromStack, int toStack)
        {
            _count = count;
            _fromStack = fromStack;
            _toStack = toStack;
        }
        
        public void Execute(ICrateMover mover) =>
            mover.Move(_count, _fromStack, _toStack);

        public override string ToString() =>
            $"move {_count} from {_fromStack} to {_toStack}";
    }
}