using no_space_left_on_device_src.Disk;
using no_space_left_on_device_src.Disk.Abstract;

namespace no_space_left_on_device_src.Commands.Abstract
{
    public interface ICommand
    {
        void Execute(IDevice device);
    }
}