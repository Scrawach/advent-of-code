using System.Collections;
using supply_stacks_src.Storages.Abstract;
using supply_stacks_src.Vehicles.Abstract;

namespace supply_stacks_src.Vehicles
{
    public class CrateMover : ICrateMover
    {
        private readonly IStorage _storage;

        public CrateMover(IStorage storage) =>
            _storage = storage;

        public void Move(int count, int from, int to)
        {
            for (var i = 0; i < count; i++)
            {
                var box = _storage.Take(from);
                _storage.Put(box, to: to);
            }
        }
    }
}