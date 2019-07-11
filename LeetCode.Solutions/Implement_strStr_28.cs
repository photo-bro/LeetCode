using System;

namespace LeetCode.Solutions
{
    public static class Implement_strStr_28
    {
        public static int StrStr(string haystack, string needle) => haystack.AsSpan().IndexOf(needle);
    }
}
