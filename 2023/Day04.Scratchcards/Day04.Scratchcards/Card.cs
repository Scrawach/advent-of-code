namespace Day04.Scratchcards;

public class Card
{
    public readonly int Id;
    public readonly HashSet<int> WinningNumbers;
    public readonly int[] Numbers;

    public Card(int id, HashSet<int> winningNumbers, int[] numbers)
    {
        Id = id;
        WinningNumbers = winningNumbers;
        Numbers = numbers;
    }

    public int CountOfWinningNumbers() =>
        Numbers.Count(number => WinningNumbers.Contains(number));
}