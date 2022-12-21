using monkey_in_the_middle_src.Logic.Data;

namespace monkey_in_the_middle_src.Logic.Abstract
{
    public interface IBrain
    {
        int NextTarget(Item item);
    }
}