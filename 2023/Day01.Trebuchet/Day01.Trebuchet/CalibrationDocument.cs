using Day01.Trebuchet.Parsers;
using Day01.Trebuchet.Text;

namespace Day01.Trebuchet;

public class CalibrationDocument
{
    private readonly IText _text;
    private readonly IStringParser _parser;

    public CalibrationDocument(IText text, IStringParser parser)
    {
        _text = text;
        _parser = parser;
    }
    
    public IEnumerable<int> Values() =>
        _text.Lines().Select(line => _parser.Parse(line));
}