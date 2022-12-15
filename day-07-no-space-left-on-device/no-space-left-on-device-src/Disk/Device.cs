using System.Linq;
using no_space_left_on_device_src.Disk.Abstract;

namespace no_space_left_on_device_src.Disk
{
    public class Device : IDevice
    {
        public Device(ITree<IDirectory> root) =>
            Current = Root = root;

        public ITree<IDirectory> Root { get; }
            
        public ITree<IDirectory> Current { get; private set; }

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

        public void To(string directoryName)
        {
            if (TryFindDirectory(directoryName, out var directory))
                Current = directory;
        }

        public void ToRoot() =>
            Current = Root;

        public void ToPrevious() =>
            Current = Current.Parent;

        private bool TryFindDirectory(string name, out ITree<IDirectory> directory)
        {
            directory = Current.Children.FirstOrDefault(tree => tree.Value.Name == name);
            return directory != null;
        }
    }
}