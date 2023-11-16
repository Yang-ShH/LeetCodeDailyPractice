//给你一个整数数组 nums ，请你找出一个具有最大和的连续子数组（子数组最少包含一个元素），返回其最大和。

//子数组 是数组中的一个连续部分。


//示例 1：

//输入：nums = [-2,1,-3,4,-1,2,1,-5,4]
//输出：6
//解释：连续子数组 [4,-1,2,1] 的和最大，为 6 。
//示例 2：

//输入：nums = [1]
//输出：1
//示例 3：

//输入：nums = [5,4,-1,7,8]
//输出：23


namespace MaxSubArray
{
    class Program
    {
        public static void Main(string[] args)
        {
            var nums = new int[] { 4, -1, 5, -3 };
            var result = MaxSubArray(nums);
            Console.WriteLine(result);
        }

        public static int MaxSubArray(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }
            var currentMax = nums[0];
            var max = currentMax;
            for (int i = 1; i < nums.Length; i++)
            {
                // 比较 nums[i] 和 nums[i] + 前一个元素作为尾数的子数组和 谁更大
                currentMax = Math.Max(nums[i], currentMax + nums[i]);
                // 比较 当前元素作为尾数的子数组和 与 之前的最大值 谁更大
                max = Math.Max(currentMax, max);
            }

            return max;
        }
    }
}