namespace Day02.CubeConundrum.FirstTask;

public class SumOfIdOfPossibleGameSets
{
    private readonly PossibleGameSets _gameSets;

    public SumOfIdOfPossibleGameSets(PossibleGameSets gameSets) =>
        _gameSets = gameSets;

    public int Value() =>
        _gameSets.All()
            .Sum(bag => bag.Id);
}