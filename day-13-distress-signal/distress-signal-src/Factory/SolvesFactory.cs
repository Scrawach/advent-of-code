using System;
using System.IO;
using System.Linq;
using distress_signal_src.Comparer;
using distress_signal_src.Logic;
using distress_signal_src.Storages;
using distress_signal_src.Storages.Abstract;

namespace distress_signal_src.Factory
{
    public class SolvesFactory
    {
        private static readonly string WorkingDirectory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];
        
        private readonly string _fileName;

        public SolvesFactory(string fileName) =>
            _fileName = fileName;
        
        public Signal CreateSignal()
        {
            var text = CreateText();
            var storage = new PacketTextStorage(text, new RightOrderComparer());
            return new Signal(storage.All().ToArray());
        }

        public DecoderKey CreateDecoder() =>
            new DecoderKey(CreateText(), new RightOrderComparer(), new []{"[[2]]", "[[6]]"});

        private IText CreateText()
        {
            var path = Path.Combine(WorkingDirectory, _fileName);
            var text = new Text(path);
            return new WithoutBigNumbersText(text);
        }
    }
}