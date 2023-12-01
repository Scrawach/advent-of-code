namespace Day01.Trebuchet.Parsers;

public class FirstAndLastNumbers : IStringParser
{
    public int Parse(string line)
    {
        var firstNumber = ' ';
        var secondNumber = ' ';

        foreach (var symbol in line.Where(char.IsDigit))
        {
            if (firstNumber == ' ')
                firstNumber = symbol;
            
            secondNumber = symbol;
        }

        return int.Parse($"{firstNumber}{secondNumber}");
    }
}