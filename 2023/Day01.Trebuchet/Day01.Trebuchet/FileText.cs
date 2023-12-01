namespace Day01.Trebuchet;

public class FileText : IText
{
    private readonly string _pathToFile;

    public FileText(string pathToFile) =>
        _pathToFile = pathToFile;

    public IEnumerable<string> Lines() =>
        File.ReadAllLines(_pathToFile);
}