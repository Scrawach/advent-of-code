namespace Day02.CubeConundrum.Common;

public class Game
{
    public Game(int reds, int blues, int greens)
    {
        Reds = reds;
        Blues = blues;
        Greens = greens;
    }

    public int Reds { get; }
    public int Blues { get; }
    public int Greens { get; }
}