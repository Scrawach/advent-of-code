namespace Day01.Trebuchet;

public class SumOfCalibrationValues
{
    private readonly CalibrationDocument _document;

    public SumOfCalibrationValues(CalibrationDocument document) =>
        _document = document;

    public int Value() =>
        _document.Values().Sum();
}