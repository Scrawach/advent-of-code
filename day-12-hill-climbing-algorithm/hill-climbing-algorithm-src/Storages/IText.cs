using System.Collections.Generic;

namespace hill_climbing_algorithm_src.Storages
{
    public interface IText
    {
        IEnumerable<string> Lines();
    }
}