using Day02.CubeConundrum.Common;

namespace Day02.CubeConundrum.SecondTask;

public class SumOfPowerGameSets
{
    private readonly GameSets _gameSets;

    public SumOfPowerGameSets(GameSets gameSets) =>
        _gameSets = gameSets;

    public int Value() =>
        _gameSets.All()
            .Select(PowerOfGameSet)
            .Sum();

    private static int PowerOfGameSet(GameSet set)
    {
        var maxRed = 0;
        var maxBlue = 0;
        var maxGreen = 0;
        
        foreach (var game in set.Games)
        {
            maxRed = Math.Max(maxRed, game.Reds);
            maxBlue = Math.Max(maxBlue, game.Blues);
            maxGreen = Math.Max(maxGreen, game.Greens);
        }

        return maxRed * maxBlue * maxGreen;
    }
}