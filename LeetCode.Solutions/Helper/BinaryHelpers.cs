using System;
using System.Linq;

namespace LeetCode.Solutions.Helper
{
    public static class BinaryHelpers
    {
        public static string ToFormattedBinaryString(this int n, string delim = "_") =>
            Convert.ToString(n, 2).PadLeft(32, '0')
                   .Select((c, i) => (i, s: c.ToString()))
                   .Aggregate((s, c) => (c.i, s.s + (c.i % 4 == 0 ? $"{delim}{c.s}" : $"{c.s}"))).s;

        public static string ToFormattedBinaryString(this long n, string delim = "_") =>
            Convert.ToString(n, 2).PadLeft(64, '0')
                   .Select((c, i) => (i, s: c.ToString()))
                   .Aggregate((s, c) => (c.i, s.s + (c.i % 4 == 0 ? $"{delim}{c.s}" : $"{c.s}"))).s;

        public static string ToFormattedBinaryString(this short n, string delim = "_") =>
            Convert.ToString(n, 2).PadLeft(16, '0')
                   .Select((c, i) => (i, s: c.ToString()))
                   .Aggregate((s, c) => (c.i, s.s + (c.i % 4 == 0 ? $"{delim}{c.s}" : $"{c.s}"))).s;

        public static string ToFormattedBinaryString(this byte n, string delim = "_") =>
            Convert.ToString(n, 2).PadLeft(8, '0')
                   .Select((c, i) => (i, s: c.ToString()))
                   .Aggregate((s, c) => (c.i, s.s + (c.i % 4 == 0 ? $"{delim}{c.s}" : $"{c.s}"))).s;
    }
}