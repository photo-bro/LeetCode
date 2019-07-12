using System;
using LeetCode.Solutions;
using Xunit;
using static LeetCode.Solutions.Easy.SameTree_100;

namespace LeetCode.Tests
{
    public class SameTree_100_Tests
    {
        [Theory]
        [InlineData("","","")]
        public void IsSameTree_Test(string p, string q, string exp)
        {
            var expected = new TreeNode(0);

            var actual = IsSameTree(null, null);

        }
    }
}