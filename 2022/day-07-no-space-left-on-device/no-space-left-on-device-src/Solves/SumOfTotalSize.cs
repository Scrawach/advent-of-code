using System.Linq;
using no_space_left_on_device_src.Disk.Abstract;

namespace no_space_left_on_device_src.Solves
{
    public class SumOfTotalSize
    {
        private readonly IDevice _device;
        private readonly int _maxDirectorySize;

        public SumOfTotalSize(IDevice device, int maxDirectorySize)
        {
            _device = device;
            _maxDirectorySize = maxDirectorySize;
        }
            
        public int Solve() =>
            _device.Root.Where(x => x.Size < _maxDirectorySize).Sum(file => file.Size);
    }
}