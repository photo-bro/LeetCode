using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Solutions
{

    //////  T h r e e   S u m - M E D I U M  //////
    ///
    ///    Given an array nums of n integers, are there elements a, b, c
    ///    in nums such that a + b + c = 0? Find all unique triplets in
    ///    the array which gives the sum of zero.
    ///
    ///    Note:
    ///    The solution set must not contain duplicate triplets.
    ///
    ///    Example:
    ///    Given array nums = [-1, 0, 1, 2, -1, -4],
    ///    A solution set is:
    ///    [
    ///       [-1, 0, 1],
    ///       [-1, -1, 2]
    ///    ]
    ///    
    //////  T h r e e   S u m - M E D I U M  //////
    public static class ThreeSum_15
    {
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            if (nums.Length < 2)
                return null;

            if (nums.Length == 3)
            {
                if (nums[0] + nums[1] + nums[2] == 0)
                {
                    return new List<IList<int>> { nums.ToList() };
                }

                return null;
            }
            var triplets = new List<IList<int>>();

            var a = (Pos: 0, Val: nums[0]);
            var b = (Pos: 1, Val: nums[1]);
            var c = (Pos: 2, Val: nums[2]);

            bool ZeroSum(int x, int y, int z) => x + y + z == 0;

            for(var i = 0; i < nums.Length; ++i)
            {
                if (ZeroSum(a.Val,b.Val,c.Val))
                {
                    triplets.Add(new[] { a.Val, b.Val, c.Val });
                }
                while (c.Pos < nums.Length)
                {
                    if (ZeroSum(a.Val, b.Val, c.Val))
                    {
                        triplets.Add(new[] { a.Val, b.Val, c.Val });
                    }

                    c.Pos++;
                    c.Val = nums[c.Pos];
                }

            }

            return triplets;
        }
    }
}
