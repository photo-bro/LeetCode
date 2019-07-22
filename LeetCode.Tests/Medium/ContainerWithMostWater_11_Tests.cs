using System;
using System.Linq;
using Xunit;
using static LeetCode.Solutions.Medium.ContainerWithMostWater_11;

namespace LeetCode.Tests.Medium
{
    public class ContainerWithMostWater_11_Tests
    {
        [Theory]
        [InlineData("1,8,6,2,5,4,8,3,7", 49)]
        public void MaxArea_Tests(string heights, int expected)
        {
            var h = heights.Split(',').Select(int.Parse).ToArray();
            var actual = MaxArea(h);

            Assert.Equal(expected, actual);
        }
    }
}
