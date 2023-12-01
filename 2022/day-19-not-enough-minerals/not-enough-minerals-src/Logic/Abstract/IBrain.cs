using not_enough_minerals_src.Data;

namespace not_enough_minerals_src.Logic.Abstract
{
    public interface IBrain
    {
        int BestNumberOfGeodes(Blueprint forBlueprint);
    }
}