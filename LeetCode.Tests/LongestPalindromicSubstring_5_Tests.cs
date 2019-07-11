using System;
using System.Linq;
using System.Timers;
using Xunit;

using static LeetCode.Solutions.LongestPalindromicSubstring_5;

namespace LeetCode.Tests
{
    public class LongestPalindromicSubstring_5_Tests
    {
        [Theory]
        [InlineData("babad", "bab,aba")]
        [InlineData("cbbd", "bb")]
        [InlineData("aba", "aba")]
        [InlineData("fgcdabba", "abba")]
        [InlineData("abcdabba", "abba")]
        [InlineData("abcdabbaed", "abba")]
        [InlineData("abbabcda", "abba")]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("aa", "aa")]
        [InlineData("ab", "")]
        public void LongestPalindromeTests(string str, string answers)
        {
            var expected = answers.Split(",");
            var actual = LongestPalindrome(str);

            if (expected.Length > 1)
            {
                Assert.True(expected.Any(e => actual == e), $"actual: '{actual}'");
            }
            else
            {
                Assert.Equal(expected[0], actual);
            }
        }

        [Fact]
        public void LongestPalindromeTests_LargeInput()
        {
            var data = Enumerable.Repeat("abcdabbaed", 200).Aggregate((s, i) => string.Concat(s, i));

            void OnTimedEvent(Object source, ElapsedEventArgs e) => throw new Exception("Too long!");

            var timer = new Timer(5 * 1000);
            timer.Elapsed += OnTimedEvent;

            try
            {
                timer.Start();
                var actual = LongestPalindrome(data);
                timer.Stop();
            }
            finally
            {
                timer.Dispose();
            }
        }

        [Theory]
        [InlineData("abba",true)]
        [InlineData("aba",true)]
        [InlineData("abcba",true)]
        [InlineData("aa",true)]
        [InlineData("a",true)]
        [InlineData("ab",false)]
        [InlineData("ed",false)]
        [InlineData("abc",false)]
        [InlineData("aera",false)]
        public void IsPalindromeTests(string s, bool expected)
        {
            var actual = s.AsSpan().IsPalindrome(0, s.Length - 1);
            Assert.Equal(expected, actual);
        }
    }
}
