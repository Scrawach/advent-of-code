using System;

namespace supply_stacks_tests
{
    public static class Working
    {
        public static readonly string Directory = Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];
    }
}