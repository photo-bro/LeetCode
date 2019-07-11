using System;

namespace LeetCode.Solutions
{
    ////// M e d i a n   o f   T w o   S o r t e d   A r r a y s  -  H A R D ////////
    ///                                                                           ///
    /// There are two sorted arrays nums1 and nums2 of size m and n respectively. ///
    ///                                                                           ///
    /// Find the median of the two sorted arrays. The overall run time complexity ///
    /// should be O(log (m+n)).                                                   ///
    ///                                                                           ///
    /// You may assume nums1 and nums2 cannot be both empty.                      ///
    ///                                                                           ///
    /// Example 1:                                                                ///
    /// nums1 = [1, 3]                                                            ///
    /// nums2 = [2]                                                               ///
    ///                                                                           ///
    /// The median is 2.0                                                         ///
    /// Example 2:                                                                ///
    /// nums1 = [1, 2]                                                            ///
    /// nums2 = [3, 4]                                                            ///
    ///                                                                           ///
    /// The median is (2 + 3)/2 = 2.5                                             ///
    ///                                                                           ///
    ////// M e d i a n   o f   T w o   S o r t e d   A r r a y s  -  H A R D ////////

    public static class MedianOfTwoSortedArrays_4
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length == 0)
            {
                return CalculateMedian(nums2);
            }
            if (nums2.Length == 0)
            {
                return CalculateMedian(nums1);
            }

            var min = 0;
            var max = (nums1.Length + nums2.Length) / 2;
            var mid = (max - min) / 2;

            while (min <= max)
            {
                if (nums1[mid] > nums2[mid])
                {

                }
            }


            return 0d;
        }

        private static double CalculateMedian(int[] arr)
        => arr.Length % 2 == 0
            ? (arr[arr.Length / 2] + arr[(arr.Length / 2) - 1]) / 2d
            : arr[arr.Length / 2];

        private static void BinaryInsert(int[] arr, int index, int val)
        {
            if (index > arr.Length - 1)
                return;

            var left = arr[index - 1];
            var end = arr[arr.Length - 1];

            if (val > left)
            {
                if (val > end)
                {
                    // swap end to after left
                    Swap(arr, arr.Length - 1, index);
                    // place at end
                    arr[arr.Length - 1] = val;
                }
                else
                {
                    // place after left
                    arr[index] = val;
                }
            }
            else
            {
                // swap left and after left
                Swap(arr, index - 1, index);
                // insert at prior left
                arr[index - 1] = val;
            }
        }

        private static void Swap(int[] arr, int indexA, int indexB)
        {
            if (indexA < arr.Length && indexB < arr.Length)
            {
                var t = arr[indexB];
                arr[indexB] = arr[indexA];
                arr[indexA] = t;
            }
        }

        private static double FirstTryImpl(int[] nums1, int[] nums2)
        {
            if (nums1.Length == 0)
            {
                return CalculateMedian(nums2);
            }
            if (nums2.Length == 0)
            {
                return CalculateMedian(nums1);
            }

            var arr = new int[nums1.Length + nums2.Length];

            if (nums1[0] < nums2[0])
            {
                arr[0] = nums1[0];
                arr[arr.Length - 1] = nums2[0];
            }
            else
            {
                arr[0] = nums2[0];
                arr[arr.Length - 1] = nums1[0];
            }


            var leftPos = 1;
            var max = nums1.Length > nums2.Length ? nums1.Length : nums2.Length;
            // Binary merge sort
            for (var i = 1; i < max; ++i)
            {
                var l = i < nums1.Length ? nums1[i] : (int?)null;
                var r = i < nums2.Length ? nums2[i] : (int?)null;

                if (l.HasValue)
                {
                    // just insert right
                    BinaryInsert(arr, leftPos++, l.Value);
                }
                if (r.HasValue)
                {
                    // just insert left
                    BinaryInsert(arr, leftPos++, r.Value);
                }
            }

            return CalculateMedian(arr);
        }
    }
}
