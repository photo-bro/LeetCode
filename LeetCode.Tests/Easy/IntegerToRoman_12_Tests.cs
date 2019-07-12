using LeetCode.Solutions.Easy;
using Xunit;

namespace LeetCode.Tests.Easy
{
    public class IntegerToRoman_12_Tests
    {
        [Theory]
        [InlineData(1,"I")]
        [InlineData(4,"IV")]
        [InlineData(5,"V")]
        [InlineData(9,"IX")]
        [InlineData(10,"X")]
        [InlineData(13,"XIII")]
        [InlineData(49,"XLIX")]
        [InlineData(99, "XCIX")]
        [InlineData(3999, "MMMCMXCIX")]
        public void IntToRomanTests(int num, string expected)
        {
            var actual = IntegerToRoman_12.IntToRoman(num);
            Assert.Equal(expected, actual);
        }
    }
}
