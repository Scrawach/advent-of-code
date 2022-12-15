using System.Collections.Generic;

namespace no_space_left_on_device_src.Disk.Abstract
{
    public interface ITree<TValue> : IEnumerable<TValue>
    {
        public TValue Value { get; }
        ITree<TValue> Parent { get; }
        IList<ITree<TValue>> Children { get; }
        ITree<TValue> AddChild(TValue value);
    }
}