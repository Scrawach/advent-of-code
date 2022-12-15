using System.Linq;
using no_space_left_on_device_src.Commands.Abstract;
using no_space_left_on_device_src.Disk;
using no_space_left_on_device_src.Disk.Abstract;

namespace no_space_left_on_device_src.Commands
{
    public class ListCommand : ICommand
    {
        private readonly string[] _content;

        public ListCommand(string[] content) =>
            _content = content;

        public void Execute(IDevice device)
        {
            foreach (var content in _content)
            {
                var split = content.Split(" ");
                    
                if (split[0] == "dir")
                    device.CreateDirectory(split[1]);
                else
                    device.CreateFile(int.Parse(split[0]));
            }
        }

        public override string ToString() =>
            $"{_content.Aggregate("List Command: ", (first, next) => $"{first} {next}")}";
    }
}