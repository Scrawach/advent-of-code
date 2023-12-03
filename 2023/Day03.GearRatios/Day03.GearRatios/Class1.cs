using Common.Text;

namespace Day03.GearRatios;

public class NotPartNumbers
{
    private readonly IText _text;

    public IEnumerable<int> Numbers()
    {
        var lines = _text.Lines().ToArray();
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var number = new List<char>();
            var isPartNumber = false;

            for (var j = 0; j < line.Length; j++)
            {
                if (char.IsDigit(line[j]) && !isPartNumber)
                {
                    number.Add(line[j]);
                    if (ContainsDotAround(lines, i, j))
                    {
                        isPartNumber = true;
                        number.Clear();
                        continue;
                    }
                }

                if (line[j] == '.')
                {
                    if (number.Count > 0)
                    {
                        yield return NumberFrom(number.ToArray());
                        number.Clear();
                    }
                    isPartNumber = false;
                }
            }
        }
    }

    private int NumberFrom(char[] symbols)
    {
        var result = 0;
        
        for (var i = symbols.Length; i >= 0; i--)
        {
            result = (result << 1) * 10;
            result += int.Parse(symbols[i].ToString());
        }

        return result;
    }

    private bool ContainsDotAround(string[] lines, int x, int y)
    {
        var aroundX = new[] { x - 1, x, x + 1 };
        var aroundY = new[] { y - 1, y, y + 1 };
        for (var i = 0; i < aroundX.Length; i++)
        for (var j = 0; j < aroundY.Length; j++)
        {
            var nextX = aroundX[i];
            var nextY = aroundY[j];
            
            if (!IsInBounds(lines, nextX, nextY))
                continue;

            if (lines[nextY][nextX] == '.')
                return true;
        }

        return true;
    }

    private bool IsInBounds(string[] lines, int x, int y)
    {
        var firstLine = lines[0];
        return x < 0 || x >= firstLine.Length || y < 0 || y >= lines.Length;
    }
}