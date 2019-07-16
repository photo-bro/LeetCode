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
            if (nums == null || nums.Length == 0)
                return null;

            if (nums.Length == 1)
            {
                return new TreeNode(nums[0]);
            }

            if (nums.Length == 2)
            {
                var max = Math.Max(nums[0], nums[1]);
                var min = Math.Min(nums[0], nums[1]);
                return new TreeNode(max) { left = new TreeNode(min) };
            }

            if (nums.Length == 3)
            {

                var max = Math.Max(nums[0], nums[2]);
                var min = Math.Min(nums[0], nums[2]);
                return new TreeNode(nums[1])
                {
                    left = new TreeNode(min),
                    right = new TreeNode(max)
                };
            }

            var middle = nums.Length / 2;
            var left = nums.AsSpan().Slice(0, middle).ToArray();
            var right = nums.AsSpan().Slice(middle + 1).ToArray();

            var head = new TreeNode(nums[middle])
            {
                left = SortedArrayToBST(left),
                right = SortedArrayToBST(right)
            };

            return head;
        }
    }
}
