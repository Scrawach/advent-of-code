namespace Day01.Trebuchet.Text;

public class OneLineText : IText
{
    private readonly string _line;

    public OneLineText(string line) =>
        _line = line;

    public IEnumerable<string> Lines() =>
        _line.Split(Environment.NewLine);
}