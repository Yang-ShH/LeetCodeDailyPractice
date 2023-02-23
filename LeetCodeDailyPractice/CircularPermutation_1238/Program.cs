namespace CircularPermutation_1238
{
    /// <summary>
    /// 给你两个整数 n 和 start。你的任务是返回任意 (0,1,2,,...,2^n-1) 的排列 p，并且满足：
    /// 
    /// p[0] = start
    /// p[i] 和 p[i+1] 的二进制表示形式只有一位不同
    /// p[0] 和 p[2^n -1] 的二进制表示形式也只有一位不同
    ///  
    /// 
    /// 示例 1：
    /// 
    /// 输入：n = 2, start = 3
    /// 输出：[3,2,0,1]
    /// 解释：这个排列的二进制表示是 (11,10,00,01)
    ///      所有的相邻元素都有一位是不同的，另一个有效的排列是 [3,1,0,2]
    /// 示例 2：
    /// 
    /// 输出：n = 3, start = 2
    /// 输出：[2,6,7,5,4,0,1,3]
    /// 解释：这个排列的二进制表示是 (010,110,111,101,100,000,001,011)
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var result1 = CircularPermutation_Pro(2, 3);
            var result2 = CircularPermutation_Pro2(2, 3);
        }

        public static IList<int> CircularPermutation_Pro(int n, int start)
        {
            IList<int> ret = new List<int>();
            ret.Add(start);
            for (int i = 1; i <= n; i++)
            {
                int m = ret.Count;
                for (int j = m - 1; j >= 0; j--)
                {
                    ret.Add(((ret[j] ^ start) | (1 << (i - 1))) ^ start);
                }
            }
            return ret;
        }

        public static IList<int> CircularPermutation_Pro2(int n, int start)
        {
            IList<int> ret = new List<int>();
            for (int i = 0; i < 1 << n; i++)
            {
                ret.Add((i >> 1) ^ i ^ start);
            }
            return ret;
        }
    }
}