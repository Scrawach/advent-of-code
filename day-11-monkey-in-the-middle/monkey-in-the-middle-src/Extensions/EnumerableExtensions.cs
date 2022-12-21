using System;
using System.Collections.Generic;
using System.Linq;

namespace monkey_in_the_middle_src.Extensions
{
    public static class EnumerableExtensions
    {
        public static long Multiply<TValue>(this IEnumerable<TValue> self, Func<TValue, long> selector) =>
            self.Aggregate(1L, (current, value) => current * selector.Invoke(value));
    }
}