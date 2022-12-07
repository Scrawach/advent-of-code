using System.Linq;

namespace day_01_calorie_counting
{
    public class MostCalories
    {
        private readonly InventoryDatabase _database;

        public MostCalories(InventoryDatabase database) =>
            _database = database;

        public int Solve() =>
            _database
                .Inventories()
                .OrderByDescending(inventory => inventory.TotalCalories)
                .First()
                .TotalCalories;
    }
}