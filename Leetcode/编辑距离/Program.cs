namespace 编辑距离
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Solution
    {
        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;
            int[,] dp = new int[m + 1, n + 1];
            if (m * n == 0) return m + n;

            for (int i = 0; i < m + 1; i++)
                dp[i, 0] = i;

            for (int j = 0; j < n + 1; j++)
                dp[0, j] = j;

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    if (word1[i] == word2[j]) dp[i + 1, j + 1] = dp[i, j];
                    else dp[i + 1, j + 1] = 1 + Math.Min(dp[i + 1, j], Math.Min(dp[i, j + 1], dp[i, j]));
                }

            return dp[m, n];
        }

        // //cur记录当前使用的操作数,target代表要转换的字符串,curStr代表当前字符串
        // public void dfs(int cur,string target,string curStr){
        //     if(curStr.Equals(target)){
        //         ans = Math.Min(ans,cur);
        //         return;
        //     }

        //     //只有当前字符串大于等于目标字符串才操作
        //     if(curStr.Length >= target.Length){
        //         curStr +=
        //     }
        // }
    }
}