using LeetCode.Solutions.Helper;

namespace LeetCode.Solutions.Easy
{
    ////// S y m m e t r i c   T r e e - E A S Y  //////
    ///
    ///    Given a binary tree, check whether it is a mirror of itself(ie, symmetric around its center).
    ///
    /// For example, this binary tree [1,2,2,3,4,4,3] is symmetric:
    ///          1
    ///         / \
    ///        2   2
    ///       / \ / \
    ///      3  4 4  3
    /// 
    /// 
    /// But the following[1, 2, 2, null, 3, null, 3] is not:
    ///          1
    ///         / \
    ///        2   2
    ///         \   \
    ///         3    3
    /// 
    /// 
    /// Note:
    /// Bonus points if you could solve it both recursively and iteratively.
    ///
    ////// S y m m e t r i c   T r e e - E A S Y  //////
    public static class SymmetricTree_101
    {

        public static bool IsSymmetric(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            InvertTree(root.right);

            return IsSameTree(root.left, root.right);
        }

        public static void InvertTree(TreeNode head)
        {
            if (head == null)
            {
                return;
            }

            var n = head.left;
            head.left = head.right;
            head.right = n;

            InvertTree(head.left);
            InvertTree(head.right);
        }

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null)
            {
                return false;
            }

            if (p.val != q.val)
            {
                return false;
            }

            var left = IsSameTree(p.left, q.left);
            var right = IsSameTree(p.right, q.right);
            return left && right;
        }
    }
}
