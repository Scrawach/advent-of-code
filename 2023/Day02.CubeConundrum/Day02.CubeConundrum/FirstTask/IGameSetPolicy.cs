using Day02.CubeConundrum.Common;

namespace Day02.CubeConundrum.FirstTask;

public interface IGameSetPolicy
{
    bool IsValid(GameSet gameSet);
}