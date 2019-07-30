using System;
using LeetCode.Solutions.Helper;
using Xunit;
using static LeetCode.Solutions.Medium.ValidateBinarySearchTree_98;

namespace LeetCode.Tests.Medium
{
    public class ValidateBinarySearchTree_98_Tests
    {
        [Theory]
        [InlineData("", true)]
        [InlineData("2,1,3", true)]
        [InlineData("5,1,4,null,null,3,6", false)]
        [InlineData("10,5,15,null,null,6,20", false)]
        [InlineData("3,1,5,0,2,4,6", true)]
        [InlineData("5,14,null,1", false)]
        [InlineData("87,84,94,79,null,null,null,77,null,-82,null,70,null,38,null," +
                    "36,45,22,null,null,null,18,24,14,null,null,null,8,null,-93," +
                    "null,6,null,-37,null,-21,4,-32,null,null,null,-15,null,-42," +
                    "null,-63,null,-70,null,-78,null,75,null,7,null,-96,null,-98",
            false)]
        public void IsValidBST_Tests(string tree, bool expected)
        {
            var actual = IsValidBST(tree.ToBinaryTree());
            Assert.Equal(expected, actual);
        }
    }
}
