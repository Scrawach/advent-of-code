using supply_stacks_src.Storages.Abstract;
using supply_stacks_src.Vehicles.Abstract;

namespace supply_stacks_src.Factory
{
    public class Rearrangement
    {
        private readonly ICrateMover _crateMover;
        private readonly ICommandStorage _commands;
        private readonly IStorage _storage;

        public Rearrangement(ICrateMover crateMover, ICommandStorage commands, IStorage storage)
        {
            _crateMover = crateMover;
            _commands = commands;
            _storage = storage;
        }

        public string WorkResult()
        {
            foreach (var command in _commands.All()) 
                command.Execute(_crateMover);
            return _storage.Top();
        }
    }
}