using System.Linq;
using System;
using LeetCode.Solutions.Helper;

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
    }
}
