namespace clamp_cleanup_src.Logic
{
    public readonly struct PairRange
    {
        public readonly Range First;
        public readonly Range Second;

        public PairRange(Range first, Range second)
        {
            First = first;
            Second = second;
        }

        public bool ContainsEachOther() =>
            First.Contains(Second) || Second.Contains(First);

        public bool IsOverlap() =>
            First.IsOverlap(Second) || Second.IsOverlap(First);
    }
}