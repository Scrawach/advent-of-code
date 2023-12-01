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
                (firstNumber, secondNumber) = UpdateNumbers(firstNumber, int.Parse(symbol.ToString()));
            else
                ParseSubstring(symbol, buffer, parsedNumber =>
                {
                    (firstNumber, secondNumber) = UpdateNumbers(firstNumber, parsedNumber);
                });
        }

        return firstNumber * 10 + secondNumber;
    }

    private void ParseSubstring(char symbol, StringBuilder buffer, Action<int> onParsed)
    {
        buffer.Append(symbol);
        var (isHasSubstringNumber, substringNumber) = ParseSubstringNumber(buffer.ToString());
        
        if (!isHasSubstringNumber) 
            return;
        
        onParsed(substringNumber);
        buffer.Clear();
        buffer.Append(symbol);
    }
    
    private static (int, int) UpdateNumbers(int firstNumber, int nextNumber) =>
        firstNumber == 0 ? (nextNumber, nextNumber) : (firstNumber, nextNumber);

    private (bool, int) ParseSubstringNumber(string line)
    {
        foreach (var numberKey in _numbersMap.Select(pair => pair.Key).Where(line.Contains))
            return (true, _numbersMap[numberKey]);

        return (false, -1);
    }
}