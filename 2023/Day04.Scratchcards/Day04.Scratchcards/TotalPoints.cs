namespace Day04.Scratchcards;

public class TotalPoints
{
    private readonly Cards _cards;

    public TotalPoints(Cards cards) =>
        _cards = cards;

    public int Value() =>
        _cards.All()
            .Select(card => card.CountOfWinningNumbers())
            .Select(TotalPointsFrom)
            .Sum();

    private int TotalPointsFrom(int winningCount)
    {
        if (winningCount == 0)
            return 0;
        return (int) Math.Pow(2, winningCount) / 2;
    }
}