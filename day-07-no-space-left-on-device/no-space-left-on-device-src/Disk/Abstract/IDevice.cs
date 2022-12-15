namespace no_space_left_on_device_src.Disk.Abstract
{
    public interface IDevice
    {
        Tree<IDirectory> Root { get; }
            
        Tree<IDirectory> Current { get; }

        void CreateDirectory(string name);
            
        void CreateFile(int size);
        void MoveTo(string directoryName);
        void MoveToRoot();
        void MoveToParent();
    }
}