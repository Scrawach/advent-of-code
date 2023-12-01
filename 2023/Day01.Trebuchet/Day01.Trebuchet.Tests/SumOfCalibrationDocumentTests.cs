using FluentAssertions;

namespace Day01.Trebuchet.Tests;

public class SumOfCalibrationDocumentTests
{
    [TestCase("example.txt", 142)]
    [TestCase("task.txt", 54708)]
    public void WhenTextHasNumbersInLines_ThenShouldReturnSumNumbers_ThatTakenFromFirstAndLastNumber_ForEveryLine(string fileName, int expected)
    {
        // arrange 
        var sum = new SumOfCalibrationValues
        (
            new CalibrationDocument
            (
                new FileText(Path.Combine(Environment.CurrentDirectory, fileName)),
                new FirstAndLastNumbers()
            )
        );

        // act
        var result = sum.Value();

        // assert
        result.Should().Be(expected);
    }

    [TestCase("example_text.txt", 281)]
    [TestCase("task.txt", 54100)]
    public void WhenTextHasNumbersInLines_ThenShouldReturnSumNumbers_ThanTakenFromFirstAndLastNumber_OrTextCodedNumber_ForEveryLine(string fileName, int expected)
    {
        // arrange 
        var sum = new SumOfCalibrationValues
        (
            new CalibrationDocument
            (
                new FileText(Path.Combine(Environment.CurrentDirectory, fileName)),
                new FirstAndLastNumbersWithText()
            )
        );

        // act
        var result = sum.Value();

        // assert
        result.Should().Be(expected);
    }
}