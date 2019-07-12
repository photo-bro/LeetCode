using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Solutions
{
    ////// S a m e   T r e e - E A S Y  //////
    ///
    ///    Given two binary trees, write a function to check
    ///    if they are the same or not.
    ///
    ///    Two binary trees are considered the same if they
    ///    are structurally identical and the nodes have the
    ///    same value.
    ///
    ///    Example 1:
    ///    Input:     1         1
    ///              / \       / \
    ///             2   3     2   3
    ///            [1,2,3],  [1,2,3]
    ///    Output: true
    /// 
    ///    Example 2:
    ///    
    ///    Input:     1         1
    ///              /           \
    ///             2             2
    ///            [1,2],  [1,null,2]
    ///    Output: false
    /// 
    ///    Example 3:
    ///    Input:     1         1
    ///              / \       / \
    ///             2   1     1   2
    ///            [1,2,1],  [1,1,2]
    ///    Output: false
    ///    
    ////// S a m e   T r e e - E A S Y  //////

    public static class SameTree_100
    {
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            return false;
        }
    }
    public class TreeNode
    {
        public int Val;
        public TreeNode Left;
        public TreeNode Right;
        public TreeNode(int x) { Val = x; }

        public static TreeNode StringToTree(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return null;

            var values = s.Split(",").ToArray();
            if (values.Length == 0)
                return null;


            var head = new TreeNode(int.Parse(values[0]));
            var node = head;
            for (var i = 0; i < values.Length; i++)
            {
                var l = values[i];
                if (l != "null")
                {
                    node.Left = new TreeNode(int.Parse(l));
                }
                if (values.Length > i + 1)
                {
                    var r = values[i + 1];
                    if (r != "null")
                    {
                        node.Right = new TreeNode(int.Parse(r));
                    }
                }

                //node = node.Left;
            }


            return null;
        }
    }
}
