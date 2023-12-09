namespace Day06.WaitForIt;

public class ManyRacesRecordParser : IRecordParser
{
    public IEnumerable<Record> Parse(string times, string distances)
    {
        var timesArray = ParseLine(times);
        var distancesArray = ParseLine(distances);

        for (var i = 0; i < timesArray.Length; i++)
            yield return new Record(timesArray[i], distancesArray[i]);
    }

    private static int[] ParseLine(string line) =>
        line
            .Split(':')[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
}