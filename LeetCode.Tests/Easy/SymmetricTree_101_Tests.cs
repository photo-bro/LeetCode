using System;
using Xunit;
using static LeetCode.Solutions.Easy.SymmetricTree_101;

namespace LeetCode.Tests.Easy
{
    public class SymmetricTree_101_Tests
    {
        [Theory]
        [InlineData("1,2,2,3,4,4,3", true)]
        [InlineData("2,1,1", true)]
        [InlineData("1,2,2,null,3,null,3", false)]
        public void IsSymmetric_Tests(string tree, bool expected)
        {
            var head = TreeNode.StringToTree(tree);
            var actual = IsSymmetric(head);

            Assert.Equal(expected, actual);
        }

    }
}
