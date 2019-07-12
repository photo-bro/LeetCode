using System;

namespace LeetCode.Solutions.Easy
{
    public static class Implement_StrStr_28
    {
        public static int StrStr(string haystack, string needle) => haystack.AsSpan().IndexOf(needle);
    }
}
