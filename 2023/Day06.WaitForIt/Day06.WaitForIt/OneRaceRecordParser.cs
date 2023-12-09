using System.Text;

namespace Day06.WaitForIt;

public class OneRaceRecordParser : IRecordParser
{
    public IEnumerable<Record> Parse(string times, string distances)
    {
        var timesArray = ParseLine(times);
        var distancesArray = ParseLine(distances);
        yield return new Record(ParseAsNumber(timesArray), ParseAsNumber(distancesArray));
    }
    
    private static string[] ParseLine(string line) =>
        line
            .Split(':')[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

    private static long ParseAsNumber(IEnumerable<string> lines)
    {
        var builder = new StringBuilder();
        foreach (var line in lines) 
            builder.Append(line);
        return long.Parse(builder.ToString());
    }
}