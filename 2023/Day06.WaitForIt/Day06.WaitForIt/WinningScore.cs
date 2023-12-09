namespace Day06.WaitForIt;

public class WinningScore
{
    private readonly NumberOfWinningWays _winningWays;

    public WinningScore(NumberOfWinningWays winningWays) =>
        _winningWays = winningWays;

    public long Score() =>
        _winningWays
            .Numbers()
            .Aggregate(1L, (current, number) => current * number);
}