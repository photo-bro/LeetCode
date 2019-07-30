using System;
using System.Collections.Generic;
using LeetCode.Solutions.Helper;

namespace LeetCode.Solutions.Medium
{

    ////// V a l i d a t e   B i n a r y   S e a r c h   T r e e - M E D I U M //////
    ///
    ///    Given a binary tree, determine if it is a valid binary search tree(BST).
    ///
    ///  Assume a BST is defined as follows:
    ///  
    ///  The left subtree of a node contains only nodes with keys less than the node's key.
    ///  The right subtree of a node contains only nodes with keys greater than the node's key.
    ///  Both the left and right subtrees must also be binary search trees.
    ///  
    ///  Example 1:
    ///      2
    ///     / \
    ///    1   3 
    ///  Input: [2,1,3]
    ///  Output: true
    ///  
    ///  Example 2:
    ///      5
    ///     / \
    ///    1   4
    ///       / \
    ///      3   6 
    ///  Input: [5,1,4,null,null,3,6]
    ///  Output: false
    ///  Explanation: The root node's value is 5 but its right child's value is 4.
    ///  
    ////// V a l i d a t e   B i n a r y   S e a r c h   T r e e - M E D I U M //////
    public static class ValidateBinarySearchTree_98
    {
        public static bool IsValidBST(TreeNode root)
        {
            if (root == null) return true;
            return IsValidTree(root, root.val);
        }

        private static bool IsValidTree(TreeNode root, int parentVal,
            int minValue = int.MinValue, int maxValue = int.MaxValue,
            bool? isLeft = null)
        {
            if (root == null)
            {
                return true;
            }

            if (root.left == null && root.right == null)
            {
                if (isLeft == null)
                {
                    return true;
                }

                var valid = root.val > minValue && root.val < maxValue;

                if (isLeft.Value)
                {
                    valid &= root.val < parentVal && parentVal <= maxValue;
                }
                else
                {
                    valid &= root.val > parentVal && parentVal >= minValue;
                }

                return valid;
            }

            var left = true;
            var right = true;

            int lmin, rmin, lmax, rmax;
            if (isLeft == null)
            {
                lmin = minValue;
                lmax = parentVal;
                rmin = parentVal;
                rmax = maxValue;
            }
            else if (isLeft.Value)
            {
                lmin = minValue;
                lmax = parentVal;
                rmin = root.val;
                rmax = parentVal;
            }
            else
            {
                lmin = parentVal;
                lmax = root.val;
                rmin = parentVal;
                rmax = maxValue;
            }

            if (root.left != null && root.right != null)
            {
                left = IsValidTree(root.left, root.val, lmin, lmax, true);
                right = IsValidTree(root.right, root.val, rmin, rmax, false);
            }
            else if (root.left == null)
            {
                right = IsValidTree(root.right, root.val, rmin, rmax, false);
            }
            else if (root.right == null)
            {
                left = IsValidTree(root.left, root.val, lmin, lmax, true);
            }

            return left && right;
        }
    }
}
