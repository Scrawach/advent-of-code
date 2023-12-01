using System.Collections.Generic;

namespace distress_signal_src.Comparer
{
    public class RightOrderComparer : IComparer<string>
    {
        public int Compare(string left, string right)
        {
            if (left == right) return 0;
            return IsRightOrder(left, right) ? -1 : 1;
        }

        private static bool IsRightOrder(string left, string right)
        {
            var (leftHead, leftTail) = (left[0], left[1..]);
            var (rightHead, rightTail) = (right[0], right[1..]);

            return (leftHead, rightHead) switch
            {
                var (l, r) when l == r => IsRightOrder(leftTail, rightTail),
                (_, ']') => false,
                (']', _) => true,
                ('[', var r) => IsRightOrder(leftTail, $"{r}]{rightTail}"),
                (var l, '[') => IsRightOrder($"{l}]{leftTail}", rightTail),
                var (l, r) => l < r,
            };
        }
    }
}