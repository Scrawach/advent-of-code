namespace Day05.IfYouGiveASeedAFertilizer;

public class PieceOfMap
{
    public long Source;
    public long Destination;
    public long Steps;

    public PieceOfMap(long source, long destination, long steps)
    {
        Source = source;
        Destination = destination;
        Steps = steps;
    }

    public bool HasInside(long number) =>
        number >= Source && number < Source + Steps;
    
    public long Convert(long value) =>
        value + (Destination - Source);
}