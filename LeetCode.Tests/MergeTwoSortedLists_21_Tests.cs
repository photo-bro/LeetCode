using System;
using System.Linq;
using Xunit;

using static LeetCode.Solutions.Easy.MergeTwoSortedLists_21;

namespace LeetCode.Tests
{
    public class MergeTwoSortedLists_21_Tests
    {
        [Theory]
        [InlineData("1,2,4", "1,3,4", "1,1,2,3,4,4")]
        [InlineData("7,8,9", "0,1,1", "0,1,1,7,8,9")]
        [InlineData("7,8,9", "0,1,1,1,1", "0,1,1,1,1,7,8,9")]
        [InlineData("7,8,9", "", "7,8,9")]
        public void MergeTwoLists_Test1(string left, string right, string expected)
        {
            var l = InlineDataStringToList(left);
            var r = InlineDataStringToList(right);
            var exp = InlineDataStringToList(expected);

            var actual = MergeTwoLists(l, r);
            AssertListsEqual(exp, actual);
        }


        private static void AssertListsEqual(ListNode expected, ListNode actual)
        {
            var l = expected;
            var r = actual;
            while (l != null && r != null)
            {
                Assert.Equal(l.Val, r.Val);
                l = l.Next;
                r = r.Next;
            }
            Assert.Null(l);
            Assert.Null(r);
        }

        private static ListNode InlineDataStringToList(string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;

            var head = new ListNode(-1);
            var n = head;
            foreach (var i in str.Split(",").Select(int.Parse))
            {
                n.Next = new ListNode(i);
                n = n.Next;
            }
            return n.Next;
        }
    }
}
