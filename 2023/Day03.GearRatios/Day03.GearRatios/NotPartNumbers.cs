using System.Text;
using Common.Text;

namespace Day03.GearRatios;



public class NotPartNumbers
{
    private readonly IText _text;

    public NotPartNumbers(IText text) =>
        _text = text;

    public IEnumerable<int> Numbers()
    {
        var lines = _text.Lines().ToArray();
        var number = new StringBuilder();
        for (var y = 0; y < lines.Length; y++)
        {
            var current = lines[y];
            var hasSymbolAround = false;
            for (var x = 0; x < current.Length; x++)
            {
                var symbol = current[x];
                if (char.IsDigit(symbol))
                {
                    number.Append(symbol);
                    if (!hasSymbolAround) 
                        hasSymbolAround = HasSymbolAround(lines, x, y);

                    if (x == current.Length - 1 && hasSymbolAround)
                    {
                        yield return int.Parse(number.ToString());
                        number.Clear();
                        hasSymbolAround = false;
                    }
                }
                else
                {
                    if (hasSymbolAround)
                        yield return int.Parse(number.ToString());
                    number.Clear();
                    hasSymbolAround = false;
                }
            }
        }
    }
    
    private bool HasSymbolAround(string[] lines, int x, int y)
    {
        for (var i = x - 1; i <= x + 1; i++)
        for (var j = y - 1; j <= y + 1; j++)
            if (HasSymbolAt(lines, i, j))
                return true;

        return false;
    }

    private bool HasSymbolAt(string[] lines, int x, int y)
    {
        var first = lines[0];
        if (y < 0 || y >= lines.Length || x < 0 || x >= first.Length)
            return false;

        var point = lines[y][x];
        return point != '.' && !char.IsDigit(point);
    }
}