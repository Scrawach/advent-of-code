using System.Text;

namespace Day01.Trebuchet;

public class FirstAndLastNumbersWithText : IStringParser
{
    private readonly Dictionary<string, int> _numbersMap = new()
    {
        ["one"] = 1,
        ["two"] = 2,
        ["three"] = 3,
        ["four"] = 4,
        ["five"] = 5,
        ["six"] = 6,
        ["seven"] = 7,
        ["eight"] = 8,
        ["nine"] = 9
    };

    public int Parse(string line)
    {
        var firstNumber = 0;
        var secondNumber = 0;
        var buffer = new StringBuilder();

        foreach (var symbol in line)
        {
            if (char.IsDigit(symbol))
            {
                var number = int.Parse(symbol.ToString());
                if (firstNumber == 0)
                    firstNumber = number;
                secondNumber = number;
            }

            buffer.Append(symbol);
            var (isHasSubstringNumber, substringNumber) = ParseSubstringNumber(buffer.ToString());
            if (isHasSubstringNumber)
            {
                if (firstNumber == 0)
                    firstNumber = substringNumber;
                secondNumber = substringNumber;
                buffer.Clear();
                buffer.Append(symbol);
            }
        }

        return firstNumber * 10 + secondNumber;
    }

    private (bool, int) ParseSubstringNumber(string line)
    {
        foreach (var numberKey in _numbersMap.Select(pair => pair.Key).Where(line.Contains))
            return (true, _numbersMap[numberKey]);

        return (false, -1);
    }
}