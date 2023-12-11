namespace Day05.IfYouGiveASeedAFertilizer;

public class Locations
{
    private readonly FileMaps _maps;
    private readonly FileSeeds _seeds;

    public Locations(FileMaps maps, FileSeeds seeds)
    {
        _maps = maps;
        _seeds = seeds;
    }

    public IEnumerable<long> Values() =>
        _seeds.All()
            .Select(CalculateLocation);

    private long CalculateLocation(long seed)
    {
        var number = seed;

        foreach (var map in _maps.All())
        {
            number = map.Convert(number);
        }

        return number;
    }
}