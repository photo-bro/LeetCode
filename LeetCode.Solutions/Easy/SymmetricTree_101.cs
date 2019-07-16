using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace LeetCode.Solutions.Easy
{
    ////// S y m m e t r i c   T r e e - E A S Y  //////
    ///
    ///    Given a binary tree, check whether it is a mirror of itself(ie, symmetric around its center).
    ///
    /// For example, this binary tree [1,2,2,3,4,4,3] is symmetric:
    ///          1
    ///         / \
    ///        2   2
    ///       / \ / \
    ///      3  4 4  3
    /// 
    /// 
    /// But the following[1, 2, 2, null, 3, null, 3] is not:
    ///          1
    ///         / \
    ///        2   2
    ///         \   \
    ///         3    3
    /// 
    /// 
    /// Note:
    /// Bonus points if you could solve it both recursively and iteratively.
    ///
    ////// S y m m e t r i c   T r e e - E A S Y  //////
    public static class SymmetricTree_101
    {

        public static bool IsSymmetric(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            InvertTree(root.right);

            return IsSameTree(root.left, root.right);
        }

        public static void InvertTree(TreeNode head)
        {
            if (head == null)
            {
                return;
            }

            var n = head.left;
            head.left = head.right;
            head.right = n;

            InvertTree(head.left);
            InvertTree(head.right);
        }

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null)
            {
                return false;
            }

            if (p.val != q.val)
            {
                return false;
            }

            var left = IsSameTree(p.left, q.left);
            var right = IsSameTree(p.right, q.right);
            return left && right;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }

            public static TreeNode StringToTree(string s)
            {
                if (string.IsNullOrEmpty(s))
                    return null;

                var ints = s.Split(",")
                            .Select(i => i == "null" ? (int?)null : int.Parse(i))
                            .ToArray();

                if (ints.Length < 1)
                    return null;

                var tree = ConstructTree(ints);

                return tree;
            }

            public static TreeNode ConstructTree(ReadOnlySpan<int?> values)
            {
                var n = (int)Math.Log(values.Length + 1, 2);

                if (n == 1)
                {
                    return values[0].HasValue ? new TreeNode(values[0].Value) : null;
                }

                var groups = new int?[n][];
                for (var i = 0; i < n; ++i)
                {
                    var length = (int)Math.Pow(2, i);
                    groups[i] = values.Slice(length - 1, length).ToArray();
                }

                // Construct nodes (n*log(n))
                var nodeLevels = groups
                    .Select(g =>
                        g.Select(i => i.HasValue
                            ? new TreeNode(i.Value)
                            : null)
                        .ToArray())
                    .ToArray();

                // Attach parents to children (log(n) * n)
                for (var i = 1; i < nodeLevels.Length; ++i)
                {
                    var parents = nodeLevels[i - 1];
                    var children = nodeLevels[i];
                    var offset = 0;

                    foreach (var parent in parents)
                    {
                        parent.left = children[offset];
                        parent.right = children[offset + 1];
                        offset += 2;
                    }
                }

                return nodeLevels[0][0];
            }
        }
    }
}
