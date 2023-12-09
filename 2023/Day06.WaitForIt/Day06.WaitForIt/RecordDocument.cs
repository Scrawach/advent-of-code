using Common.Text;

namespace Day06.WaitForIt;

public class RecordDocument
{
    private readonly IText _text;
    private readonly IRecordParser _parser;

    public RecordDocument(IText text, IRecordParser parser)
    {
        _text = text;
        _parser = parser;
    }

    public IEnumerable<Record> All()
    {
        foreach (var chunk in _text.Lines().Chunk(2))
        foreach (var record in _parser.Parse(chunk[0], chunk[1]))
            yield return record;
    }
}