using System;
using System.Collections.Generic;

namespace LeetCode.Solutions.Helper
{
    public static class Trie
    {
        public static void Insert(TrieNode head, string value)
        {


        }


    }

    public struct TrieNode
    {
        public char Value { get; }

        public IDictionary<char, TrieNode> Children { get; }

        public TrieNode(char value)
        {
            Value = value;
            Children = new Dictionary<char, TrieNode>();
        }

        public void AddChild(TrieNode child)
        {
            if (Children.ContainsKey(child.Value))
                throw new InvalidOperationException($"Trie already has child with value '{child.Value}'");
            Children[child.Value] = child;
        }

        public void RemoveChild(TrieNode child)
        {
            Children[child.Value] = default;
        }
    }
}
