using System.Collections.Generic;
using supply_stacks_src.Commands.Abstract;

namespace supply_stacks_src.Storages.Abstract
{
    public interface ICommandStorage
    {
        IEnumerable<ICommand> All();
    }
}