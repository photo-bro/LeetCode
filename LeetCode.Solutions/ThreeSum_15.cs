using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                return new List<IList<int>>();

            if (nums.Length < 2)
                return new List<IList<int>>();

            if (nums.Length == 3)
            {
                return nums[0] + nums[1] + nums[2] == 0
                    ? new List<IList<int>> { nums.ToList() }
                    : new List<IList<int>>();
            }

            Array.Sort(nums);

            var triplets = new HashSet<Triplet>();

            var sums = new HashSet<int>();

            for (var i = 0; i < nums.Length - 1; ++i)
            {
                var a = nums[i];
                if (a == nums[i + 1] && nums[i + 1] == nums[nums.Length - 1])
                {
                    if (i + 1 < nums.Length - 1 && a * 3 == 0)
                    {
                        var triplet = new Triplet(a, a, a);
                        if (!triplets.Contains(triplet))
                        {
                            triplets.Add(triplet);
                        }
                    }

                    break;
                }
                for (var j = i + 1; j < nums.Length; ++j)
                {
                    var b = nums[j];
                    var x = (a + b) * -1;
                    if (sums.Contains(x))
                    {
                        var triplet = new Triplet(x, a, b);
                        if (!triplets.Contains(triplet))
                        {
                            triplets.Add(triplet);
                        }
                    }
                    else
                    {
                        sums.Add(b);
                    }

                }
                sums.Clear();
            }

            return triplets.Select(t => new List<int> { t.A, t.B, t.C }).Cast<IList<int>>().ToList();
        }

        public struct Triplet
        {
            public Triplet(int a, int b, int c)
            {
                A = a;
                B = b;
                C = c;

                var counts = new Dictionary<int, int> { { a, 1 } };
                if (counts.ContainsKey(b))
                    counts[b] += 1;
                else
                    counts.Add(b, 1);
                if (counts.ContainsKey(c))
                    counts[c] += 1;
                else
                    counts.Add(c, 1);

                _countsString = counts.OrderBy(kv => kv.Key)
                                     .Select(kv => $"{kv.Key}{kv.Value}")
                                     .Aggregate((agg, s) => agg += s);
            }

            public int A { get; }
            public int B { get; }
            public int C { get; }

            private readonly string _countsString;

            // HashCode shouldn't be used for equality check...
            public override bool Equals(object o) =>
                GetHashCode() == (o as Triplet? ?? default).GetHashCode();

            public override int GetHashCode() => _countsString.GetHashCode();
        }
    }
}
