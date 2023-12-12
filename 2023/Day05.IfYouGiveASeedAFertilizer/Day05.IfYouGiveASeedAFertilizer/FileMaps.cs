using Common.Text;

namespace Day05.IfYouGiveASeedAFertilizer;

public class FileMaps
{
    private readonly IText _text;

    public FileMaps(IText text) =>
        _text = text;

    public IEnumerable<Map> All()
    {
        var mapLines = new List<string>();
        foreach (var line in _text.Lines().Skip(1))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                if (mapLines.Count > 0)
                    yield return ParseMap(mapLines);
                mapLines.Clear();
            }
            else
            {
                mapLines.Add(line);
            }
        }
        yield return ParseMap(mapLines);
    }

    private Map ParseMap(IReadOnlyList<string> mapLines) =>
        new(ParsePieceOfMaps(mapLines).ToArray());

    private IEnumerable<PieceOfMap> ParsePieceOfMaps(IEnumerable<string> map) =>
        map.Skip(1).Select(ParsePieceOfMap);

    private static PieceOfMap ParsePieceOfMap(string line)
    {
        var lineNumbers = line.Split(" ");
        var numbers = lineNumbers.Select(long.Parse).ToArray();
        return new PieceOfMap(numbers[1], numbers[0], numbers[2]);
    }
}