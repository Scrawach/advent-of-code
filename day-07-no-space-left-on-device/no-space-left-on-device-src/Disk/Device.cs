using System.Linq;
using no_space_left_on_device_src.Disk.Abstract;

namespace no_space_left_on_device_src.Disk
{
    public class Device : IDevice
    {
        public Device() =>
            Current = Root = new Tree<IDirectory>(new Directory("/"));

        public Tree<IDirectory> Root { get; }
            
        public Tree<IDirectory> Current { get; private set; }

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

        public void MoveTo(string directoryName)
        {
            if (TryFindDirectory(directoryName, out var directory))
                Current = directory;
        }

        public void MoveToRoot() =>
            Current = Root;

        public void MoveToParent() =>
            Current = Current.Parent;

        private bool TryFindDirectory(string name, out Tree<IDirectory> directory)
        {
            directory = Current.Children.FirstOrDefault(dir => dir.Value.Name == name);
            return directory != null;
        }
    }
}