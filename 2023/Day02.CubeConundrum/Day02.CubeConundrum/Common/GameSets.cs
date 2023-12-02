using Common.Text;

namespace Day02.CubeConundrum.Common;

public class GameSets
{
    private readonly IText _text;
    private readonly GameSetParser _parser;

    public GameSets(IText text, GameSetParser parser)
    {
        _text = text;
        _parser = parser;
    }

    public IEnumerable<GameSet> All() =>
        _text.Lines()
            .Select(_parser.Parse);
}