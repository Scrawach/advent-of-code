using Common.Text;
using FluentAssertions;

namespace Day06.WaitForIt.Tests;

public class Tests
{
    [TestCase("example.txt", 288)]
    [TestCase("task.txt", 503424)]
    public void FirstTask(string filename, int expected)
    {
        // arrange
        var winningWays = new WinningScore
        (
            new NumberOfWinningWays
            (
            new RecordDocument
                (
                    new FileText(Path.Combine(Environment.CurrentDirectory, filename)),
                    new ManyRacesRecordParser()
                )
            )
        );

        // act
        var score = winningWays.Score();

        // assert
        score.Should().Be(expected);
    }
    
    [TestCase("example.txt", 71503)]
    [TestCase("task.txt", 32607562)]
    public void SecondTask(string filename, int expected)
    {
        // arrange
        var winningWays = new WinningScore
        (
            new NumberOfWinningWays
            (
                new RecordDocument
                (
                    new FileText(Path.Combine(Environment.CurrentDirectory, filename)),
                    new OneRaceRecordParser()
                )
            )
        );

        // act
        var score = winningWays.Score();

        // assert
        score.Should().Be(expected);
    }
}