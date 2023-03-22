namespace 最长回文子串
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "babad";
            string ans = Solution.LongestPalindrome(s);
            Console.WriteLine(ans);
        }

    }

    public class Solution
    {
        
        public static string LongestPalindrome(string s)
        {
            int[,] dp = new int[1000,1000];
            string ans = "";
            for(int i = 0;i < s.Length;i++)
            {
                for(int k = 0;i + k < s.Length;k++)
                {
                    int j = i + k;
                    if (i == 0)
                    {
                        dp[k,j] = 1;
                    }else if(i == 1)
                    {
                        if (s[k] == s[j])
                            dp[k,j] = 1;
                    }
                    else
                    {
                        if (s[k] == s[j]&& dp[k + 1,j-1] == 1)
                        {
                            dp[k, j] = 1;
                        }
                    }
                    if (dp[k, j] == 1 && i + 1 > ans.Length)
                    {
                        ans = s.Substring(k, j - k + 1);
                    }
                }
            }
            return ans;
        }
    }
}