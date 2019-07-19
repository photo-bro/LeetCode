using System;
using Xunit;
using static LeetCode.Solutions.Medium.DivideTwoIntegers_29;
namespace LeetCode.Tests.Medium
{
    public class DivideTwoIntegers_29_Tests
    {
        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(10, -2, -5)]
        [InlineData(-10, -2, 5)]
        [InlineData(2, 2, 1)]
        [InlineData(0, 2, 0)]
        [InlineData(1, 2, 0)]
        [InlineData(1, -2, 0)]
        [InlineData(-1, -2, 0)]
        [InlineData(10, 3, 3)]
        [InlineData(7, -3, -2)]
        [InlineData(7, 3, 2)]
        [InlineData(-2147483648, -1, 2147483647)]
        [InlineData(-2147483648, 1, -2147483648)]
        [InlineData(-2147483648, 2, -1073741824)]
        [InlineData(-2147483648, -3, 715827882)]
        [InlineData(-1021989372, -82778243, 12)]
        [InlineData(-2147483648, 122481295, -17)]
        public void Divide_Tests(int dividend, int divisor, int expected)
        {
            var actual = Divide(dividend, divisor);
            Assert.Equal(expected, actual);
        }
    }
}
