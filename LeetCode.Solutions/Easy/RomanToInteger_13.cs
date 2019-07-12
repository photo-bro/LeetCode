using System;

namespace LeetCode.Solutions.Easy
{
    ////// R o m a n   t o   I n t e g e r - E A S Y //////
    ///
    ///    Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
    ///
    /// Symbol Value
    /// I             1
    /// V             5
    /// X             10
    /// L             50
    /// C             100
    /// D             500
    /// M             1000
    /// For example, two is written as II in Roman numeral, just two one's added together.
    /// Twelve is written as, XII, which is simply X + II. The number twenty seven is written
    /// as XXVII, which is XX + V + II.
    /// 
    /// Roman numerals are usually written largest to smallest from left to right.However,
    /// the numeral for four is not IIII. Instead, the number four is written as IV.Because
    /// he one is before the five we subtract it making four. The same principle applies to
    /// the number nine, which is written as IX.There are six instances where subtraction is
    /// used:
    /// 
    /// I can be placed before V (5) and X(10) to make 4 and 9. 
    /// X can be placed before L(50) and C(100) to make 40 and 90. 
    /// C can be placed before D(500) and M(1000) to make 400 and 900.
    /// Given a roman numeral, convert it to an integer.Input is guaranteed to be within
    /// the range from 1 to 3999.
    /// 
    ////// R o m a n   t o   I n t e g e r - E A S Y //////
    public static class RomanToInteger_13
    {
        public static int RomanToInt(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            var value = 0;
            var sameCount = 0;
            var current = (char)0;
            var next = (char)0;
            for (var i = 0; i < s.Length; ++i)
            {
                current = s[i];
                next = i + 1 < s.Length ? s[i + 1] : (char)0;

                switch (current)
                {
                    case 'I':
                        switch (next)
                        {
                            case 'V':
                                value += 4;
                                i++;
                                break;
                            case 'X':
                                value += 9;
                                i++;
                                break;
                            case 'I':
                                if (sameCount < 4) sameCount++;
                                else throw new InvalidOperationException($"Too many Roman '{current}' in a row");
                                break;
                            case (char)0:
                                value += ++sameCount * 1;
                                break;
                            default:
                                value += ++sameCount * 1;
                                sameCount = 0;
                                break;
                        }
                        break;
                    case 'V':
                        value += 5;
                        break;
                    case 'X':
                        switch (next)
                        {
                            case 'L':
                                value += 40;
                                i++;
                                break;
                            case 'C':
                                value += 90;
                                i++;
                                break;
                            case 'X':
                                if (sameCount < 4) sameCount++;
                                else throw new InvalidOperationException($"Too many Roman '{current}' in a row");
                                break;
                            case (char)0:
                                value += ++sameCount * 10;
                                break;
                            default:
                                value += ++sameCount * 10;
                                sameCount = 0;
                                break;
                        }
                        break;
                    case 'L':
                        value += 50;
                        break;
                    case 'C':
                        switch (next)
                        {
                            case 'D':
                                value += 400;
                                i++;
                                break;
                            case 'M':
                                value += 900;
                                i++;
                                break;
                            case 'C':
                                if (sameCount < 4) sameCount++;
                                else throw new InvalidOperationException($"Too many Roman '{current}' in a row");
                                break;
                            case (char)0:
                                value += ++sameCount * 100;
                                break;
                            default:
                                value += ++sameCount * 100;
                                sameCount = 0;
                                break;
                        }
                        break;
                    case 'D':
                        value += 500;
                        break;
                    case 'M':
                        switch (next)
                        {
                            case 'M':
                                if (sameCount < 4) sameCount++;
                                else throw new InvalidOperationException($"Too many Roman '{current}' in a row");
                                break;
                            case (char)0:
                                value += ++sameCount * 1000;
                                break;
                            default:
                                value += ++sameCount * 1000;
                                sameCount = 0;
                                break;
                        }
                        break;
                    default:
                        throw new InvalidOperationException($"Illegal Roman char: '{current}'");
                }
            }

            return value;
        }
    }
}
