namespace Day05.IfYouGiveASeedAFertilizer;

public class SecondTaskFileSeeds : ISeeds
{
    public readonly FileSeeds _seeds;

    public SecondTaskFileSeeds(FileSeeds seeds) =>
        _seeds = seeds;

    public IEnumerable<long> All()
    {
        foreach (var seeds in _seeds.All().Chunk(2))
        {
            var start = seeds[0];
            var range = seeds[1];

            for (var i = 0; i < range; i++)
                yield return start + i;
        }
    }
}