using System;
using System.Linq;
using System.Collections.Generic;

using Xunit;
using static LeetCode.Solutions.ThreeSum_15;

namespace LeetCode.Tests
{
    public class ThreeSum_15_Tests
    {
        [Theory]
        [InlineData("-1,0,1,2,-1,-4", "-1,0,1;-1,-1,2")]
        public void ThreeSum_Tests(string nums, string expected)
        {
            var n = nums.Split(",").Select(int.Parse).ToArray();
            var exp = expected.Split(";").Select(s => s.Split(",").Select(int.Parse).ToList()).ToList();

            var actual = ThreeSum(n);

            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
            Assert.Equal(exp.Count, actual.Count);

            actual.OrderBy(l => l[0]);
            exp.OrderBy(l => l[0]);

            for (var i = 0; i < exp.Count; ++i)
            {
                Assert.True(exp[i].SequenceEqual(actual[i]));
            }
        }
    }
}
