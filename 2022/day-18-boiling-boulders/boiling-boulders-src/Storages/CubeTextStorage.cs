using System.Collections.Generic;
using boiling_boulders_src.Data;
using boiling_boulders_src.Storages.Abstract;

namespace boiling_boulders_src.Storages
{
    public class CubeTextStorage : ICubeStorage
    {
        private readonly IText _text;

        public CubeTextStorage(IText text) =>
            _text = text;
        
        public IEnumerable<Vector3> All()
        {
            const char coordsSeparator = ',';
            foreach (var line in _text.Lines())
            {
                var split = line.Split(coordsSeparator);
                yield return new Vector3
                (
                    int.Parse(split[0]),
                    int.Parse(split[1]),
                    int.Parse(split[2])
                );
            }
        }
    }
}