using System;
using System.Linq;
using Xunit;
using static LeetCode.Solutions.Hard.WordBreak2_140;

namespace LeetCode.Tests.Hard
{
    public class WordBreak2_140_Tests
    {
        [Theory(Skip = "Not implemented yet")]
        [InlineData("catsanddog", "cat,cats,and,sand,dog", "cats and dog,cat sand dog")]
        [InlineData("aaaa", "a,aa,aaa,aaaa", "a a a a,aa a a,a aa a,aaa a,a a aa,aa aa,a aaa,aaaa")]
        public void WordBreak_Tests(string s, string words, string expWords)
        {
            var expected = expWords.Split(",").ToList();
            var wordDict = words.Split(",").ToList();

            var actual = WordBreak(s, wordDict);

            Assert.Equal(expected.Count, actual.Count);

            actual = actual.OrderBy(v => v).ToList();
            expected = expected.OrderBy(v => v).ToList();

            for (var i = 0; i < expected.Count; ++i)
            {
                Assert.Equal(expected[i], actual[i]);
            }
        }
    }
}
