namespace rock_paper_scissors_src
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

        public int Score(string first, string second)
        {
            if (first == _first && second == _second)
                return 1;

            if (first == _second && second == _first)
                return -1;

            return 0;
        }
    }
}