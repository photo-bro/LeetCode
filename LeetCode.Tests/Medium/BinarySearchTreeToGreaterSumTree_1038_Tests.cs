using System;
using Xunit;
using LeetCode.Solutions.Helper;
using static LeetCode.Solutions.Medium.BinarySearchTreeToGreaterSumTree_1038;

namespace LeetCode.Tests.Medium
{
    public class BinarySearchTreeToGreaterSumTree_1038_Tests
    {
        [Theory]
        [InlineData("4,1,6,0,2,5,7,null,null,null,3,null,null,null,8", "30,36,21,36,35,26,15,null,null,null,33,null,null,null,8")]
        [InlineData("6,2,10,0,4,8,12,null,1,3,5,7,9,11,13", "76,90,46,91,85,63,25,null,91,88,81,70,55,36,13")]
        [InlineData("3,2,4,1", "7,9,4,10")]
        public void BstToGst_Tests(string bst, string expected)
        {
            var actual = BstToGst(bst.ToBinaryTree());
            Assert.True(TreeNode.IsSameTree(actual, expected.ToBinaryTree()));
        }
    }
}
