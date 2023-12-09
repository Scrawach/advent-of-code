namespace Day06.WaitForIt;

public interface IRecordParser
{
    IEnumerable<Record> Parse(string times, string distances);
}