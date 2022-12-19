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
        
        public int Simulate(int length = 1)
        {
            var head = new Head();
            var tails = new List<Tail> { new Tail(head) };
            for (var i = 1; i < length; i++)
                tails.Add(new Tail(tails[i - 1]));

            foreach (var command in _storage.All())
            {
                command.Execute(head);
                foreach (var tail in tails) 
                    tail.Update();
            }

            return tails.Last().UniquePositions.Count;
        }
    }
}