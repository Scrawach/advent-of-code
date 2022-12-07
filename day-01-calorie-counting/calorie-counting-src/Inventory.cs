namespace day_01_calorie_counting
{
    public class Inventory
    {
        private int _calories;
        
        public int TotalCalories => _calories;

        public void Add(int calories) =>
            _calories = calories;
    }
}