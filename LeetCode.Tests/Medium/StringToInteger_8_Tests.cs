using LeetCode.Solutions.Medium;
using Xunit;

namespace LeetCode.Tests.Medium
{
    public class StringToInteger_8_Tests
    {
        [Theory]
        [InlineData("42", 42)]
        [InlineData("   -42", -42)]
        [InlineData("     ", 0)]
        [InlineData("+", 0)]
        [InlineData("-", 0)]
        [InlineData("+-", 0)]
        [InlineData("+-2", 0)]
        [InlineData("4193 with words", 4193)]
        [InlineData("words and 987", 0)]
        [InlineData("  0000000000012345678", 12345678)]
        [InlineData("    0000000000000   ", 0)]
        [InlineData("-000000000000001", -1)]
        [InlineData("-91283472332", -2147483648)]
        [InlineData("  -0012a42", -12)]
        [InlineData("    +0a32", 0)]
        [InlineData("-2147483647", -2147483647)]
        [InlineData("-5-", -5)]
        [InlineData("20000000000000", 2147483647)]
        public void atoiTests(string s, int expected)
        {
            var actual = StringToInteger_8.atoi(s);

            Assert.Equal(expected, actual);
        }
    }
}
