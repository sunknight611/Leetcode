namespace 合并区间
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] nums = new int[4][];
            nums[0] =new int[]{ 1,3};
            nums[1] = new int[] {2,6};
            nums[2] = new int[] { 8,10 };
            nums[3] = new int[] { 15, 18 };
            var ans = Solution.Merge(nums);
            for(int i = 0;i < ans.GetLength(0);i++)
            {
                Console.Write(ans[i][0].ToString()+ ' ' + ans[i][1].ToString());
            }
        }        
    }

    public class Solution
    {
        public static int[][] Merge(int[][] intervals)
        {
            var ans = new List<List<int>>();
            Array.Sort(intervals, (p1, p2) => p1[0].CompareTo(p2[0]));
            int index = -1;
            int n = intervals.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                //如果当前答案数组中为空，或者intervals中新的数组中左边的数大于当前
                //答案数组中右边的数，说明新数组最小数扔大于答案数组最大数，则将该新数组加入答案数组
                if (ans.Count == 0 || intervals[i][0] > ans[index][1])
                {
                    ans.Add(new List<int>() { intervals[i][0], intervals[i][1] });
                    index++;
                }
                else if (intervals[i][0] < ans[index][1] && intervals[i][1] > ans[index][1])
                {
                    ans[index][1] = intervals[i][1];
                }
            }
            int[][] a = new int[ans.Count][];
            for (int i = 0; i < ans.Count; i++)
            {
                a[0] = ans[i].ToArray();
            }
            return a;
        }
    }
}