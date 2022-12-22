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
            var sum = 0;
            
            for (var i = 0; i < _packets.Length; i++)
            {
                if (_packets[i].IsRightOrder())
                    sum += (i + 1);
            }

            return sum;
        }
    }
}