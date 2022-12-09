using supply_stacks_src.Vehicles.Abstract;

namespace supply_stacks_src.Commands.Abstract
{
    public interface ICommand
    {
        void Execute(ICrateMover mover);
    }
}