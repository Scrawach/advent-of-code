using System.Linq;
using clamp_cleanup_src.Storages;

namespace clamp_cleanup_src.Logic
{
    public class Camp
    {
        private readonly PairRangeTextStorage _storage;

        public Camp(PairRangeTextStorage storage) =>
            _storage = storage;

        public int TotalContainsPairs() =>
            _storage.All()
                .Where(pair => pair.ContainsEachOther())
                .Sum(pair => 1);

        public int TotalOverlapPairs() =>
            _storage.All()
                .Where(pair => pair.IsOverlap())
                .Sum(pair => 1);
    }
}