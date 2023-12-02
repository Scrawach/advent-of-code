namespace Day02.CubeConundrum.Common;

public class GameSet
{
    public GameSet(int id, Game[] games)
    {
        Id = id;
        Games = games;
    }

    public int Id { get; }
    public Game[] Games { get; }
}