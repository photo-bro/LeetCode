namespace LeetCode.Solutions.Easy
{
    ////// M e r g e   T w o   S o r t e d   L i s t s  -  E A S Y /////
    ///
    ///  Merge two sorted linked lists and return it as a new list.
    ///  The new list should be made by splicing together the nodes
    ///  of the first two lists.
    ///
    /// Example:
    /// 
    /// Input: 1->2->4, 1->3->4
    /// Output: 1->1->2->3->4->4
    ///
    ////// M e r g e   T w o   S o r t e d   L i s t s  -  E A S Y /////
    public static class MergeTwoSortedLists_21
    {
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            var head = new ListNode(int.MinValue);
            var n = head;

            while (l1 != null && l2 != null)
            {
                if (l2.Val < l1.Val)
                {
                    n.Next = l2;
                    l2 = l2.Next;
                }
                else
                {
                    n.Next = l1;
                    l1 = l1.Next;
                }
                n = n.Next;

                if (l1 == null)
                {
                    n.Next = l2;
                    l2 = null;
                }
                else if (l2 == null)
                {
                    n.Next = l1;
                    l1 = null;
                }
            }

            return head.Next;
        }
        

        public class ListNode
        {
            public int Val;
            public ListNode Next;
            public ListNode(int x) { Val = x; }
        }
    }
}
