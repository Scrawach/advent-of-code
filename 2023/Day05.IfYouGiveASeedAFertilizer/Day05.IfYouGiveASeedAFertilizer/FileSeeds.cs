using Common.Text;

namespace Day05.IfYouGiveASeedAFertilizer;

public class FileSeeds : ISeeds
{
    private readonly IText _text;

    public FileSeeds(IText text) =>
        _text = text;

    public IEnumerable<long> All()
    {
        var seedLine = _text.Lines().First();
        var split = seedLine.Split(" ");
        for (var i = 1; i < split.Length; i++)
            yield return long.Parse(split[i]);
    }
}