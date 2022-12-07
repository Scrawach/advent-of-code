using System.Collections.Generic;

namespace day_01_calorie_counting.Counting
{
    public class InventoryDatabase
    {
        private readonly IText _text;

        public InventoryDatabase(IText text) =>
            _text = text;
        
        public IEnumerable<Inventory> Inventories()
        {
            var inventory = new Inventory();
            
            foreach (var line in _text.Lines())
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    yield return inventory;
                    inventory = new Inventory();
                    continue;
                }
                
                inventory.Add(int.Parse(line));
            }

            yield return inventory;
        }
    }
}