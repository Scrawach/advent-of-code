using System.Collections.Generic;

namespace supply_stacks_src.Storages
{
    public static class ListExtensions
    {
        public static IEnumerable<List<TValue>> PerItemReverse<TValue>(this IEnumerable<List<TValue>> self)
        {
            foreach (var list in self)
            {
                list.Reverse();
                yield return list;
            }
        }

        public static void FillEmpties<TValue>(this List<TValue> self, int capacity) where  TValue : new()
        {
            for (var i = 0; i < capacity; i++)
                self.Add(new TValue());
        }
    }
}