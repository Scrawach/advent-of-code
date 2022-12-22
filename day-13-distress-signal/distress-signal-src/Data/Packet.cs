using System;

namespace distress_signal_src.Data
{
    public class Packet
    {
        private readonly string _left;
        private readonly string _right;

        public Packet(string left, string right)
        {
            _left = left;
            _right = right;
        }

        public bool IsRightOrder() =>
            IsRightOrder(_left, _right);

        private static bool IsRightOrder(string left, string right)
        {
            var (leftHead, leftTail) = (left[0], left[1..]);
            var (rightHead, rightTail) = (right[0], right[1..]);

            return (leftHead, rightHead) switch
            {
                var (l, r) when l == r => IsRightOrder(leftTail, rightTail),
                (_, ']') => false,
                (']', _) => true,
                ('[', _) => IsRightOrder(leftTail, right),
                (_, '[') => IsRightOrder(left, rightTail),
                var (l, r) => l < r,
            };
        }
    }
}