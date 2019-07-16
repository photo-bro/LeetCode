using System;
using System.Linq;

namespace LeetCode.Solutions.Helper
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

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

        public static TreeNode ConstructTree(ReadOnlySpan<int?> values)
        {
            var n = (int)Math.Log(values.Length + 1, 2);

            if (n == 1)
            {
                return values[0].HasValue ? new TreeNode(values[0].Value) : null;
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
                    parent.left = children[offset];
                    parent.right = children[offset + 1];
                    offset += 2;
                }
            }

            return nodeLevels[0][0];
        }
    }
}
