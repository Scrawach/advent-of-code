using Common.Text;
using Day02.CubeConundrum.Common;
using Day02.CubeConundrum.SecondTask;
using FluentAssertions;

namespace Day02.CubeConundrum.Tests;

public class SecondTask
{
    [TestCase("example.txt", 2286)]
    [TestCase("task.txt", 78111)]
    public void WhenCalculateSumValue_ThenShouldReturn_SumOfPower_ForEveryGameSet(string filename, int expected)
    {
        // arrange
        var sum = new SumOfPowerGameSets
        (
            new GameSets
            (
                new FileText(Path.Combine(Environment.CurrentDirectory, filename)), 
                new GameSetParser()
            )
        );
        
        // act
        var result = sum.Value();

        // assert
        result.Should().Be(expected);
    }
}