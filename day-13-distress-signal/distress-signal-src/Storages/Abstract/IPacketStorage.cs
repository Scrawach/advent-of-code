using System.Collections.Generic;
using distress_signal_src.Logic.Abstract;

namespace distress_signal_src.Storages.Abstract
{
    public interface IPacketStorage
    {
        IEnumerable<IPacket> All();
    }
}