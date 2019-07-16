using System;
using System.Linq;
using Xunit;
using static LeetCode.Solutions.Easy.SortedArrayToBinarySearchTree_108;

namespace LeetCode.Tests.Easy
{
    public class SortedArrayToBinarySearchTree_108_Tests
    {
        [Theory]
        [InlineData("-10,-3,0,5,9")]
        public void SortedArrayToBST_Tests(string array)
        {
            var nums = array.Split(",").Select(int.Parse).ToArray();

            var actual = SortedArrayToBST(nums);


        }
    }
}
