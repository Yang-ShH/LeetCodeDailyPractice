namespace MovesToMakeZigzag_1144
{
    /// <summary>
    /// 1144. 递减元素使数组呈锯齿状
    /// 
    ///
    /// 给你一个整数数组 nums，每次 操作 会从中选择一个元素并 将该元素的值减少 1。
    /// 
    /// 如果符合下列情况之一，则数组 A 就是 锯齿数组：
    /// 
    /// 每个偶数索引对应的元素都大于相邻的元素，即 A[0] > A[1] < A[2] > A[3] < A[4] > ...
    /// 或者，每个奇数索引对应的元素都大于相邻的元素，即 A[0] < A[1] > A[2] < A[3] > A[4] < ...
    /// 返回将数组 nums 转换为锯齿数组所需的最小操作次数。
    /// 
    /// 
    /// 示例 1：
    /// 
    /// 输入：nums = [1,2,3]
    /// 输出：2
    /// 解释：我们可以把 2 递减到 0，或把 3 递减到 1。
    /// 示例 2：
    /// 
    /// 输入：nums = [9,6,1,6,2]
    /// 输出：4
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = MovesToMakeZigzag(new int[] { 151, 42, 769, 349, 835, 92, 242, 82, 357, 494,
                880, 683, 470, 631, 479, 298, 941, 113, 892, 103, 755, 575, 885, 50, 479, 502, 181, 164,
                292, 832, 657, 512, 528, 588, 716, 965, 195, 106, 396, 649 });

            var result1 = MovesToMakeZigzag_Pro(new int[] { 151, 42, 769, 349, 835, 92, 242, 82, 357, 494,
                880, 683, 470, 631, 479, 298, 941, 113, 892, 103, 755, 575, 885, 50, 479, 502, 181, 164,
                292, 832, 657, 512, 528, 588, 716, 965, 195, 106, 396, 649 });
        }

        public static int MovesToMakeZigzag(int[] nums)
        {
            return Math.Min(Calc(nums, 0), Calc(nums, 1));
        }

        public static int Calc(int[] nums, int i)
        {
            int result = 0;
            for (int j = i; j < nums.Length; j+=2)
            {
                if (j == i)
                {
                    if (i == nums.Length - 1)
                    {
                        continue;
                    }
                    var first = i == 0 ? 0 : (nums[j] - nums[i-1] + 1);
                    result += Math.Max(0, Math.Max(first, nums[j] - nums[j + 1] + 1));
                }
                else if (j == nums.Length -1)
                {
                    result += Math.Max(0, nums[j] - nums[j - 1] + 1);
                }
                else
                {
                    result += Math.Max(0, Math.Max(nums[j] - nums[j - 1], nums[j] - nums[j + 1]) + 1);
                }
            }

            return result;
        }

        public static int MovesToMakeZigzag_Pro(int[] nums)
        {
            return Math.Min(Calc_Pro(nums, 0), Calc_Pro(nums, 1));
        }

        public static int Calc_Pro(int[] nums, int pos)
        {
            int res = 0;
            for (int i = pos; i < nums.Length; i += 2)
            {
                int a = 0;
                if (i - 1 >= 0)
                {
                    a = Math.Max(a, nums[i] - nums[i - 1] + 1);
                }
                if (i + 1 < nums.Length)
                {
                    a = Math.Max(a, nums[i] - nums[i + 1] + 1);
                }
                res += a;
            }
            return res;
        }
    }
}