using System.Collections.Generic;

namespace rock_paper_scissors_src.Rounds.Abstract
{
    public interface IText
    {
        IEnumerable<string> Lines();
    }
}