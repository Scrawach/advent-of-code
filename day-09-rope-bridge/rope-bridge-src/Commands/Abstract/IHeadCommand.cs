using rope_bridge_src.Logic;

namespace rope_bridge_src.Commands.Abstract
{
    public interface IHeadCommand
    {
        void Execute(IHead head);
    }
}