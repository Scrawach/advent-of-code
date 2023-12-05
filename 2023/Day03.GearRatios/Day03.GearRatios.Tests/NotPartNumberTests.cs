using Common.Text;
using FluentAssertions;

namespace Day03.GearRatios.Tests;

public class NotPartNumberTests
{
    [TestCase("example.txt", 4361)]
    [TestCase("task.txt", 539590)]
    public void WhenCondition_ThenExpectation(string filename, int expected)
    {
        // arrange
        var notPartNumber = new NotPartNumbers(new FileText(Path.Combine(Environment.CurrentDirectory, filename)));

        // act
        var sum = notPartNumber.Numbers().Sum();

        // answer
        sum.Should().Be(expected);
    }
}