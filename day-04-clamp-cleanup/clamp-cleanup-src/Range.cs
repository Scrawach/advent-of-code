namespace clamp_cleanup_src
{
    public class Range
    {
        private readonly int _start;
        private readonly int _end;

        public Range(int start, int end)
        {
            _start = start;
            _end = end;
        }
        
        public bool Contains(Range other) =>
            other._start >= _start && other._end <= _end;

        public bool IsOverlap(Range other) =>
            other._end >= _start && other._start <= _end;
    }
}