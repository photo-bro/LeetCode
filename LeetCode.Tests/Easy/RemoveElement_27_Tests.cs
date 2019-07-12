using System;
using System.Linq;
using LeetCode.Solutions.Easy;
using Xunit;

namespace LeetCode.Tests.Easy
{
    public class RemoveElement_27_Tests
    {
        [Fact]
        public void RemoveElementTest_1()
        {
            var expected = new[] { 2, 2 };
            var expectedLen = 2;
            var nums = new[] { 3, 2, 2, 3 };
            var val = 3;

            var actual = RemoveElement_27.RemoveElement(nums, val);

            Assert.Equal(expectedLen, actual);
            AssertNumsEqual(expected, nums, expectedLen);

        }

        [Fact]
        public void RemoveElementTest_2()
        {
            var expected = new[] { 0, 1, 3, 0, 4 };
            var expectedLen = 5;
            var nums = new[] { 0, 1, 2, 2, 3, 0, 4, };
            var val = 2;

            var actual = RemoveElement_27.RemoveElement(nums, val);

            Assert.Equal(expectedLen, actual);
            AssertNumsEqual(expected, nums, expectedLen);
        }

        [Fact]
        public void RemoveElementTest_3()
        {
            var expected = new int[0];
            var expectedLen = 0;
            var nums = new[] { 3, 3 };
            var val = 3;

            var actual = RemoveElement_27.RemoveElement(nums, val);

            Assert.Equal(expectedLen, actual);
            AssertNumsEqual(expected, nums, expectedLen);
        }

        [Fact]
        public void RemoveElementTest_4()
        {
            var expected = new[] { 4 };
            var expectedLen = 1;
            var nums = new[] { 4, 5 };
            var val = 5;

            var actual = RemoveElement_27.RemoveElement(nums, val);

            Assert.Equal(expectedLen, actual);
            AssertNumsEqual(expected, nums, expectedLen);
        }

        private static void AssertNumsEqual(int[] expected, int[] actual, int length)
        {
            var actualSorted = actual.AsSpan().Slice(0, length).ToArray().ToList();
            actualSorted.Sort();
            actual = actualSorted.ToArray();

            var expectedSorted = expected.ToList();
            expectedSorted.Sort();
            expected = expectedSorted.ToArray();

            for (var i = 0; i < length; ++i)
            {
                Assert.Equal(expected[i], actual[i]);
            }
        }
    }
}


