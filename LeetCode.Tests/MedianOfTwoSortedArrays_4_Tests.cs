using System;
using System.Linq;
using Xunit;

using static LeetCode.Solutions.Hard.MedianOfTwoSortedArrays_4;

namespace LeetCode.Tests
{
    public class MedianOfTwoSortedArrays_4_Tests
    {
        
        [Theory(Skip = "Not working yet...")]
        [InlineData("1,3", "2", 2d)]
        [InlineData("1,2", "3,4", 2.5d)]
        [InlineData("1,2,9,10", "5,6,7,8", 6.5d)]
        [InlineData("1,2,9,10", "5", 5d)]
        [InlineData("1", "1", 1d)]
        [InlineData("1", "2", 1.5d)]
        [InlineData("0", "0", 0d)]
        [InlineData("1,2,3,4,5,6,7", "0", 3.5d)]
        [InlineData("1,2,3,4,5,6,7", "", 4d)]
        [InlineData("1,1", "1,1", 1d)]
        [InlineData("1,1", "1,1,1,1,1,1,1,1,1", 1d)]
        [InlineData("1", "1,1,1,1,1,1,1,1,1", 1d)]
        [InlineData("4,5,6,7", "1,2,3", 4d)]
        [InlineData("7,8,9,10", "0,1,1,1,2", 2d)]
        public void MedianOfTwoSortedArrays_Tests(string nums1, string nums2, double expected)
        {
            var n1 = nums1.Length != 0
                ? nums1.Split(",").Select(s => int.Parse(s)).ToArray()
                : new int[0]
;
            var n2 = nums2.Length != 0
                ? nums2.Split(",").Select(s => int.Parse(s)).ToArray()
                : new int[0]
;
            var actual = FindMedianSortedArrays(n1, n2);

            Assert.Equal(expected, actual);
        }
    }
}
