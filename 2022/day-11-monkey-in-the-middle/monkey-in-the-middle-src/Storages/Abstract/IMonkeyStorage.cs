using System.Collections.Generic;
using monkey_in_the_middle_src.Logic;

namespace monkey_in_the_middle_src.Storages.Abstract
{
    public interface IMonkeyStorage
    {
        IEnumerable<Monkey> All();
    }
}