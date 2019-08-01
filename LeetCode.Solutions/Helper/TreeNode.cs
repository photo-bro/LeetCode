using System;
using System.Linq;

namespace LeetCode.Solutions.Helper
{
    public class TreeNode : IEquatable<TreeNode>
    {
        public readonly int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

        public override int GetHashCode() => HashCode.Combine(val, left, right);

        public override string ToString() =>
            $"'{val}'\t{Environment.NewLine}" +
            $"{(left == null ? "[null]" : left.ToString())}{Environment.NewLine}" +
            $"{(right == null ? "[null]" : right.ToString())}";

        public override bool Equals(object obj) => Equals(obj as TreeNode);

        public bool Equals(TreeNode other) => IsSameTree(this, other);

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

        public static TreeNode StringToTree(string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;

            var ints = s.Split(",")
                        .Select(i => i == "null" ? (int?)null : int.Parse(i))
                        .ToArray();

            if (ints.Length < 1)
                return null;

            var tree = ConstructTree(ints);

            return tree;
        }

        public static TreeNode ConstructTree(ReadOnlySpan<int> values)
        {
            var nullableNums = values.ToArray().Cast<int?>().ToArray();
            return ConstructTree(nullableNums);
        }

        public static TreeNode ConstructTree(ReadOnlySpan<int?> values)
        {
            if (values.Length == 0)
                return null;

            var n = (int)Math.Ceiling(Math.Log(values.Length + 1, 2));

            if (n == 1)
            {
                return values[0].HasValue ? new TreeNode(values[0].Value) : null;
            }

            // Null pad values
            if (values.Length < Math.Pow(2, n) - 1)
            {
                var valueCopy = values.ToArray();
                Array.Resize(ref valueCopy, (int)Math.Pow(2, n) - 1);
                values = valueCopy.AsSpan();
            }

            var groups = new int?[n][];
            for (var i = 0; i < n; ++i)
            {
                var length = (int)Math.Pow(2, i);
                groups[i] = values.Slice(length - 1, length).ToArray();
            }

            // Construct nodes (n*log(n))
            var nodeLevels = groups
                .Select(g =>
                    g.Select(i => i.HasValue
                        ? new TreeNode(i.Value)
                        : null)
                    .ToArray())
                .ToArray();

            // Attach parents to children (log(n) * n)
            for (var i = 1; i < nodeLevels.Length; ++i)
            {
                var parents = nodeLevels[i - 1];
                var children = nodeLevels[i];
                var offset = 0;

                foreach (var parent in parents)
                {
                    if (parent == null)
                    {
                        offset += 2;
                        continue;
                    }

                    parent.left = children[offset];
                    parent.right = children[offset + 1];
                    offset += 2;
                }
            }

            return nodeLevels[0][0];
        }
    }

    public static class TreeNodeExtensions
    {
        public static TreeNode ToBinaryTree(this string s) => TreeNode.StringToTree(s);
    }
}
