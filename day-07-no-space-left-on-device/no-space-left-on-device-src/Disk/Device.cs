namespace no_space_left_on_device_src.Disk
{
    public class Device : IDevice
    {
        public Device() =>
            Current = Root = new Tree<IDirectory>(new Directory("/"));

        public Tree<IDirectory> Root { get; }
            
        public Tree<IDirectory> Current { get; set; }

        public void CreateDirectory(string name) =>
            Current.AddChild(new Directory(name));

        public void CreateFile(int size)
        {
            var parent = Current;
                
            while (parent != null)
            {
                parent.Value.Size += size;
                parent = parent.Parent;
            }
        }
    }
}