using System;
namespace LeetCode.Solutions
{
    ////// I n t e g e r   t o   R o m a n - E A S Y  //////
    ///
    ///     Roman numerals are represented by seven different symbols:
    ///     I, V, X, L, C, D and M.
    ///   
    /// Symbol Value
    /// I             1
    /// V             5
    /// X             10
    /// L             50
    /// C             100
    /// D             500
    /// M             1000
    /// For example, two is written as II in Roman numeral, just two
    /// one's added together. Twelve is written as, XII, which is simply
    /// X + II. The number twenty seven is written as XXVII, which is
    /// XX + V + II.
    ///  
    /// Roman numerals are usually written largest to smallest from l
    /// eft to right.However, the numeral for four is not IIII. Instead,
    /// the number four is written as IV.Because the one is before
    /// the five we subtract it making four. The same principle applies
    /// to the number nine, which is written as IX.There are six instances
    /// where subtraction is used:
    ///   
    /// I can be placed before V (5) and X(10) to make 4 and 9. 
    /// X can be placed before L(50) and C(100) to make 40 and 90. 
    /// C can be placed before D(500) and M(1000) to make 400 and 900.
    /// Given an integer, convert it to a roman numeral.Input is guaranteed
    /// to be within the range from 1 to 3999.
    ///
    /////// I n t e g e r   t o   R o m a n - E A S Y  //////
    public static class IntegerToRoman_12
    {
        public static string IntToRoman(int num)
        {
            if (num < 0)
                return null;

            if (num >= 1000)
            {
                return $"{new string('M', num / 1000)}{IntToRoman(num - (num / 1000 * 1000))}";
            }
            if (num >= 900)
            {
                return $"CM{IntToRoman(num - 900)}";
            }
            if (num >= 500)
            {
                return $"D{IntToRoman(num - 500)}";
            }
            if (num >= 400)
            {
                return $"CD{IntToRoman(num - 400)}";
            }
            if (num >= 100)
            {
                return $"{new string('C', num / 100)}{IntToRoman(num - (num / 100 * 100))}";
            }
            if (num >= 90)
            {
                return $"XC{IntToRoman(num - 90)}";
            }
            if (num >= 50)
            {
                return $"L{IntToRoman(num - 50)}";
            }
            if (num >= 40)
            {
                return $"XL{IntToRoman(num - 40)}";
            }
            if (num >= 10)
            {
                return $"{new string('X', num / 10)}{IntToRoman(num - (num / 10 * 10))}";
            }

            switch (num)
            {
                case var _ when num < 4:
                    return new string('I', num);
                case 4:
                    return "IV";
                case 5:
                    return "V";
                case var _ when num > 5 && num < 9:
                    return $"V{new string('I', num - 5)}";
                case 9:
                    return "IX";
                case 10:
                    return "X";
                default:
                    return string.Empty;
            }
        }
    }
}
