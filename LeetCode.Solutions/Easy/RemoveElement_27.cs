using System.Linq;

namespace LeetCode.Solutions.Easy
{
    public static class RemoveElement_27
    {
        public static int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0)
                return 0;
            if (nums.Length == 1 && nums[0] == val)
                return 0;
            if (nums.All(i => i == val))
                return 0;

            var offset = 0;
            var pos = 0;

            while (pos < nums.Length)
            {
                if (nums[pos] == val && pos < nums.Length - offset - 1)
                {
                    Swap(nums, pos, nums.Length - offset - 1);
                    ++offset;

                    if (nums[pos] == val)
                    {
                        continue;
                    }
                }

                pos++;
            }
            return nums.Count(i => i != val);
        }

        private static void Swap(int[] nums, int a, int b)
        {
            if (a < nums.Length && b < nums.Length)
            {
                var t = nums[b];
                nums[b] = nums[a];
                nums[a] = t;
            }
        }
    }
}
