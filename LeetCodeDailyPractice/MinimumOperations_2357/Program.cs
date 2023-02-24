namespace MinimumOperations_2357
{
    /// <summary>
    /// 给你一个非负整数数组 nums 。在一步操作中，你必须：
    /// 
    /// 选出一个正整数 x ，x 需要小于或等于 nums 中 最小 的 非零 元素。
    /// nums 中的每个正整数都减去 x。
    /// 返回使 nums 中所有元素都等于 0 需要的 最少 操作数。
    /// 
    ///  
    /// 
    /// 示例 1：
    /// 
    /// 输入：nums = [1,5,0,3,5]
    /// 输出：3
    /// 解释：
    /// 第一步操作：选出 x = 1 ，之后 nums = [0,4,0,2,4] 。
    /// 第二步操作：选出 x = 2 ，之后 nums = [0,2,0,0,2] 。
    /// 第三步操作：选出 x = 2 ，之后 nums = [0,0,0,0,0] 。
    /// 示例 2：
    /// 
    /// 输入：nums = [0]
    /// 输出：0
    /// 解释：nums 中的每个元素都已经是 0 ，所以不需要执行任何操作。
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = MinimumOperations(new[] {1, 5, 0, 3, 5});
            var result2 = MinimumOperations2(new[] { 1, 5, 0, 3, 5 });
            var result3 = MinimumOperations_Pro(new[] { 1, 5, 0, 3, 5 });
        }

        public static int MinimumOperations(int[] nums)
        {
            if (nums.All(e => e == 0))
            {
                return 0;
            }
            if (nums.Length == 1)
            {
                return 1;
            }
            var result = 0;
            return Calc(nums, result);
        }

        public static int Calc(int[] nums, int result)
        {
            if (nums.All(e => e == 0))
            {
                return result;
            }

            var temp = nums.Where(e => e > 0).Min();
            var nextNums = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    nextNums[i] = nums[i] - temp;
                }
                else
                {
                    nextNums[i] = nums[i];
                }
            }

            result++;
            return Calc(nextNums, result);
        }

        public static int MinimumOperations2(int[] nums)
        {
            var result = nums.Where(e => e > 0).Distinct().Count();
            return result;
        }

        public static int MinimumOperations_Pro(int[] nums)
        {
            ISet<int> set = new HashSet<int>(nums.Where(e => e > 0));
            
            return set.Count;
        }
    }
}