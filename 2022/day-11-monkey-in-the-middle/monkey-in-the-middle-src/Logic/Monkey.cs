using System.Collections.Generic;
using System.Linq;
using monkey_in_the_middle_src.Logic.Abstract;
using monkey_in_the_middle_src.Logic.Data;

namespace monkey_in_the_middle_src.Logic
{
    public class Monkey
    {
        private readonly IBrain _brain;
        private readonly List<Item> _inventory;

        public Monkey(IBrain brain, List<Item> inventory)
        {
            _brain = brain;
            _inventory = inventory;
        }
        
        public bool HasItem => 
            _inventory.Count != 0;
        
        public long InspectionCount { get; private set; }

        public IEnumerable<ThrowingItem> ThrowItems()
        {
            var actions = new ThrowingItem[_inventory.Count];
            
            for (var i = 0; i < _inventory.Count; i++)
            {
                var item = _inventory[i];
                var targetId = _brain.NextTarget(item);
                actions[i] = new ThrowingItem(item, targetId);
                InspectionCount++;
            }
            
            _inventory.Clear();
            return actions;
        }

        public void Catch(Item item) =>
            _inventory.Add(item);

        public override string ToString() =>
            _inventory.Aggregate("Inventory: ", (line, item) => $"{line}, {item.WorryLevel}");
    }
}