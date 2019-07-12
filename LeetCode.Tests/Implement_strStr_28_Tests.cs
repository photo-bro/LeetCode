using Xunit;
using static LeetCode.Solutions.Easy.Implement_StrStr_28;
namespace LeetCode.Tests
{
    public class Implement_strStr_28_Tests
    {
        [Theory]
        [InlineData("hello", "ll", 2)]
        [InlineData("aaaaa", "bba", -1)]
        public void Implement_strStr(string haystack, string needle, int expected)
        {
            var actual = StrStr(haystack, needle);
            Assert.Equal(expected, actual);
        }
    }
}
