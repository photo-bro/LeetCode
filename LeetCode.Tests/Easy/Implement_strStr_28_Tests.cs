using LeetCode.Solutions.Easy;
using Xunit;

namespace LeetCode.Tests.Easy
{
    public class Implement_strStr_28_Tests
    {
        [Theory]
        [InlineData("hello", "ll", 2)]
        [InlineData("aaaaa", "bba", -1)]
        public void Implement_strStr(string haystack, string needle, int expected)
        {
            var actual = Implement_StrStr_28.StrStr(haystack, needle);
            Assert.Equal(expected, actual);
        }
    }
}
