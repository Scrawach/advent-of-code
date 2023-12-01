using System;

namespace supply_stacks_tests.Utils
{
    public static class Working
    {
        public static readonly string Directory = Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];
    }
}