namespace MinimumDeletions_1653
{
    /// <summary>
    /// 1653. 使字符串平衡的最少删除次数
    /// 
    /// 
    /// 给你一个字符串 s ，它仅包含字符 'a' 和 'b'​​​​ 。
    /// 
    /// 你可以删除 s 中任意数目的字符，使得 s 平衡 。当不存在下标对 (i,j) 满足 i < j ，且 s[i] = 'b' 的同时 s[j]= 'a' ，此时认为 s 是 平衡 的。
    /// 
    /// 请你返回使 s 平衡 的 最少 删除次数。
    /// 
    ///  
    /// 
    /// 示例 1：
    /// 
    /// 输入：s = "aababbab"
    /// 输出：2
    /// 解释：你可以选择以下任意一种方案：
    /// 下标从 0 开始，删除第 2 和第 6 个字符（"aababbab" -> "aaabbb"），
    /// 下标从 0 开始，删除第 3 和第 6 个字符（"aababbab" -> "aabbbb"）。
    /// 
    /// 
    /// 示例 2：
    /// 
    /// 输入：s = "bbaaaaabb"
    /// 输出：2
    /// 解释：唯一的最优解是删除最前面两个字符。
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = MinimumDeletions("bbaaaabb");
        }

        public static int MinimumDeletions(string s)
        {
            int leftb = 0, righta = 0;
            righta = s.Count(e => e.Equals('a'));
            int res = righta;
            foreach (char c in s)
            {
                if (c == 'a')
                {
                    righta--;
                }
                else
                {
                    leftb++;
                }
                res = Math.Min(res, leftb + righta);
            }
            return res;
        }

        public static int MinimumDeletions_Pro(string s)
        {
            int righta = 0;
            foreach (var item in s)
            {
                righta += 'b' - item;
            }
            int res = righta;
            foreach (char c in s)
            {
                righta += (c - 'a') * 2 - 1;
                res = Math.Min(res, righta);
            }
            return res;
        }

        /// <summary>
        /// 动态规划（一次遍历）
        /// 
        /// 考虑 s 的最后一个字母：
        /// 
        /// 如果它是 'b'，则无需删除，问题规模缩小，变成「使 s 的前 n−1 个字母平衡的最少删除次数」。
        /// 如果它是 'a'：
        ///     删除它，则答案为「使 s 的前 n−1 个字母平衡的最少删除次数」加上 1
        ///     保留它，那么前面的所有 'b' 都要删除
        /// 	
        /// 设 cntB 为前 i 个字母中 'b' 的个数。定义 f[i] 表示使 s 的前 i 个字母平衡的最少删除次数：
        /// 
        /// 如果第 i 个字母是 'b'，则 f[i]=f[i−1]；
        /// 如果第 i 个字母是 'a'，则 f[i]=min⁡(f[i−1]+1,cntB)。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int MinimumDeletions_Pro2(string s)
        {
            int f = 0;
            int countB = 0;
            foreach (var item in s)
            {
                if (item.Equals('b'))
                {
                    countB++;
                }
                else
                {
                    f = Math.Min(f + 1, countB);
                }
            }

            return f;
        }
    }
}