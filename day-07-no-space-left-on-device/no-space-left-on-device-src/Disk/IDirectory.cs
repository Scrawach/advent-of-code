namespace no_space_left_on_device_src.Disk
{
    public interface IDirectory
    {
        string Name { get; }
        int Size { get; set; }
    }
}