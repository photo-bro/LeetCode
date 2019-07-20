using System;
using System.Linq;

namespace LeetCode.Solutions.Medium
{
    ////// R e v e r s e   W o r d s   I n   A   S t r i n g - M E D I U M //////
    ///
    ///    Given an input string, reverse the string word by word.
    ///
    ///   Example 1:
    ///   Input: "the sky is blue"
    ///   Output: "blue is sky the"
    ///   
    ///   Example 2:
    ///   Input: "  hello world!  "
    ///   Output: "world! hello"
    ///   Explanation: Your reversed string should not contain leading or trailing
    ///   spaces.
    ///   
    ///   Example 3:
    ///   Input: "a good   example"
    ///   Output: "example good a"
    ///   Explanation: You need to reduce multiple spaces between two words to a
    ///   single space in the reversed string.
    ///   
    ///   Note:
    ///   A word is defined as a sequence of non-space characters.
    ///   Input string may contain leading or trailing spaces.However, your
    ///   reversed string should not contain leading or trailing spaces.
    ///   You need to reduce multiple spaces between two words to a single s
    ///   pace in the reversed string.
    ///
    ////// R e v e r s e   W o r d s   I n   A   S t r i n g - M E D I U M //////
    public static class ReverseWordsInAString_151
    {
        public static string ReverseWords(string s) =>
            string.Join(" ", s.Trim().Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).Reverse()).Trim();
    }
}
