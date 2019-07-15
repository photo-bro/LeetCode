using System.Linq;
using System;

namespace LeetCode.Solutions.Easy
{
    ////// S a m e   T r e e - E A S Y  //////
    ///
    ///    Given two binary trees, write a function to check
    ///    if they are the same or not.
    ///
    ///    Two binary trees are considered the same if they
    ///    are structurally identical and the nodes have the
    ///    same value.
    ///
    ///    Example 1:
    ///    Input:     1         1
    ///              / \       / \
    ///             2   3     2   3
    ///            [1,2,3],  [1,2,3]
    ///    Output: true
    /// 
    ///    Example 2:
    ///    
    ///    Input:     1         1
    ///              /           \
    ///             2             2
    ///            [1,2],  [1,null,2]
    ///    Output: false
    /// 
    ///    Example 3:
    ///    Input:     1         1
    ///              / \       / \
    ///             2   1     1   2
    ///            [1,2,1],  [1,1,2]
    ///    Output: false
    ///    
    ////// S a m e   T r e e - E A S Y  //////
    public static class SameTree_100
    {
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

                var ints = s.Split(",").Select(i => i == "null" ? (int?)null : int.Parse(i)).ToArray().AsSpan();

                if (ints.Length < 1)
                    return null;

                var tree = StringToTreeImpl(ints.Slice(1), new TreeNode(ints[0].Value));

                return tree;
            }

            internal static TreeNode StringToTreeImpl(Span<int?> values, TreeNode head = null)
            {
                if (values.Length == 0)
                    return head;

                if (values.Length > 0 && values[0].HasValue)
                    head.left = new TreeNode(values[0].Value);

                if (values.Length > 1 && values[1].HasValue)
                    head.right = new TreeNode(values[1].Value);

                //if (values.Length > 2 && values[3].HasValue)
                //{
                //    head.left.left = new TreeNode(values[3].Value);
                //    head.left.left = StringToTreeImpl(values.Slice(3), head.left.left);
                //}

                //if (values.Length > 3 && values[4].HasValue)
                //{
                //    head.left.left = new TreeNode(values[4].Value);
                //    head.left.left = StringToTreeImpl(values.Slice(4), head.left.left);
                //}

                return head;
            }
        }
    }
}
