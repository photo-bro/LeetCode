using System;
using System.Linq;
using LeetCode.Solutions.Helper;

namespace LeetCode.Solutions.Easy
{
    ////// C o n v e r t   S o r t e d   A r r a y   t o   B i n a r y   S e a r c h   T r e e - M E D I U M //////
    ///
    ///    Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
    ///
    ///  For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the
    ///  two subtrees of every node never differ by more than 1.
    ///  
    ///  Example:
    ///  Given the sorted array: [-10,-3,0,5,9],
    ///  
    ///  One possible answer is: [0,-3,9,-10,null,5], which represents the following height balanced BST:
    ///  
    ///        0
    ///       / \
    ///     -3   9
    ///     /   /
    ///   -10  5
    ///  
    ////// C o n v e r t   S o r t e d   A r r a y   t o   B i n a r y   S e a r c h   T r e e - M E D I U M //////
    public static class SortedArrayToBinarySearchTree_108
    {
        public static TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null)
                return null;

            var head = new TreeNode(nums[0]);

            if (nums.Length == 1)
            {
                return head;
            }

            if (nums.Length < 4)
            {
                head.left = new TreeNode(nums[0]);
                head.right = nums.Length > 2 ? new TreeNode(nums[2]) : null;
                return head;
            }

            var middle = nums.Length / 2;
            var left = nums.AsSpan().Slice(0, middle);
            var right = nums.AsSpan().Slice(middle);

            head = new TreeNode(nums[middle])
            {
                left = TreeNode.ConstructTree(left),
                right = TreeNode.ConstructTree(right)
            };

            return head;
        }
    }
}
