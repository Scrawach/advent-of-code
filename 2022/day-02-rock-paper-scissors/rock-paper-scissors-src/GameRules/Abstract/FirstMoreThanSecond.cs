using rock_paper_scissors_src.Rounds;

namespace rock_paper_scissors_src.GameRules.Abstract
{
    public class FirstMoreThanSecond : IGameRule
    {
        private readonly string _first;
        private readonly string _second;

        public FirstMoreThanSecond(string first, string second)
        {
            _first = first;
            _second = second;
        }

        public int Score(Round round)
        {
            if ((round.Player, round.Opponent) == (_first, _second))
                return 1;

            if ((round.Player, round.Opponent) == (_second, _first))
                return -1;

            return 0;
        }
    }
}