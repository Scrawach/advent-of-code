using System;

namespace no_space_left_on_device_tests.Utils
{
    public static class Working
    {
        public static readonly string Directory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];
    }
}