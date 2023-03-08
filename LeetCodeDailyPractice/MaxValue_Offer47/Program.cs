namespace MaxValue_Offer47
{
    /// <summary>
    /// 剑指 Offer 47. 礼物的最大价值
    /// 
    /// 
    /// 在一个 m*n 的棋盘的每一格都放有一个礼物，每个礼物都有一定的价值（价值大于 0）。你可以从棋盘的左上角开始拿格子里的礼物，并每次向右或者向下移动一格、直到到达棋盘的右下角。给定一个棋盘及其上面的礼物的价值，请计算你最多能拿到多少价值的礼物？
    ///  
    /// 
    /// 示例 1:
    /// 
    /// 输入: 
    /// [
    ///   [1,3,1],
    ///   [1,5,1],
    ///   [4,2,1]
    /// ]
    /// 输出: 12
    /// 解释: 路径 1→3→5→2→1 可以拿到最多价值的礼物
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = MaxValue(new[] {new[] {1, 3, 1}, new[] {1, 5, 1}, new[] {4, 2, 1}});
            Console.ReadKey();
        }

        public static int MaxValue(int[][] grid)
        {
            int len = grid.Length, wid = grid[0].Length;
            var result = new int[len][];
            for (int i = 0; i < len; i++)
            {
                result[i] = new int[wid];
            }
            return Dp(grid, result, len - 1, wid - 1);
        }

        public static int Dp(int[][] grid, int[][] result, int len, int wid)
        {
            if (result[len][wid] != 0)
            {
                return result[len][wid];
            }
            for (int i = 0; i < len + 1; i++)
            {
                for (int j = 0; j < wid + 1; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            result[i][j] = grid[i][j];
                        }
                        else
                        {
                            result[i][j] = grid[i][j] + Dp(grid, result, i, j - 1);
                        }
                    }
                    else if (j == 0)
                    {
                        result[i][j] = grid[i][j] + Dp(grid, result, i - 1, j);
                    }
                    else
                    {
                        result[i][j] = grid[i][j] + Math.Max(Dp(grid, result, i, j - 1), Dp(grid, result, i - 1, j));
                    }
                }
            }

            return result[len][wid];
        }

        public static int MaxValue_Pro(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            int[][] f = new int[m][];
            for (int i = 0; i < m; ++i)
            {
                f[i] = new int[n];
                for (int j = 0; j < n; ++j)
                {
                    if (i > 0)
                    {
                        f[i][j] = Math.Max(f[i][j], f[i - 1][j]);
                    }
                    if (j > 0)
                    {
                        f[i][j] = Math.Max(f[i][j], f[i][j - 1]);
                    }
                    f[i][j] += grid[i][j];
                }
            }
            return f[m - 1][n - 1];
        }
    }
}