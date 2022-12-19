using System.Collections.Generic;
using rope_bridge_src.Commands;
using rope_bridge_src.Commands.Abstract;

namespace rope_bridge_src.Storages.Abstract
{
    public interface ICommandsStorage
    {
        IEnumerable<IHeadCommand> All();
    }
}