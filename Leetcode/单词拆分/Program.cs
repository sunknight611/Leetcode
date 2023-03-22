namespace 单词拆分
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "bb";
            IList<string> wordDict = new List<string>() { "a","bb","bbb","bbbb"};
            var solution = new Solution();
            solution.WordBreak(s, wordDict);
        }
    }

    public class Solution
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            int n = s.Length;
            //dp记录到到当前位置的字符串是否可以拆分
            bool[] dp = new bool[n + 1];
            dp[0] = true;
            for (int i = 1; i <= n; i++)
                //j枚举字符串可以拆分的位置
                for (int j = 0; j < i; j++)
                {
                    dp[i] = dp[j] && wordDict.Contains(s.Substring(j, i - j));
                    if (dp[i])
                        break;
                }
            return dp[n];
        }

        //temp和当前拼起来的字符串
        public bool dfs(string s, IList<string> wordDict, string temp)
        {
            if (temp.Length >= s.Length && !temp.Equals(s))
                return false;
            if (temp.Equals(s))
                return true;

            for (int i = 0; i < wordDict.Count; i++)
            {
                temp += wordDict[i];
                if (dfs(s, wordDict, temp)) return true;
                temp = temp.Substring(0, temp.Length - wordDict[i].Length);
            }

            return false;
        }
    }
}