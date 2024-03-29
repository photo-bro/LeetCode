﻿namespace LeetCode.Solutions.Medium
{
    ////// S t r i n g   t o   I n t e g e r   ( a t o i ) - M E D I U M /////
    ///
    ///     Implement atoi which converts a string to an integer.
    /// 
    /// The function first discards as many whitespace characters as necessary until
    /// the first non-whitespace character is found. Then, starting from this character,
    /// takes an optional initial plus or minus sign followed by as many numerical
    /// digits as possible, and interprets them as a numerical value.
    /// 
    /// The string can contain additional characters after those that form the integral
    /// number, which are ignored and have no effect on the behavior of this function.
    /// 
    /// If the first sequence of non-whitespace characters in str is not a valid
    /// integral number, or if no such sequence exists because either str is empty
    /// or it contains only whitespace characters, no conversion is performed.
    /// 
    /// If no valid conversion could be performed, a zero value is returned.
    /// 
    /// Note:
    /// 
    /// Only the space character ' ' is considered as whitespace character.
    /// Assume we are dealing with an environment which could only store integers
    /// within the 32-bit signed integer range: [−2^31,  2^31 − 1]. If the numerical
    /// value is out of the range of representable values, INT_MAX (2^31 − 1) or
    /// INT_MIN(−2^31) is returned.
    ///
    /// Example 1:
    /// Input: "42"
    /// Output: 42
    /// 
    /// Example 2:
    /// Input: "   -42"
    /// Output: -42
    /// Explanation: The first non-whitespace character is '-', which is the minus sign.
    ///              Then take as many numerical digits as possible, which gets 42.
    ///              
    /// Example 3:
    /// Input: "4193 with words"
    /// Output: 4193
    /// Explanation: Conversion stops at digit '3' as the next character is not a
    /// numerical digit.
    /// 
    /// Example 4:
    /// Input: "words and 987"
    /// Output: 0
    /// Explanation: The first non-whitespace character is 'w', which is not a numerical
    ///              digit or a +/- sign.Therefore no valid conversion could be performed.
    ///              
    /// Example 5:
    /// Input: "-91283472332"
    /// Output: -2147483648
    /// Explanation: The number "-91283472332" is out of the range of a 32-bit
    /// signed integer. Thefore INT_MIN (−231) is returned.
    /// 
    ////// S t r i n g   t o   I n t e g e r   ( a t o i ) - M E D I U M /////
    public static class StringToInteger_8
    {
        public static int atoi(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;

            if (str.Length == 1 && !char.IsDigit(str[0]))
                return 0;

            str = str.TrimStart(' ');

            var hasPrefix = false;
            switch (str[0])
            {
                case '+':
                case '-':
                    hasPrefix = true;
                    break;
                case var _ when char.IsDigit(str[0]):
                    break;
                default:
                    return 0;

            }

            var digits = string.Empty;
            for (var i = 0; i < str.Length; i++)
            {
                var c = str[i];

                if (char.IsDigit(c))
                {
                    digits += c;
                }
                else
                {
                    if (hasPrefix && (c == '-' || c == '+'))
                    {
                        if (i == 0)
                        {
                            digits += c;
                            continue;
                        }
                        break;
                    }
                    break;
                }
            }

            digits = hasPrefix ? $"{digits[0]}{digits.Substring(1).TrimStart('0')}" : digits.TrimStart('0');

            if (hasPrefix && digits.Length == 1)
                return 0;

            if (string.IsNullOrWhiteSpace(digits))
                return 0;

            if (digits.Length > 11)
            {
                if (hasPrefix && digits[0] == '-')
                    return int.MinValue;

                return int.MaxValue;
            }

            var l = long.Parse(digits);

            if (l > int.MaxValue)
                return int.MaxValue;
            if (l < int.MinValue)
                return int.MinValue;

            return (int)l;
        }
    }
}
