using LeetCode.Solutions.Helper;
using Xunit;

using static LeetCode.Solutions.Easy.SameTree_100;

namespace LeetCode.Tests.Easy
{
    public class SameTree_100_Tests
    {
        [Theory]
        [InlineData("1,2,3", "1,2,3", true)]
        [InlineData("1,2,1", "1,1,2", false)]
        [InlineData("1,2", "1,null,2", false)]
        public void IsSameTree_Test(string p, string q, bool expected)
        {
            var l = TreeNode.StringToTree(p);
            var r = TreeNode.StringToTree(q);

            var actual = IsSameTree(l, r);

            Assert.Equal(expected, actual);
        }

    }
}