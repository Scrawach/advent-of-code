using System;
using System.IO;
using rucksack_reorganization_src.Logic;
using rucksack_reorganization_src.Storages;
using rucksack_reorganization_src.Storages.Abstract;

namespace rucksack_reorganization_src.Factory
{
    public class ReorganizationFactory
    {
        private static readonly string WorkingDirectory =
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];

        private readonly string _inputFileName;

        public ReorganizationFactory(string inputFileName) =>
            _inputFileName = inputFileName;

        public RucksackReorganization Single() =>
            Create(new RucksackTextStorage(CreateText()));

        public RucksackReorganization Group() =>
            Create(new SeveralRucksacksTextStorage(CreateText()));

        private RucksackReorganization Create(IRucksackStorage storage) =>
            new RucksackReorganization(storage, new Priority());

        private Text CreateText() =>
            new Text(Path.Combine(WorkingDirectory, _inputFileName));
    }
}