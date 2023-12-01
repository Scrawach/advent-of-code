using System;
using System.IO;
using System.Linq;
using beacon_exclusion_zone_src.Data;
using beacon_exclusion_zone_src.Logic;
using beacon_exclusion_zone_src.Storages;
using beacon_exclusion_zone_src.Storages.Abstract;

namespace beacon_exclusion_zone_src.Factory
{
    public class SolvesFactory
    {
        private static readonly string WorkingDirectory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];

        private readonly string _fileName;

        public SolvesFactory(string fileName) =>
            _fileName = fileName;

        public PositionsWithoutBeacon PositionsWithoutBeacon(int row) =>
            new PositionsWithoutBeacon(row, CreateStorage().All().ToArray());

        public PositionsWithHiddenBeacon PositionsWithHiddenBeacon(Vector2 min, Vector2 max) =>
            new PositionsWithHiddenBeacon(min, max, CreateStorage().All().ToArray());

        private ISensorStorage CreateStorage()
        {
            var path = Path.Combine(WorkingDirectory, _fileName);
            return new SensorTextStorage(new Text(path));
        }
    }
}