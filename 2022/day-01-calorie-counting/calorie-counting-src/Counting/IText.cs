using System.Collections.Generic;

namespace day_01_calorie_counting.Counting
{
    public interface IText
    {
        IEnumerable<string> Lines();
    }
}