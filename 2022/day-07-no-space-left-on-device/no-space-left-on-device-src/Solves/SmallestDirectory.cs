using System.Linq;
using no_space_left_on_device_src.Disk.Abstract;

namespace no_space_left_on_device_src.Solves
{
    public class SmallestDirectory
    {
        private readonly IDevice _device;
        private readonly int _diskSpace;
        private readonly int _targetUnusedSpace;

        public SmallestDirectory(IDevice device, int diskSpace, int targetUnusedSpace)
        {
            _device = device;
            _diskSpace = diskSpace;
            _targetUnusedSpace = targetUnusedSpace;
        }
            
        public int Solve()
        {
            var usedSpace = _device.Root.Value.Size;
            var target = _targetUnusedSpace - (_diskSpace - usedSpace);
            return _device.Root.Select(file => file.Size).Where(size => size >= target).Min();
        }
    }
}