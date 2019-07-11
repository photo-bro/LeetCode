using System;
using System.Linq;
using Xunit;
using static LeetCode.Solutions.MaximumSubarray_53;

namespace LeetCode.Tests
{
    public class MaximumSubarray_53_tests
    {
        [Theory]
        [InlineData("-2,1,-3,4,-1,2,1,-5,4", 6)]
        [InlineData("-2,1", 1)]
        [InlineData("2,1", 3)]
        public void MaxSubArray_Tests(string nums, int expected)
        {
            var n = nums.Split(",").Select(int.Parse).ToArray();
            var actual = MaxSubArray(n);
            Assert.Equal(expected, actual);
        }
    }
}
