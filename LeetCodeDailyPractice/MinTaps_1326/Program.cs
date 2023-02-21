namespace MinTaps_1326;

/// <summary>
/// 1326. 灌溉花园的最少水龙头数目
///
/// 在 x 轴上有一个一维的花园。花园长度为 n，从点 0 开始，到点 n 结束。
///
/// 花园里总共有 n + 1 个水龙头，分别位于 [0, 1, ..., n] 。
///
/// 给你一个整数 n 和一个长度为 n + 1 的整数数组 ranges ，其中 ranges[i] （下标从 0 开始）表示：如果打开点 i 处的水龙头，可以灌溉的区域为 [i -  ranges[i], i + ranges[i]] 。
///
/// 请你返回可以灌溉整个花园的 最少水龙头数目 。如果花园始终存在无法灌溉到的地方，请你返回 -1 。
///
/// 示例 1：
/// 
/// 输入：n = 5, ranges = [3,4,1,1,0,0]
/// 输出：1
/// 解释：
/// 点 0 处的水龙头可以灌溉区间 [-3,3]
/// 点 1 处的水龙头可以灌溉区间 [-3,5]
/// 点 2 处的水龙头可以灌溉区间 [1,3]
/// 点 3 处的水龙头可以灌溉区间 [2,4]
/// 点 4 处的水龙头可以灌溉区间 [4,4]
/// 点 5 处的水龙头可以灌溉区间 [5,5]
/// 只需要打开点 1 处的水龙头即可灌溉整个花园 [0,5] 。
/// </summary>
public class Solution
{
    public static void Main()
    {
        var result1 = MinTaps_Pro(5, new int[] {3, 3, 1, 1, 1, 0});
        var result2 = MinTaps_Pro2(5, new int[] {3, 3, 1, 1, 1, 0});
    }

    /// <summary>
    /// 动态规划
    /// </summary>
    /// <param name="n"></param>
    /// <param name="ranges"></param>
    /// <returns></returns>
    public static int MinTaps_Pro(int n, int[] ranges)
    {
        int[][] intervals = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            int start = Math.Max(0, i - ranges[i]);
            int end = Math.Min(n, i + ranges[i]);
            intervals[i] = new int[] { start, end };
        }
        Array.Sort(intervals, (a, b) => a[0] - b[0]);
        int[] dp = new int[n + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;
        foreach (int[] interval in intervals)
        {
            int start = interval[0], end = interval[1];
            if (dp[start] == int.MaxValue)
            {
                return -1;
            }
            for (int j = start; j <= end; j++)
            {
                dp[j] = Math.Min(dp[j], dp[start] + 1);
            }
        }
        return dp[n];
    }

    /// <summary>
    /// 贪心算法
    /// </summary>
    /// <param name="n"></param>
    /// <param name="ranges"></param>
    /// <returns></returns>
    public static int MinTaps_Pro2(int n, int[] ranges)
    {
        int[] rightMost = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            rightMost[i] = i;
        }
        for (int i = 0; i <= n; i++)
        {
            int start = Math.Max(0, i - ranges[i]);
            int end = Math.Min(n, i + ranges[i]);
            rightMost[start] = Math.Max(rightMost[start], end);
        }
        int last = 0, ret = 0, pre = 0;
        for (int i = 0; i < n; i++)
        {
            last = Math.Max(last, rightMost[i]);
            if (i == last)
            {
                return -1;
            }
            if (i == pre)
            {
                ret++;
                pre = last;
            }
        }
        return ret;
    }
}
