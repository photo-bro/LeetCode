﻿using System.Linq;
using LeetCode.Solutions.Easy;
using Xunit;

namespace LeetCode.Tests.Easy
{
    public class SearchInsertPosition_35_Tests
    {
        [Theory]
        [InlineData("1,3,5,6", 5, 2)]
        [InlineData("1,3,5,6", 2, 1)]
        [InlineData("1,3,5,6", 7, 4)]
        [InlineData("1,3,5,6", 0, 0)]
        [InlineData("1,3,5", 4, 2)]
        public void SearchInsertPositionTests(string arr, int target, int expected)
        {
            var nums = arr.Split(",").Select(int.Parse).ToArray();

            var actual = SearchInsertPosition_35.SearchInsert(nums, target);

            Assert.Equal(expected, actual);
        }
    }
}
