using System;
using LeetCode.Solutions.Helper;

namespace LeetCode.Solutions.Medium
{
    ////// B s t   t o   G s t - M E D I U M //////
    /// 
    ///    Given the root of a binary search tree with distinct values, modify it so
    ///    that every node has a new value equal to the sum of the values of the original
    ///    tree that are greater than or equal to node.val.
    ///    
    ///    As a reminder, a binary search tree is a tree that satisfies these constraints:
    ///    
    ///    The left subtree of a node contains only nodes with keys less than the node's key.
    ///    The right subtree of a node contains only nodes with keys greater than the node's key.
    ///    Both the left and right subtrees must also be binary search trees.
    ///    
    ///    Example 1:
    ///    Input: [4,1,6,0,2,5,7,null,null,null,3,null,null,null,8]
    ///    Output: [30,36,21,36,35,26,15,null,null,null,33,null,null,null,8]
    ///    
    ///    Note:
    ///    The number of nodes in the tree is between 1 and 100.
    ///    Each node will have value between 0 and 100.
    ///    The given tree is a binary search tree.
    ///
    ////// B s t   t o   G s t - M E D I U M //////
    public static class BinarySearchTreeToGreaterSumTree_1038
    {
        public static TreeNode BstToGst(TreeNode root) => GstTree(root).tree;

        private static (TreeNode tree, int outCarry) GstTree(TreeNode node, int inCarry = 0)
        {
            if (node == null)
                return (null, 0);

            if (node.left == null && node.right == null)
                return (new TreeNode(node.val + inCarry), 0);

            var (right, rightCarry) = GstTree(node.right, inCarry);

            if (right == null)
                rightCarry = inCarry;

            var thisVal = Math.Max(right?.val ?? 0, rightCarry) + node.val;

            var (left, leftCarry) = GstTree(node.left, thisVal);

            return (new TreeNode(thisVal)
            {
                left = left,
                right = right
            }, Math.Max(left?.val ?? 0, leftCarry));
        }
    }
}
