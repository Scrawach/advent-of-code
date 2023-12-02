using Day02.CubeConundrum.Common;

namespace Day02.CubeConundrum.FirstTask;

public class LimitsGameSetPolicy : IGameSetPolicy
{
    private readonly Game _limits;

    public LimitsGameSetPolicy(Game limits) =>
        _limits = limits;

    public bool IsValid(GameSet gameSet) =>
        gameSet.Games.All(IsValid);

    private bool IsValid(Game game) =>
        game.Reds <= _limits.Reds 
        && game.Blues <= _limits.Blues 
        && game.Greens <= _limits.Greens;
}