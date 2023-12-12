namespace Day05.IfYouGiveASeedAFertilizer;

public class LowestLocation
{
    private readonly Locations _locations;

    public LowestLocation(Locations locations) =>
        _locations = locations;

    public long Value() =>
        _locations.Values().Min();
}