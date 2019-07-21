using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode.Solutions.Helper;

namespace LeetCode.Solutions.Medium
{

    /// B i n a r y   T r e e   L e v e l   O r d e r   T r a v e r s a l - M E D I U M //////
    ///
    ///    Given a binary tree, return the level order traversal of its nodes' values.
    ///    (ie, from left to right, level by level).
    ///
    ///   For example:
    ///   Given binary tree[3, 9, 20, null, null, 15, 7],
    ///       3
    ///      / \
    ///     9  20
    ///       /  \
    ///      15   7
    ///   return its level order traversal as:
    ///   [
    ///     [3],
    ///     [9,20],
    ///     [15,7]
    ///   ]
    ///
    /// B i n a r y   T r e e   L e v e l   O r d e r   T r a v e r s a l - M E D I U M //////
    public static class BinaryTreeLevelOrderTraversal_102
    {
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null)
                return new List<IList<int>>();

            var levels = new List<IList<int>> { new[] { root.val } };

            var nextLevels = GetLevels(root);

            if (nextLevels == null)
            {
                return levels;
            }

            return levels.Concat(nextLevels).ToList();
        }

        public static IList<IList<int>> GetLevels(TreeNode root)
        {
            if (root == null || root.left == null && root.right == null)
            {
                return null;
            }

            var levels = new List<IList<int>>();
            var level = new List<int>();

            if (root.left != null) level.Add(root.left.val);
            if (root.right != null) level.Add(root.right.val);

            levels.Add(level);

            var l = GetLevels(root.left);
            var r = GetLevels(root.right);

            if (l == null && r == null)
            {
                return levels;
            }

            if (l == null)
            {
                levels = levels.Concat(r).ToList();
            }
            else if (r == null)
            {
                levels = levels.Concat(l).ToList();
            }
            else
            {
                // Consolidate left & right
                for (var i = 0; i < Math.Max(l.Count, r.Count); ++i)
                {
                    var left = i < l.Count ? l[i] : null;
                    var right = i < r.Count ? r[i] : null;

                    if (left != null && right != null)
                    {
                        var lev = left.Concat(right).ToList();
                        levels.Add(lev);
                    }
                    else if (left == null)
                    {
                        levels.Add(right);
                    }
                    else // right == null
                    {
                        levels.Add(left);
                    }
                }
            }

            return levels;
        }

    }
}
