using no_space_left_on_device_src.Commands.Abstract;
using no_space_left_on_device_src.Disk.Abstract;

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
                    device.ToPrevious();
                    break;
                case "/":
                    device.ToRoot();
                    break;
                default:
                    device.To(_target);
                    break;
            }
        }
        public override string ToString() =>
            $"Change Directory Command (to {_target})";
    }
}