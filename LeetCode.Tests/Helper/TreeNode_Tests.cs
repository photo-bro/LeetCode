using System;
using LeetCode.Solutions.Helper;
using Xunit;

namespace LeetCode.Tests.Helper
{
    public class TreeNode_Tests
    {
        [Fact]
        public void ConstructTree_Empty()
        {
            var nums = new int[0];

            var actual = TreeNode.ConstructTree(nums);

            Assert.Null(actual);
        }

        [Fact]
        public void ConstructTree_OneItem()
        {
            var expected = new TreeNode(1);

            var actual = TreeNode.ConstructTree(new[] { 1 });

            Assert.True(TreeNode.IsSameTree(expected, actual));
        }

        [Fact]
        public void ConstructTree_TwoItems()
        {
            var expected = new TreeNode(1)
            {
                left = new TreeNode(2)
            };

            var actual = TreeNode.ConstructTree(new[] { 1, 2 });

            Assert.True(TreeNode.IsSameTree(expected, actual));
        }

        [Fact]
        public void ConstructTree_ThreeItems()
        {
            var expected = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(1)
            };

            var actual = TreeNode.ConstructTree(new[] { 1, 2, 1 });

            Assert.True(TreeNode.IsSameTree(expected, actual));
        }

        [Fact]
        public void ConstructTree_ManyItems()
        {
            var expected = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(3)
                    {
                        left = new TreeNode(5),
                        right = new TreeNode(6),
                    },
                    right = new TreeNode(4)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(8),
                    },
                },
                right = new TreeNode(2)
                {
                    left = new TreeNode(4)
                    {
                        left = new TreeNode(8),
                        right = new TreeNode(7),
                    },
                    right = new TreeNode(3)
                    {
                        left = new TreeNode(6),
                        right = new TreeNode(5),
                    },
                }
            };

            var actual = TreeNode.ConstructTree(new[] { 1, 2, 2, 3, 4, 4, 3, 5, 6, 7, 8, 8, 7, 6, 5 });

            Assert.True(TreeNode.IsSameTree(expected, actual));
        }
    }
}
