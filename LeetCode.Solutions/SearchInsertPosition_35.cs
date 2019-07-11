using System;
namespace LeetCode.Solutions
{
    ////// S e a r c h   I n s e r t   P o s i t i o n  -  E A S Y  ////// 
    ///
    /// Given a sorted array and a target value, return the index if the
    /// target is found.If not, return the index where it would be if it
    /// were inserted in order.
    ///
    /// You may assume no duplicates in the array.
    /// 
    /// Example 1:
    /// Input: [1,3,5,6], 5
    /// Output: 2
    /// 
    /// Example 2:
    /// Input: [1,3,5,6], 2
    /// Output: 1
    /// 
    /// Example 3:
    /// Input: [1,3,5,6], 7
    /// Output: 4
    /// 
    /// Example 4:
    /// Input: [1,3,5,6], 0
    /// Output: 0
    /// 
    ////// S e a r c h   I n s e r t   P o s i t i o n  -  E A S Y  ////// 
    public static class SearchInsertPosition_35
    {
        public static int SearchInsert(int[] nums, int target) => BinarySearch(nums, target);

        internal static int BinarySearch(int[] nums, int target, int indexOffset = 0)
        {
            if (nums == null || nums.Length == 0)
                return indexOffset;

            var halfIndex = nums.Length / 2;

            if (target == nums[halfIndex])
                return indexOffset + halfIndex;

            if (target > nums[halfIndex])
                return BinarySearch(nums.AsSpan().Slice(halfIndex + 1).ToArray(), target, indexOffset + halfIndex + 1);

            return BinarySearch(nums.AsSpan().Slice(0, halfIndex).ToArray(), target, indexOffset);
        }
    }
}
