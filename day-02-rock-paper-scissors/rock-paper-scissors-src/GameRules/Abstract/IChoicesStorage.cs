using System.Collections.Generic;

namespace rock_paper_scissors_src.GameRules.Abstract
{
    public interface IChoicesStorage
    {
        IReadOnlyList<string> AvailableChoices();
    }
}