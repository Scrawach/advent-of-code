using System.Collections.Generic;
using distress_signal_src.Comparer;
using distress_signal_src.Logic;
using distress_signal_src.Logic.Abstract;
using distress_signal_src.Storages.Abstract;

namespace distress_signal_src.Storages
{
    public class PacketTextStorage : IPacketStorage
    {
        private readonly IText _text;
        private readonly IComparer<string> _comparer;

        public PacketTextStorage(IText text, IComparer<string> comparer)
        {
            _text = text;
            _comparer = comparer;
        }

        public IEnumerable<IPacket> All()
        {
            var previousLine = string.Empty;

            foreach (var line in _text.Lines())
            {
                if (IsLineWithData(line) && IsSecondLineWithData(previousLine))
                    yield return new Packet(previousLine, line, _comparer);

                previousLine = line;
            }
        }

        private static bool IsLineWithData(string line) =>
            !string.IsNullOrWhiteSpace(line);

        private static bool IsSecondLineWithData(string previousLine) =>
            !string.IsNullOrWhiteSpace(previousLine);
    }
}