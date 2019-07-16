using System;

namespace LeetCode.Solutions.Easy
{
    ////// S q r t ( x ) - E A S Y //////
    /// 
    ///  Implement int sqrt(int x).
    ///  
    ///  Compute and return the square root of x, where x is
    ///  guaranteed to be a non-negative integer.
    ///  
    ///  Since the return type is an integer, the decimal digits
    ///  are truncated and only the integer part of the result
    ///  is returned.
    ///
    ///  Example 1:
    ///  Input: 4
    ///  Output: 2
    ///  
    ///  Example 2:
    ///  Input: 8
    ///  Output: 2
    ///  
    ///  Explanation: The square root of 8 is 2.82842..., and since
    ///  the decimal part is truncated, 2 is returned.
    ///  
    ////// S q r t ( x ) - E A S Y //////
    public static class Sqrt_69
    {
        public static int MySqrt(int x)
        {
            if (x < 2)
            {
                return x;
            }

            var small = MySqrt(x >> 2) << 1;
            var large = small + 1L;

            return large * large > x ? small : (int)large;
        }
    }
}