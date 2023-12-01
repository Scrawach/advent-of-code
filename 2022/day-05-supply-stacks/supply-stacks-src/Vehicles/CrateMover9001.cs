using System.Collections.Generic;
using supply_stacks_src.Storages.Abstract;
using supply_stacks_src.Vehicles.Abstract;

namespace supply_stacks_src.Vehicles
{
    public class CrateMover9001 : ICrateMover
    {
        private readonly IStorage _storage;

        public CrateMover9001(IStorage storage) =>
            _storage = storage;
        
        public void Move(int count, int fromStack, int toStack)
        {
            var localStorage = new Stack<char>();
            
            for (var i = 0; i < count; i++) 
                localStorage.Push(_storage.Take(fromStack));
            
            for (var i = 0; i < count; i++) 
                _storage.Put(localStorage.Pop(), toStack);
        }
    }
}