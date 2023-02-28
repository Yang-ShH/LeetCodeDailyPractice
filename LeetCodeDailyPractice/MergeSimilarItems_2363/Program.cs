namespace MergeSimilarItems_2363
{
    /// <summary>
    /// 2363. 合并相似的物品
    /// 
    /// 给你两个二维整数数组 items1 和 items2 ，表示两个物品集合。每个数组 items 有以下特质：
    /// 
    /// items[i] = [valuei, weighti] 其中 valuei 表示第 i 件物品的 价值 ，weighti 表示第 i 件物品的 重量 。
    /// items 中每件物品的价值都是 唯一的 。
    /// 请你返回一个二维数组 ret，其中 ret[i] = [valuei, weighti]， weighti 是所有价值为 valuei 物品的 重量之和 。
    /// 
    /// 注意：ret 应该按价值 升序 排序后返回。
    /// 
    ///  
    /// 
    /// 示例 1：
    /// 
    /// 输入：items1 = [[1,1],[4,5],[3,8]], items2 = [[3,1],[1,5]]
    /// 输出：[[1,6],[3,9],[4,5]]
    /// 解释：
    /// value = 1 的物品在 items1 中 weight = 1 ，在 items2 中 weight = 5 ，总重量为 1 + 5 = 6 。
    /// value = 3 的物品再 items1 中 weight = 8 ，在 items2 中 weight = 1 ，总重量为 8 + 1 = 9 。
    /// value = 4 的物品在 items1 中 weight = 5 ，总重量为 5 。
    /// 所以，我们返回 [[1,6],[3,9],[4,5]] 。
    /// 示例 2：
    /// 
    /// 输入：items1 = [[1,1],[3,2],[2,3]], items2 = [[2,1],[3,2],[1,3]]
    /// 输出：[[1,4],[2,4],[3,4]]
    /// 解释：
    /// value = 1 的物品在 items1 中 weight = 1 ，在 items2 中 weight = 3 ，总重量为 1 + 3 = 4 。
    /// value = 2 的物品在 items1 中 weight = 3 ，在 items2 中 weight = 1 ，总重量为 3 + 1 = 4 。
    /// value = 3 的物品在 items1 中 weight = 2 ，在 items2 中 weight = 2 ，总重量为 2 + 2 = 4 。
    /// 所以，我们返回 [[1,4],[2,4],[3,4]] 。
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = MergeSimilarItems(new[] {new[] {1, 1}, new[] {4, 5}, new[] {3, 8}},
                new[] {new[] {3, 1}, new[] {1, 5}});
            var result2 = MergeSimilarItems2(new[] { new[] { 1, 1 }, new[] { 4, 5 }, new[] { 3, 8 } },
                new[] { new[] { 3, 1 }, new[] { 1, 5 } });
        }

        public static IList<IList<int>> MergeSimilarItems(int[][] items1, int[][] items2)
        {
            var dic = new Dictionary<int, int>();
            foreach (var i in items1)
            {
                dic.Add(i[0], i[1]);
            }

            foreach (var i in items2)
            {
                if (dic.ContainsKey(i[0]))
                {
                    dic[i[0]] += i[1];
                }
                else
                {
                    dic.Add(i[0], i[1]);
                }
            }
            var result = dic.Select(e => new int[] {e.Key, e.Value}).OrderBy(o => o[0]).ToArray();
            return result;
        }

        public static IList<IList<int>> MergeSimilarItems2(int[][] items1, int[][] items2)
        {
            items1 = items1.Concat(items2).ToArray();
            items1 = items1.GroupBy(e => e[0])
                .Select(s => new[]{s.Key, s.Select(e => e[1]).Sum()})
                .OrderBy(o => o[0]).ToArray();

            return items1;
        }
    }
}