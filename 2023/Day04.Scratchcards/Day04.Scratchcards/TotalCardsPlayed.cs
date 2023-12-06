namespace Day04.Scratchcards;

public class TotalCardsPlayed
{
    private readonly Cards _cards;
    private readonly Dictionary<int, int> _attempts;

    public TotalCardsPlayed(Cards cards)
    {
        _cards = cards;
        _attempts = new Dictionary<int, int>()
        {
            [1] = 1
        };
    }

    public int Value() =>
        _cards.All()
            .Aggregate(0, (current, card) => Simulate(card, current));

    private int Simulate(Card card, int playedCards)
    {
        _attempts.TryAdd(card.Id, 1);
        var attempts = _attempts[card.Id];

        while (attempts > 0)
        {
            var winningNumbers = card.CountOfWinningNumbers();
            playedCards++;

            for (var i = 1; i <= winningNumbers; i++)
            {
                var nextCardId = card.Id + i;
                if (_attempts.ContainsKey(nextCardId))
                    _attempts[nextCardId]++;
                else
                    _attempts[nextCardId] = 2;
            }

            attempts--;
        }

        return playedCards;
    }

    private int TotalPointsFrom(int winningCount)
    {
        if (winningCount == 0)
            return 0;
        return (int) Math.Pow(2, winningCount) / 2;
    }
}