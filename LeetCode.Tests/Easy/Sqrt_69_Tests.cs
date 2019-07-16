using Xunit;
using static LeetCode.Solutions.Easy.Sqrt_69;
namespace LeetCode.Tests.Easy
{
    public class Sqrt_69_Tests
    {
        [Theory]
        [InlineData(4, 2)]
        [InlineData(9, 3)]
        [InlineData(8, 2)]
        [InlineData(2147395599, 46339)]
        [InlineData(2147395600, 46340)]
        public void MySqrt_Tests(int x, int expected)
        {
            var actual = MySqrt(x);
            Assert.Equal(expected, actual);
        }
    }
}