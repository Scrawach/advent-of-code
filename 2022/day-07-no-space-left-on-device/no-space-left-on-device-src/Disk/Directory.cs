using no_space_left_on_device_src.Disk.Abstract;

namespace no_space_left_on_device_src.Disk
{
    public class Directory : IDirectory
    {
        public Directory(string name) =>
            Name = name;

        public string Name { get; }
        public int Size { get; set; }
    }
}