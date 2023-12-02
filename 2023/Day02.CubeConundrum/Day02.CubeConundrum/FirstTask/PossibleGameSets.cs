using Day02.CubeConundrum.Common;

namespace Day02.CubeConundrum.FirstTask;

public class PossibleGameSets
{
    private readonly GameSets _gameSets;
    private readonly IGameSetPolicy _policy;

    public PossibleGameSets(GameSets gameSets, IGameSetPolicy policy)
    {
        _gameSets = gameSets;
        _policy = policy;
    }

    public IEnumerable<GameSet> All() =>
        _gameSets.All()
            .Where(bag => _policy.IsValid(bag));
}