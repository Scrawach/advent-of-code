using System;
using System.IO;
using supply_stacks_src.Storages;
using supply_stacks_src.Storages.Abstract;
using supply_stacks_src.Vehicles;

namespace supply_stacks_src.Factory
{
    public class RearrangementFactory
    {
        private static readonly string Directory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];

        private readonly string _inputFileName;

        public RearrangementFactory(string inputFileName) =>
            _inputFileName = inputFileName;
        
        public Rearrangement CreateWithDefaultMover()
        {
            var (storage, commands) = CreateStorages();
            var mover = new CrateMover(storage);
            return new Rearrangement(mover, commands, storage);
        }

        public Rearrangement CreateWithMover9001()
        {
            var (storage, commands) = CreateStorages();
            var mover = new CrateMover9001(storage);
            return new Rearrangement(mover, commands, storage);
        }

        private (IStorage storage, CommandTextStorage commands) CreateStorages()
        {
            var text = new Text(Path.Combine(Directory, _inputFileName));
            var stateStorage = new InitialTextStorage(text);
            var commands = new CommandTextStorage(text);
            var storage = new Storage(stateStorage.InitialState());
            return (storage, commands);
        }
    }
}