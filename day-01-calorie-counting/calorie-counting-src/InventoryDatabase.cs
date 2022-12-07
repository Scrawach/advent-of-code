using System.Collections.Generic;

namespace day_01_calorie_counting
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
                inventory.Add(int.Parse(line));

                if (string.IsNullOrWhiteSpace(line))
                {
                    yield return inventory;
                    inventory = new Inventory();
                }
            }

            yield return inventory;
        }
    }
}