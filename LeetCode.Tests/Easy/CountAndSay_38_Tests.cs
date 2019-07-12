using LeetCode.Solutions.Easy;
using Xunit;

namespace LeetCode.Tests.Easy
{
    public class CountAndSay_38_Tests
    {
        [Theory]
        [InlineData(0, null)]
        [InlineData(1, "1")]
        [InlineData(2, "11")]
        [InlineData(3, "21")]
        [InlineData(4, "1211")]
        [InlineData(5, "111221")]
        [InlineData(6, "312211")]
        [InlineData(7, "13112221")]
        [InlineData(8, "1113213211")]
        [InlineData(9, "31131211131221")]
        [InlineData(31, null)]
        public void CountAndSayTests(int n, string expected)
        {
            var actual = CountAndSay_38.CountAndSay(n);

            Assert.Equal(expected, actual);
        }
    }
}
