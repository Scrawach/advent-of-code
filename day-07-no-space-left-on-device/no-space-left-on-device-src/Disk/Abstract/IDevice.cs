namespace no_space_left_on_device_src.Disk.Abstract
{
    public interface IDevice
    {
        ITree<IDirectory> Root { get; }
            
        ITree<IDirectory> Current { get; }

        void CreateDirectory(string name);
            
        void CreateFile(int size);
        void To(string directoryName);
        void ToRoot();
        void ToPrevious();
    }
}