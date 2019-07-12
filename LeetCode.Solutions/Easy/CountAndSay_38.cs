using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Solutions.Easy
{
    ////// C o u n t   a n d   S a y - E A S Y //////
    ///
    /// The count-and-say sequence is the sequence of integers
    /// with the first five terms as following:
    /// 
    /// 1. 1
    /// 2. 11
    /// 3. 21
    /// 4. 1211
    /// 5. 111221
    /// 
    /// 1 is read off as "one 1" or 11.
    /// 11 is read off as "two 1s" or 21.
    /// 21 is read off as "one 2, then one 1" or 1211.
    /// 
    /// Given an integer n where 1 ≤ n ≤ 30, generate the nth term of
    /// the count-and-say sequence.
    /// 
    /// Note: Each term of the sequence of integers will be represented
    /// as a string.
    /// 
    /// Example 1: 
    /// Input: 1
    /// Output: "1"
    /// 
    /// Example 2:
    /// Input: 4
    /// Output: "1211"
    ///
    ////// C o u n t   a n d   S a y - E A S Y //////
    public static class CountAndSay_38
    {
        public static string CountAndSay(int n)
        {
            if (n < 1 || n > 30)
                return null;

            if (n < 6)
                return CountAndSayMap[n - 1];

            var counts = new List<(int Number, int Count)>();
            var last = CountAndSayMap[CountAndSayMap.Length - 1];
            for (var i = CountAndSayMap.Length - 1; i + 1 < n; ++i)
            {
                var c = int.Parse(last[0].ToString());
                var num = c;
                var count = 1;
                for (var j = 1; j < last.Length; j++)
                {
                    c = int.Parse(last[j].ToString());
                    if (c != num)
                    {
                        counts.Add((Number: num, Count: count));
                        count = 1;
                        num = c;
                    }
                    else
                        ++count;

                }
                counts.Add((Number: num, Count: count));
                last = counts.Select(d => $"{d.Count}{d.Number}").Aggregate((a, s) => a += s);
                counts.Clear();
            }

            return last;
        }

        private static string[] CountAndSayMap => new[]
        {
            /*1*/"1",
            /*2*/"11",
            /*3*/"21",
            /*4*/"1211",
            /*5*/"111221"
        };
    }
}
