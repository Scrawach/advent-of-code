namespace rock_paper_scissors_src.Rounds.Convert
{
    public interface IConverter
    {
        Round Convert(string first, string second);
    }
}