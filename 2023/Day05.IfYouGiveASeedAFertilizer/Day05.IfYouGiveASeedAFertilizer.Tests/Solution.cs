using Common.Text;
using FluentAssertions;

namespace Day05.IfYouGiveASeedAFertilizer.Tests;

public class Test
{
    [TestCase("example.txt", 35)]
    [TestCase("task.txt", 0)]
    public void FirstTask(string filename, int expected)
    {
        // arrange
        var seeds = new FileSeeds(new FileText(Path.Combine(Environment.CurrentDirectory, filename)));
        var maps = new FileMaps(new FileText(Path.Combine(Environment.CurrentDirectory, filename)));
        var locations = new Locations(maps, seeds);
        var lowestLocation = new LowestLocation(locations);

        // act
        var value = lowestLocation.Value();

        // answer
        value.Should().Be(expected);
    }
}