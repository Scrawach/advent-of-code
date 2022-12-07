using System.Linq;

namespace day_01_calorie_counting.Counting
{
    public class MostCalories
    {
        private readonly int _numberOfLeaders;
        private readonly InventoryDatabase _database;

        public MostCalories(InventoryDatabase database) 
            : this(1, database)
        { }

        public MostCalories(int numberOfLeaders, InventoryDatabase database)
        {
            _numberOfLeaders = numberOfLeaders;
            _database = database;
        }

        public int Solve() =>
            _database
                .Inventories()
                .Select(inventory => inventory.TotalCalories)
                .OrderByDescending(calories => calories)
                .Take(_numberOfLeaders)
                .Sum();
    }
}