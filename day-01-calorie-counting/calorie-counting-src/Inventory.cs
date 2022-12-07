using System;

namespace day_01_calorie_counting
{
    public class Inventory
    {
        public int TotalCalories { get; private set; }

        public void Add(int calories)
        {
            if (calories < 0)
                throw new ArgumentException();
            
            TotalCalories = checked(TotalCalories + calories);
        }
    }
}