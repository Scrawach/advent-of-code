using System.Linq;

namespace day_01_calorie_counting
{
    public class FirstTask
    {
        private readonly InventoryDatabase _database;

        public FirstTask(InventoryDatabase database) =>
            _database = database;

        public int Solve() =>
            _database
                .Inventories()
                .OrderByDescending(inventory => inventory.TotalCalories)
                .First()
                .TotalCalories;
    }
}