using System;
using System.Linq;
using LeetCode.Solutions.Helper;
using Xunit;
using static LeetCode.Solutions.Easy.SortedArrayToBinarySearchTree_108;

namespace LeetCode.Tests.Easy
{
    public class SortedArrayToBinarySearchTree_108_Tests
    {
        [Fact]
        public void SortedArrayToBST_Empty()
        {
            var nums = new int[0];

            var actual = SortedArrayToBST(nums);

            Assert.Null(actual);
        }

        [Theory]
        [InlineData("-10,-3,0,5,9", "0,-3,9,-10,null,5")]
        [InlineData("-10,-3,0", "-3,-10,0")]
        [InlineData("-10,-3", "-3,-10")]
        [InlineData("-10", "-10")]
        public void SortedArrayToBST_Tests(string input, string expectedTree)
        {
            var expected = TreeNode.StringToTree(expectedTree);

            var nums = input.Split(",").Select(int.Parse).ToArray();

            var actual = SortedArrayToBST(nums);

            Assert.True(TreeNode.IsSameTree(expected, actual));
        }
    }
}
