using System.Collections.Generic;
using no_space_left_on_device_src.Commands;
using no_space_left_on_device_src.Commands.Abstract;
using no_space_left_on_device_src.Disk;
using no_space_left_on_device_src.Storages.Abstract;

namespace no_space_left_on_device_src.Storages
{
    public class CommandTextStorage
    {
        private readonly IDevice _device;
        private readonly IText _text;

        public CommandTextStorage(IDevice device, IText text)
        {
            _device = device;
            _text = text;
        }

        public IEnumerable<ICommand> All()
        {
            var content = new List<string>();
            var hasListCommand = false;
                
            foreach (var line in _text.Lines())
            {
                var isCommand = line[0] == '$';

                if (isCommand)
                {
                    var split = line.Split(" ");
                        
                    if (hasListCommand)
                        yield return new ListCommand(content.ToArray());
                        
                    if (split[1] == "cd")
                        yield return new ChangeDirectoryCommand(split[2]);
                        
                    hasListCommand = split[1] == "ls";
                    content.Clear();
                }
                else if (hasListCommand)
                {
                    content.Add(line);
                }
            }

            if (hasListCommand)
                yield return new ListCommand(content.ToArray());
        }
    }
}