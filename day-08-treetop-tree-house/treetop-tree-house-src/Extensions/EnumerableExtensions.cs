using System;
using System.Collections.Generic;

namespace treetop_tree_house_src.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TElement> TakeWhileIncluding<TElement>(this IEnumerable<TElement> self, Func<TElement, bool> predicate)
        {
            foreach(var element in self)
            {
                yield return element;
                
                if (!predicate(element))
                    yield break;
            }
        }
    }
}