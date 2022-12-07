namespace rock_paper_scissors_src.Rounds
{
    public readonly struct Round
    {
        public readonly string Player;
        public readonly string Opponent;

        public Round(string player, string opponent)
        {
            Player = player;
            Opponent = opponent;
        }
    }
}