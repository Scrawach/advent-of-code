using System.Linq;
using no_space_left_on_device_src.Commands.Abstract;
using no_space_left_on_device_src.Disk;

namespace no_space_left_on_device_src.Commands
{
    public class ChangeDirectoryCommand : ICommand
    {
        private readonly string _target;

        public ChangeDirectoryCommand(string target) =>
            _target = target;

        public void Execute(IDevice device)
        {
            switch (_target)
            {
                case "..":
                    device.Current = device.Current.Parent;
                    break;
                case "/":
                    device.Current = device.Root;
                    break;
                default:
                {
                    ToExistingDirectory(device, _target);
                    break;
                }
            }
        }

        private static void ToExistingDirectory(IDevice device, string name)
        {
            var next = device.Current.Children.FirstOrDefault(dir => dir.Value.Name == name);
            if (next != null)
                device.Current = next;
        }

        public override string ToString() =>
            $"Change Directory Command (to {_target})";
    }
}