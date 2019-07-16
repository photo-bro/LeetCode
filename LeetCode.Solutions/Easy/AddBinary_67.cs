using System;
using System.Text;

namespace LeetCode.Solutions.Easy
{
    ////// A d d   B i n a r y - E A S Y //////
    ///
    ///     Given two binary strings, return their sum(also a binary string).
    /// 
    /// The input strings are both non-empty and contains only characters 1 or 0.
    /// 
    /// Example 1:
    /// Input: a = "11", b = "1"
    /// Output: "100"
    /// 
    /// Example 2:
    /// 
    /// Input: a = "1010", b = "1011"
    /// Output: "10101"
    ///
    ////// A d d   B i n a r y - E A S Y //////
    public static class AddBinary67
    {
        public static string AddBinary(string a, string b)
        {
            var sb = new StringBuilder();

            bool l, r, sum;
            var c = false;
            var max = Math.Max(a.Length, b.Length);

            if (a.Length < max)
            {
                a = a.PadLeft(max, '0');
            }
            else if (b.Length < max)
            {
                b = b.PadLeft(max, '0');
            }

            for (var i = max - 1; i >= 0; --i)
            {
                l = i < a.Length && a[i] == '1';
                r = i < b.Length && b[i] == '1';

                sum = (l ^ r) ^ c;  // A ⊕ B ⊕ Cin
                c = (l & r) | (c & (l ^ r));  // (A ⋅ B) + (Cin ⋅ (A ⊕ B)).
                sb.Insert(0, sum ? '1' : '0');
            }

            if (c)
            {
                sb.Insert(0, '1');
            }

            return sb.ToString();
        }

        internal static bool FullAdder(bool a, bool b, ref bool c)
        {
            var sum = (a ^ b) ^ c; // A ⊕ B ⊕ Cin
            c = (a & b) | (c & (a ^ b));  //  (A ⋅ B) + (Cin ⋅ (A ⊕ B)).
            return sum;
        }
    }
}
