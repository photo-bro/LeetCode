using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Solutions
{
    ////// L o n g e s t   P a l i n d r o m i c   S u b s t r i n g - M E D I U M //////
    ///
    ///  Given a string s, find the longest palindromic substring in s.You may
    ///  assume that the maximum length of s is 1000.
    ///
    /// Example 1:
    /// Input: "babad"
    /// Output: "bab"
    /// Note: "aba" is also a valid answer.
    /// 
    /// Example 2:
    /// Input: "cbbd"
    /// Output: "bb"
    ///
    ////// L o n g e s t   P a l i n d r o m i c   S u b s t r i n g - M E D I U M //////
    public static class LongestPalindromicSubstring_5
    {
        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            if (s.Length == 1)
                return s;

            if (s.Length == 2)
                return s[0] == s[1] ? s : string.Empty;

            var span = s.AsSpan();

            var left = 0;
            var end = 0;
            for (var i = 0; i < span.Length; ++i)
            {
                var l1 = ExpandOut(s, i, i);
                var l2 = ExpandOut(s, i, i + 1);
                var l = l1 > l2 ? l1 : l2;
                if (l > end - left)
                {
                    left = i - ((l - 1) / 2);
                    end = i + (l / 2);
                }
            }
            return span.Slice(left, end - left + 1).ToString();
        }

        private static int ExpandOut(ReadOnlySpan<char> s, int l, int r)
        {
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                --l;
                ++r;
            }

            return r - l - 1;
        }

        public static bool IsPalindrome(this ReadOnlySpan<char> s, int i, int j)
        {
            if (s[i] == s[j])
            {
                if (i == j)
                    return true;

                if (i + 1 == j)
                    return true;

                if (s.IsPalindrome(i + 1, j - 1))
                    return true;
            }

            return false;
        }
    }
}
