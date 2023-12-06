using Common.Text;
using FluentAssertions;

namespace Day04.Scratchcards.Tests;

public class TotalPointsTests
{
    [TestCase("example.txt", 13)]
    [TestCase("task.txt", 23441)]
    public void FirstTask(string filename, int expected)
    {
        // arrange
        var points = new TotalPoints
        (
            new Cards
            (
                new FileText(Path.Combine(Environment.CurrentDirectory, filename))
            )
        );

        // act
        var cards = points.Value();

        // answer
        cards.Should().Be(expected);
    }

    [TestCase("example.txt", 30)]
    [TestCase("task.txt", 5923918)]
    public void SecondTask(string filename, int expected)
    {
        // arrange
        var points = new TotalCardsPlayed
        (
            new Cards
            (
                new FileText(Path.Combine(Environment.CurrentDirectory, filename))
            )
        );

        // act
        var cards = points.Value();

        // answer
        cards.Should().Be(expected);
    }
}