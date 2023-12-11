using Common.Text;
using FluentAssertions;

namespace Day05.IfYouGiveASeedAFertilizer.Tests;

public class Test
{
    [TestCase("example.txt", 35)]
    [TestCase("task.txt", 579439039L)]
    public void FirstTask(string filename, long expected)
    {
        // arrange
        var lowestLocation = new LowestLocation
        (
            new Locations
            (
                new FileMaps
                (
                    new FileText(Path.Combine(Environment.CurrentDirectory, filename))
                ),
                new FileSeeds
                (
                    new FileText(Path.Combine(Environment.CurrentDirectory, filename))
                )
            )
        );

        // act
        var value = lowestLocation.Value();

        // answer
        value.Should().Be(expected);
    }
    
    [TestCase("example.txt", 46)]
    [TestCase("task.txt", 0)]
    public void SecondTask(string filename, long expected)
    {
        // arrange
        var lowestLocation = new LowestLocation
        (
            new Locations
            (
                new FileMaps
                (
                    new FileText(Path.Combine(Environment.CurrentDirectory, filename))
                ),
                new SecondTaskFileSeeds
                (
                    new FileSeeds
                    (
                        new FileText(Path.Combine(Environment.CurrentDirectory, filename))
                    )
                )
            )
        );

        // act
        var value = lowestLocation.Value();

        // answer
        value.Should().Be(expected);
    }
}