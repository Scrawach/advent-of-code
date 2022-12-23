using regolith_reservoir_src.Data;

namespace regolith_reservoir_src.Logic.Abstract
{
    public interface ICave
    {
        int Height { get; }
        bool IsOccupied(Vector2 point);
    }
}