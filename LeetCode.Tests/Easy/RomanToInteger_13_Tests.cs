using LeetCode.Solutions.Easy;
using Xunit;

namespace LeetCode.Tests.Easy
{
    public class RomanToInteger_13_Tests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("I", 1)]
        [InlineData("V", 5)]
        [InlineData("X", 10)]
        [InlineData("L", 50)]
        [InlineData("C", 100)]
        [InlineData("D", 500)]
        [InlineData("M", 1000)]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("IX", 9)]
        [InlineData("XL", 40)]
        [InlineData("XC", 90)]
        [InlineData("CD", 400)]
        [InlineData("CM", 900)]
        [InlineData("XXVII", 27)]
        [InlineData("XII", 12)]
        [InlineData("MMMDCCCLXXXVIII", 3888)]
        [InlineData("MMMCMXCIX", 3999)]
        public void RomanToInt_Tests(string roman, int expected)
        {
            var actual = RomanToInteger_13.RomanToInt(roman);
            Assert.Equal(expected, actual);
        }
    }
}
