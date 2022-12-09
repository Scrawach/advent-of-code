using System.Collections.Generic;

namespace tuning_trouble_src.Storages
{
    public class ConstantQueue<TValue>
    {
        private readonly TValue[] _values;
        private int _head;

        public ConstantQueue(int capacity) =>
            _values = new TValue[capacity];

        public void Enqueue(TValue value)
        {
            _values[_head] = value;
            _head++;

            if (_head > _values.Length - 1) 
                _head = 0;
        }
        
        public bool IsUnique()
        {
            var hash = new HashSet<TValue>();
            
            foreach (var value in _values)
            {
                if (hash.Contains(value))
                    return false;
                
                hash.Add(value);
            }

            return true;
        }
    }
}