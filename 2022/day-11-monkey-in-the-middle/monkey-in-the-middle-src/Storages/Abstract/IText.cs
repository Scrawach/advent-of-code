using System.Collections.Generic;

namespace monkey_in_the_middle_src.Storages.Abstract
{
    public interface IText
    {
        string All();
        IEnumerable<string> Lines();
    }
}