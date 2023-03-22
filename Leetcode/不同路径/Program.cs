namespace 不同路径
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ans = Solution.UniquePaths(1, 2);
        }
    }

    public class Solution
    {
        public static int UniquePaths(int m, int n)
        {
            int[,] dp = new int[m, n];
            if (m == 1 || n == 1) return 1;
            dp[0, 0] = 1;
            dp[0, 1] = 1;
            dp[1, 0] = 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 1;
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    }
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}