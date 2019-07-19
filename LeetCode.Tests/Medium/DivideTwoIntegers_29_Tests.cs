using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Xunit;
using Xunit.Abstractions;
using static LeetCode.Solutions.Medium.DivideTwoIntegers_29;
namespace LeetCode.Tests.Medium
{
    public class DivideTwoIntegers_29_Tests
    {
        private readonly ITestOutputHelper _testOutput;
        public DivideTwoIntegers_29_Tests(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

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
        [InlineData(-2147483648, 2147483647, -1)]
        [InlineData(2147483647, -2147483648, 0)]
        [InlineData(2147483647, -2147483647, -1)]
        public void Divide_Tests(int dividend, int divisor, int expected)
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                var actual = Divide(dividend, divisor);
                _testOutput.WriteLine(sw.ToString());
                Assert.Equal(expected, actual);
            }
        }
    }
}
