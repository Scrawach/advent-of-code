using System.Collections;
using System.Collections.Generic;
using System.Linq;
using no_space_left_on_device_src.Disk.Abstract;

namespace no_space_left_on_device_src.Disk
{
    public class Tree<TValue> : ITree<TValue>
    {
        public TValue Value { get; }
        public ITree<TValue> Parent { get; private set; }
        public IList<ITree<TValue>> Children { get; }

        public Tree(TValue value)
        {
            Value = value;
            Children = new List<ITree<TValue>>();
        }

        public ITree<TValue> AddChild(TValue value)
        {
            var tree = new Tree<TValue>(value) { Parent = this };
            Children.Add(tree);
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