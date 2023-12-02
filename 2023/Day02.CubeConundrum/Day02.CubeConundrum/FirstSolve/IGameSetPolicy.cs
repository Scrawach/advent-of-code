using Day02.CubeConundrum.Common;

namespace Day02.CubeConundrum.FirstSolve;

public interface IGameSetPolicy
{
    bool IsValid(GameSet gameSet);
}