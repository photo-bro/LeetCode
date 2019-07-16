using System;
using LeetCode.Solutions.Helper;
using Xunit;
using static LeetCode.Solutions.Easy.MaximumDepthBinaryTree_104;

namespace LeetCode.Tests.Easy
{
    public class MaximumDepthBinaryTree_104_Tests
    {
        [Theory]
        [InlineData("3,9,20,null,null,15,7", 3)]
        [InlineData("1,2,2", 2)]
        [InlineData("1", 1)]
        [InlineData("", 0]
        [InlineData("1,2,2,3,4,4,3,5,6,7,8,7,6,5", 3)]
        [InlineData("1,2,2,3,4,4,3,5,6,7,8,7,6,5,1", 4)]
        public void MaxDepth_Tests(string tree, int expected)
        {
            var head = TreeNode.StringToTree(tree);
            var actual = MaxDepth(head);

            Assert.Equal(expected, actual);
        }
    }
}
