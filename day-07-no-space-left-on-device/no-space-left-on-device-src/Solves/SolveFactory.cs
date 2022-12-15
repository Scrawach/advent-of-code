using System;
using System.IO;
using no_space_left_on_device_src.Disk;
using no_space_left_on_device_src.Disk.Abstract;
using no_space_left_on_device_src.Storages;
using Directory = no_space_left_on_device_src.Disk.Directory;

namespace no_space_left_on_device_src.Solves
{
    public class SolveFactory
    {
        private static readonly string Directory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];
        
        private readonly string _fileName;

        public SolveFactory(string fileName) =>
            _fileName = fileName;
        
        public SmallestDirectory SmallestDirectory(int diskSpace, int targetUnusedSpace) =>
            new SmallestDirectory(CreateDevice(_fileName), diskSpace, targetUnusedSpace);

        public SumOfTotalSize SumOfTotalSize(int maxDirectorySize) =>
            new SumOfTotalSize(CreateDevice(_fileName), maxDirectorySize);

        private IDevice CreateDevice(string fileName)
        {
            var path = Path.Combine(Directory, fileName);
            var device = new Device(new Tree<IDirectory>(new Directory("/")));
            var text = new Text(path);
            var commands = new CommandTextStorage(text);
            foreach (var command in commands.All()) 
                command.Execute(device);
            return device;
        }
    }
}