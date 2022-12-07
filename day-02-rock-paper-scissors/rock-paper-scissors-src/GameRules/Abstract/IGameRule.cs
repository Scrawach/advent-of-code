using rock_paper_scissors_src.Rounds;

namespace rock_paper_scissors_src.GameRules.Abstract
{
    public interface IGameRule
    {
        int Score(Round round);
    }
}