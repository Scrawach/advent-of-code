using System.Collections.Generic;
using distress_signal_src.Logic.Abstract;

namespace distress_signal_src.Logic
{
    public class Packet : IPacket
    {
        private readonly string _left;
        private readonly string _right;
        private readonly IComparer<string> _comparer;

        public Packet(string left, string right, IComparer<string> comparer)
        {
            _left = left;
            _right = right;
            _comparer = comparer;
        }

        public bool IsRightOrder() =>
            _comparer.Compare(_left, _right) == -1;
    }
}