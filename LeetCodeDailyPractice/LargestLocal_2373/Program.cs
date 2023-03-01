namespace LargestLocal_2373
{
    /// <summary>
    /// 2373. 矩阵中的局部最大值
    /// 
    /// 给你一个大小为 n x n 的整数矩阵 grid 。
    /// 
    /// 生成一个大小为 (n - 2) x (n - 2) 的整数矩阵  maxLocal ，并满足：
    /// 
    /// maxLocal[i][j] 等于 grid 中以 i + 1 行和 j + 1 列为中心的 3 x 3 矩阵中的 最大值 。
    /// 换句话说，我们希望找出 grid 中每个 3 x 3 矩阵中的最大值。
    /// 
    /// 返回生成的矩阵。
    /// 
    ///  
    /// 
    /// 示例 1：
    /// 
    /// 输入：grid = [[9,9,8,1],[5,6,2,6],[8,2,6,4],[6,2,2,2]]
    /// 输出：[[9,9],[8,6]]
    /// 注意，生成的矩阵中，每个值都对应 grid 中一个相接的 3 x 3 矩阵的最大值。
    ///
    /// 
    /// 示例 2：
    /// 
    /// 输入：grid = [[1,1,1,1,1],[1,1,1,1,1],[1,1,2,1,1],[1,1,1,1,1],[1,1,1,1,1]]
    /// 输出：[[2,2,2],[2,2,2],[2,2,2]]
    /// 解释：注意，2 包含在 grid 中每个 3 x 3 的矩阵中。
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = LargestLocal(new int[][] { new[] {9, 9, 8, 1}, new[] { 5, 6, 2, 6}, new[] { 8, 2, 6, 4}, new[] { 6, 2, 2, 2}});
        }

        public static int[][] LargestLocal(int[][] grid)
        {
            var len = grid.Length - 2;
            int[][] maxLocal = new int[len][];
            for (int i = 0; i < len; i++)
            {
                maxLocal[i] = new int[len];
                for (int j = 0; j < len; j++)
                {
                    var tempArr = new int[]
                    {
                        grid[i][j], grid[i][j + 1], grid[i][j + 2],
                        grid[i + 1][j], grid[i + 1][j + 1], grid[i + 1][j + 2],
                        grid[i + 2][j], grid[i + 2][j + 1], grid[i + 2][j + 2],
                    };
                    maxLocal[i][j] = tempArr.Max();
                }
            }

            return maxLocal;
        }

        public int[][] LargestLocal2(int[][] grid)
        {
            var len = grid.Length - 2;
            int[][] maxLocal = new int[len][];
            for (int i = 0; i < len; i++)
            {
                maxLocal[i] = new int[len];
                for (int j = 0; j < len; j++)
                {
                    maxLocal[i][j] = grid.Skip(i).Take(3).SelectMany(e => e.Skip(j).Take(3)).Max();
                }
            }

            return maxLocal;
        }

        public int[][] LargestLocal_Pro(int[][] grid)
        {
            int n = grid.Length;
            int[][] res = new int[n - 2][];
            for (int i = 0; i < n - 2; i++)
            {
                res[i] = new int[n - 2];
                for (int j = 0; j < n - 2; j++)
                {
                    for (int x = i; x < i + 3; x++)
                    {
                        for (int y = j; y < j + 3; y++)
                        {
                            res[i][j] = Math.Max(res[i][j], grid[x][y]);
                        }
                    }
                }
            }
            return res;
        }
    }
}