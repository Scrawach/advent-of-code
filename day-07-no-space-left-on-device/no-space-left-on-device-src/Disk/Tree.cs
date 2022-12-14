using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace no_space_left_on_device_src.Disk
{
    public class Tree<TValue> : IEnumerable<TValue>
    {
        public readonly TValue Value;
        public Tree<TValue> Parent;
        public readonly LinkedList<Tree<TValue>> Children;

        public Tree(TValue value)
        {
            Value = value;
            Children = new LinkedList<Tree<TValue>>();
        }

        public Tree<TValue> AddChild(TValue value)
        {
            var tree = new Tree<TValue>(value) { Parent = this };
            Children.AddFirst(tree);
            return tree;
        }
        
        public IEnumerator<TValue> GetEnumerator()
        {
            yield return Value;
            foreach (var child in Children.SelectMany(child => child))
                yield return child;
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}