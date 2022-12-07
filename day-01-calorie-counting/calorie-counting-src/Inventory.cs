namespace day_01_calorie_counting
{
    public class Inventory
    {
        public int TotalCalories { get; private set; }

        public void Add(int calories) =>
            TotalCalories = checked(TotalCalories + calories);
    }
}