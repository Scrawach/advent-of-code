namespace supply_stacks_src.Vehicles.Abstract
{
    public interface ICrateMover
    {
        void Move(int count, int fromStack, int toStack);
    }
}