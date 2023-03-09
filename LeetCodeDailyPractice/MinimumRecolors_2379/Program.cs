namespace MinimumRecolors_2379
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = MinimumRecolors("BWWWBB", 6);
        }

        public static int MinimumRecolors(string blocks, int k)
        {
            var result = int.MaxValue;
            for (int i = 0; i <= blocks.Length - k; i++)
            {
                var tempArr = blocks.Substring(i, k);
                var wNum = tempArr.Count(e => e == 'W');
                result = Math.Min(result, wNum);
            }

            return result;
        }

        public static int MinimumRecolors_Pro(string blocks, int k)
        {
            int l = 0, r = 0, cnt = 0;
            while (r < k)
            {
                cnt += blocks[r] == 'W' ? 1 : 0;
                r++;
            }
            int res = cnt;
            while (r < blocks.Length)
            {
                cnt += blocks[r] == 'W' ? 1 : 0;
                cnt -= blocks[l] == 'W' ? 1 : 0;
                res = Math.Min(res, cnt);
                l++;
                r++;
            }
            return res;
        }
    }
}