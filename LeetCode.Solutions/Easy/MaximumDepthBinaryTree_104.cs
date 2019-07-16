using System;
using LeetCode.Solutions.Helper;

namespace LeetCode.Solutions.Easy
{
    ////// M a x i m u m   D e p t h   o f   B i n a r y   T r e e - E A S Y //////
    ///
    ///    Given a binary tree, find its maximum depth.
    ///
    ///  The maximum depth is the number of nodes along the longest path from the
    ///  root node down to the farthest leaf node.
    ///  
    ///  Note: A leaf is a node with no children.
    ///  
    ///  Example:
    ///  Given binary tree[3, 9, 20, null, null, 15, 7],
    ///  
    ///      3
    ///     / \
    ///    9  20
    ///      /  \
    ///     15   7
    ///     
    ///  return its depth = 3
    ///
    ////// M a x i m u m   D e p t h   o f   B i n a r y   T r e e - E A S Y //////
    public static class MaximumDepthBinaryTree_104
    {
        public static int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return MaxDepth(root, 1);
        }

        internal static int MaxDepth(TreeNode root, int currentDepth)
        {
            if (root.left == null && root.right == null)
                return currentDepth;

            var left = 0;
            if (root.left != null)
                left = MaxDepth(root.left, currentDepth + 1);

            var right = 0;
            if (root.right != null)
                right = MaxDepth(root.right, currentDepth + 1);

            return Math.Max(left, right);
        }
    }
}
