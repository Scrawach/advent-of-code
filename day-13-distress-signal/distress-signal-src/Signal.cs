using distress_signal_src.Data;

namespace distress_signal_src
{
    public class Signal
    {
        private readonly IPacket[] _packets;

        public Signal(params IPacket[] packets) =>
            _packets = packets;

        public int SumOfIndicesRightPairs()
        {
            return 0;
        }
    }
}