using System.Collections.Generic;

namespace day_01_calorie_counting
{
    public interface IText
    {
        IEnumerable<string> Lines();
    }
}