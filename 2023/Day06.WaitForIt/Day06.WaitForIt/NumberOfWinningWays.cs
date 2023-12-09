namespace Day06.WaitForIt;

public class NumberOfWinningWays
{
    private readonly RecordDocument _records;

    public NumberOfWinningWays(RecordDocument records) =>
        _records = records;

    public IEnumerable<long> Numbers()
    {
        foreach (var record in _records.All())
            yield return Simulate(record);
    }

    private static long Simulate(Record record)
    {
        var winningCount = 0;
        
        for (var i = 1; i < record.Time; i++)
        {
            var remainingTime = record.Time - i;
            var maxDistance = remainingTime * i;
            if (maxDistance > record.Distance)
                winningCount++;
        }

        return winningCount;
    }
}