using System;
using System.Linq;
namespace LeetCode.Solutions
{
    ////// M a x i m u m   S u b a r r a y  - E A S Y //////
    ///
    ///  Given an integer array nums, find the contiguous subarray (containing at
    ///  least one number) which has the largest sum and return its sum.
    ///    
    /// Example:
    /// 
    /// Input: [-2,1,-3,4,-1,2,1,-5,4],
    /// Output: 6
    /// Explanation: [4,-1,2,1] has the largest sum = 6.
    /// Follow up:
    /// 
    /// If you have figured out the O(n) solution, try coding another solution
    /// using the divide and conquer approach, which is more subtle.
    /// 
    ////// M a x i m u m   S u b a r r a y  - E A S Y //////
    public static class MaximumSubarray_53
    {
        public static int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return nums[0];

            var maxSoFar = nums[0];
            var currentMax = nums[0] ;
            for (var i = 1; i < nums.Length; ++i)
            {

                currentMax = nums[i] > currentMax + nums[i]
                    ? nums[i]
                    : nums[i] + currentMax;
                maxSoFar = maxSoFar > currentMax
                    ? maxSoFar
                    : currentMax;
            }

            return maxSoFar;
        }
    }
}
