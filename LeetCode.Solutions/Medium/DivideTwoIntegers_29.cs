using System;
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
                switch (divisor)
                {
                    case 1:
                        return int.MinValue;
                    case -1:
                        return int.MaxValue;
                }
            }

            var negative = ((dividend >> 31) ^ (divisor >> 31)) < 0;

            var a = Abs(dividend);
            var b = Abs(divisor);

            if (b > a) return 0;

            // Long division style
            var q = 0;
            for (var i = 30; i >= 0; --i)
            {
                var r = (long)b << i;
                if (r >= int.MaxValue || r < 0 || r > a)
                {
                    continue;
                }

                q |= (1 << i);
                a -= (int)r;
            }

            q = negative ? ~q + 1 : q;

            return q;
        }

        private static int Abs(int a)
        {
            if (a == int.MinValue)
                return int.MaxValue;

            var mask = a >> 31;
            return (mask + a) ^ mask;
        }

        //  The standard way to do division is by implementing binary long-division.
        //  This involves subtraction, so as long as you don't discount this as not a
        //  bit-wise operation, then this is what you should do. (Note that you can of
        //  course implement subtraction, very tediously, using bitwise logical operations.)

        //  In essence, if you're doing Q = N/D:

        //  Align the most-significant ones of N and D.
        //  Compute t = (N - D);.
        //  If(t >= 0), then set the least significant bit of Q to 1, and set N = t.
        //  Left-shift N by 1.
        //  Left-shift Q by 1.
        //  Go to step 2.
        //  Loop for as many output bits(including fractional) as you require, then apply
        //  a final shift to undo what you did in Step 1.

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
