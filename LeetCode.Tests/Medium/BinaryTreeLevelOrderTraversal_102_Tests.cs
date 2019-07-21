using System;
using System.Linq;
using LeetCode.Solutions.Helper;
using Xunit;

using static LeetCode.Solutions.Medium.BinaryTreeLevelOrderTraversal_102;

namespace LeetCode.Tests.Medium
{
    public class BinaryTreeLevelOrderTraversal_102_Tests
    {
        [Theory]
        [InlineData("1","1")]
        [InlineData("3,9,20,null,null,15,7", "3;9,20;15,7")]
        [InlineData("1,2,2,3,4,4,3", "1;2,2;3,4,4,3")]
        [InlineData("1, 2,null, 3,4,null,null,  5,6,8", "1;2;3,4;5,6,8")]
        [InlineData("1,2,2,3,4,4,3,5,6,7,8,8,7,6,5", "1;2,2;3,4,4,3;5,6,7,8,8,7,6,5")]
        public void LevelOrder_Tests(string tree, string expected)
        {
            var exp = expected.Split(';').Select(s => s.Split(',').Select(int.Parse).ToList()).ToList();
            var root = TreeNode.StringToTree(tree);

            var actual = LevelOrder(root);

            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
            Assert.Equal(exp.Count, actual.Count);

            for (var i = 0; i < exp.Count; ++i)
            {
                Assert.NotNull(actual[i]);
                Assert.NotEmpty(actual[i]);
                Assert.Equal(exp[i].Count, actual[i].Count);
                Assert.True(exp[i].OrderBy(x => x).SequenceEqual(actual[i].OrderBy(x => x)));
            }
        }
    }
}
