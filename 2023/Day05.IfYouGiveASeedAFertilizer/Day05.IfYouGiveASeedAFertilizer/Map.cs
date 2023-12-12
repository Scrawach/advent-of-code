namespace Day05.IfYouGiveASeedAFertilizer;

public class Map
{
    private readonly PieceOfMap[] _pieces;

    public Map(params PieceOfMap[] pieces) =>
        _pieces = pieces;
    
    public long Convert(long value)
    {
        foreach (var pieceMap in _pieces)
        {
            if (pieceMap.HasInside(value))
                return pieceMap.Convert(value);
        }
        
        return value;
    }
}