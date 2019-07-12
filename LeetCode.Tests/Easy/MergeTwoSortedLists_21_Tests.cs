using System.Linq;
using LeetCode.Solutions.Easy;
using Xunit;

namespace LeetCode.Tests.Easy
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

            var actual = MergeTwoSortedLists_21.MergeTwoLists(l, r);
            AssertListsEqual(exp, actual);
        }


        private static void AssertListsEqual(MergeTwoSortedLists_21.ListNode expected, MergeTwoSortedLists_21.ListNode actual)
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

        private static MergeTwoSortedLists_21.ListNode InlineDataStringToList(string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;

            var head = new MergeTwoSortedLists_21.ListNode(-1);
            var n = head;
            foreach (var i in str.Split(",").Select(int.Parse))
            {
                n.Next = new MergeTwoSortedLists_21.ListNode(i);
                n = n.Next;
            }
            return n.Next;
        }
    }
}
