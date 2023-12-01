using System.Collections.Generic;

namespace tuning_trouble_src.Storages
{
    public class ConstantQueue<TValue>
    {
        private readonly TValue[] _values;
        private readonly HashSet<TValue> _map;
        private int _head;

        public ConstantQueue(int capacity)
        {
            _values = new TValue[capacity];
            _map = new HashSet<TValue>(capacity);
        }

        public void Enqueue(TValue value)
        {
            _values[_head] = value;
            _head++;

            if (_head > _values.Length - 1) 
                _head = 0;
        }
        
        public bool IsUnique()
        {
            _map.Clear();

            foreach (var value in _values)
            {
                if (_map.Contains(value))
                    return false;
                
                _map.Add(value);
            }

            return true;
        }
    }
}