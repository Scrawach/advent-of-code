using Common.Text;
using Day02.CubeConundrum.Common;
using Day02.CubeConundrum.FirstSolve;
using FluentAssertions;

namespace Day02.CubeConundrum.Tests;

public class FirstTask
{
    [TestCase("example.txt", 8)]
    [TestCase("task.txt", 2545)]
    public void WhenCalculateSumValue_ThenShouldReturnSumOfIds_OfAllPossibleGameSets_ForEveryGames(string fileName, int expected)
    {
        // arrange
        var sum = new SumOfIdOfPossibleGameSets
        (
            new PossibleGameSets
            (
                new GameSets
                (
                    new FileText(Path.Combine(Environment.CurrentDirectory, fileName)),
                    new GameSetParser()
                ),
                new LimitsGameSetPolicy(new Game(12, 14, 13))
            )
        );

        // act
        var result = sum.Value();

        // assert
        result.Should().Be(expected);
    }
}