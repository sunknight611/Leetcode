namespace 插入区间
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[][] intervals = new int[5][] {new int[]{ 1, 5 }, new int[] { 3, 5} , new int[] { 6, 7 }, new int[] { 8, 10 } , new int[] { 12, 16 } };
            int[] newIntervals = new int[] { 2, 5 };
            int[][] intervals = new int[2][] { new int[] { 1, 3 }, new int[] { 6, 9 } };
            Solution.Insert(intervals, newIntervals);
        }
    }

    public class Solution
    {
        public static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            int n = intervals.GetLength(0);
            int index = 0;

            List<List<int>> ans = new List<List<int>>();
            List<List<int>> a = new List<List<int>>();
            for (int i = 0; i < n; i++)
                ans.Add(new List<int>(intervals[i]));
            for (int i = 0; i < n; i++)
            {
                if (ans[i][0] > newInterval[0])
                    break;
                index++;
            }
            ans.Insert(index, new List<int>(newInterval));
            ans.Sort((p1, p2) => p1[0].CompareTo(p2[0]));

            n = ans.Count;
            index = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == 0 || ans[i][0] > a[index-1][1])
                {
                    a.Add(ans[i]);
                    index++;
                }
                else if (ans[i][0] <= a[index-1][1] && ans[i][1] > a[index - 1][1])
                {
                    a[index - 1][1] = ans[i][1];
                }
            }
            int[][] res = new int[index][];
            for (int i = 0; i < index; i++)
            {
                res[i] = a[i].ToArray();
            }
            return res;
        }
    }
}