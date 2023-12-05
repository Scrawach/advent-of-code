using Common.Text;

namespace Day04.Scratchcards;

public class Cards
{
    private readonly IText _text;

    public Cards(IText text) =>
        _text = text;

    public IEnumerable<Card> All()
    {
        foreach (var line in _text.Lines())
        {
            var split = line.Split(':');
            var cardId = split[0].Split(' ')[^1];
            var content = split[1].Split('|');
            var winningNumbers = content[0].Split(' ');
            var numbers = content[1].Split(' ');

            yield return new Card
            (
                int.Parse(cardId), 
                ConvertToInts(winningNumbers).ToHashSet(), 
                ConvertToInts(numbers).ToArray()
            );
        }
    }

    private static List<int> ConvertToInts(IReadOnlyList<string> lines)
    {
        var array = new List<int>(lines.Count);
        foreach (var symbol in lines)
        {
            if (symbol == "")
                continue;
            array.Add(int.Parse(symbol));
        }
        return array;
    }
}