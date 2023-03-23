namespace _240.搜索二维矩阵_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[5][] { new int[] { 1,4,7,11,15 },
                                            new int[] {2,5,8,12,19},
                                            new int[]{ 3,6,9,16,22 },
                                            new int[]{ 10,13,14,17,24 },
                                            new int[]{ 18, 21, 23, 26, 30 } };
            //int[][] matrix = new int[1][] { new int[] { -5 } };
            var s = new Solution();
            s.SearchMatrix(matrix, 5);
        }
    }

    public class Solution
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            //二分搜索，在一行找到大于等于target的数
            int m = matrix.GetLength(0);
            int n = matrix[0].Length;
            if (m == 0) return false;
            //对每一行做二分
            for (int i = 0; i < m; i++)
            {
                int col = lower_bound(matrix[i], target);
                if (col == n || matrix[i][col] != target) return false;
            }

            return true;
        }

        public int lower_bound(int[] nums, int target)
        {
            int l = 0, r = nums.Length - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] >= target)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return l;
        }
    }
}