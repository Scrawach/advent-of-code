using System;
using tuning_trouble_src.Storages;

namespace tuning_trouble_src
{
    public class Packet
    {
        private readonly string _content;

        public Packet(string content) =>
            _content = content;
        
        public int Marker(int uniqueLength) =>
            ProcessedSymbols(uniqueLength);

        private int ProcessedSymbols(int uniqueSequenceLength)
        {
            var queue = new ConstantQueue<char>(uniqueSequenceLength);
            
            for (var i = 0; i < _content.Length; i++)
            {
                queue.Enqueue(_content[i]);
                if ((i >= uniqueSequenceLength - 1) && queue.IsUnique())
                    return i + 1;
            }

            throw new ArgumentException(nameof(ProcessedSymbols));
        }
    }
}