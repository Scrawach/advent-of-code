using System.Collections.Generic;
using System.Linq;
using rope_bridge_src.Logic;
using rope_bridge_src.Storages.Abstract;

namespace rope_bridge_src.Solves
{
    public class SeriesOfMotions
    {
        private readonly ICommandsStorage _storage;

        public SeriesOfMotions(ICommandsStorage storage) =>
            _storage = storage;
        
        public int Simulate()
        {
            var head = new Head();
            var tail = new Tail(head);

            foreach (var command in _storage.All())
            {
                command.Execute(head);
                tail.Update();
            }

            return tail.UniquePositions.Count;
        }
    }
}