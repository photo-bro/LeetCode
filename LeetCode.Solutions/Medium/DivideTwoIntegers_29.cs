using System;
using System.Diagnostics;
using LeetCode.Solutions.Helper;

namespace LeetCode.Solutions.Medium
{
    ////// D i v i d e   T w o   I n t e g e r s - M E D I U M //////
    ///
    ///    Given two integers dividend and divisor, divide two integers
    ///    without using multiplication, division and mod operator.
    ///
    ///  Return the quotient after dividing dividend by divisor.
    ///  
    ///  The integer division should truncate toward zero.
    ///  
    ///  Example 1:
    ///  Input: dividend = 10, divisor = 3
    ///  Output: 3
    ///  
    ///  Example 2:
    ///  Input: dividend = 7, divisor = -3
    ///  Output: -2
    ///  
    ///  Note:
    ///  - Both dividend and divisor will be 32-bit signed integers.
    ///  - The divisor will never be 0.
    ///  - Assume we are dealing with an environment which could only store
    ///    integers within the 32-bit signed integer range: [−2^31,  2^31 − 1].
    ///  - For the purpose of this problem, assume that your function
    ///    returns 2^31 − 1 when the division result overflows.
    ///  
    ////// D i v i d e   T w o   I n t e g e r s - M E D I U M //////
    public static class DivideTwoIntegers_29
    {
        public static int Divide(int dividend, int divisor)
        {
            if (divisor == 0) throw new DivideByZeroException();
            if (dividend == 0) return 0;
            if (dividend == divisor) return 1;
            if (dividend == int.MinValue)
            {
                if (divisor == 1) return int.MinValue;
                if (divisor == -1) return int.MaxValue;
            }

            var a = Abs(dividend);
            var b = Abs(divisor);

            if (b > a) return 0;

            var q = 0;

            if (b == 2)
            {
                q = (int)(a >> 1);
            }
            else
            // Long division style
            {
                for (var i = 31; i >= 0; --i)
                {
                    var r = b << i;
                    if (r > int.MaxValue || r < 0 || r > a)
                    {
                        continue;
                    }

                    q |= 1 << i;
                    a -= (int)r;
                }
            }

            q = ((dividend >> 31) ^ (divisor >> 31)) < 0 ? ~q + 1 : q;

            return q;
        }

        private static long Abs(int a)
        {
            var mask = (long)a >> 31;
            return (mask + a) ^ mask;
        }

        public static int DivideIterative(int dividend, int divisor)
        {
            var negative = ((dividend >> 31) ^ (divisor >> 31)) < 0;

            var a = Abs(dividend);
            var b = Abs(divisor);

            if (b > a) return 0;

            var q = 0;
            while (b <= a && q < int.MaxValue)
            {
                a -= b;
                q++;
            }

            return negative ? ~q + 1 : q;
        }

    }
}
