using LeetCode.Solutions.Easy;
using Xunit;

namespace LeetCode.Tests.Easy
{
    public class SameTree_100_Tests
    {
        [Theory]
        [InlineData("","","")]
        public void IsSameTree_Test(string p, string q, string exp)
        {
            var expected = new SameTree_100.TreeNode(0);

            var actual = SameTree_100.IsSameTree(null, null);

        }
    }
}