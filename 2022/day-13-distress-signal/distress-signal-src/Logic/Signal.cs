using System.Linq;
using distress_signal_src.Logic.Abstract;

namespace distress_signal_src.Logic
{
    public class Signal
    {
        private readonly IPacket[] _packets;

        public Signal(params IPacket[] packets) =>
            _packets = packets;

        public int SumOfIndicesRightPairs() =>
            _packets
                .Select((value, index) => (value, index + 1))
                .Where(packet => packet.value.IsRightOrder())
                .Select(tuple => tuple.Item2)
                .Sum();
    }
}