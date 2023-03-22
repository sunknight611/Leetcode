namespace 无重复字符的最长子串
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "abcabcbb";
            int ans = Solution.LengthOfLongestSubstring(s);
            Console.WriteLine(ans);
        }
    }

    public class Solution
    {
        public static int LengthOfLongestSubstring(string s)
        {
            int left = 0,max = 0;
            List<char> find = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                while (find.Contains(s[i]))
                {
                    find.RemoveAt(0);
                    left++;
                }
                find.Add(s[i]);
                max = Math.Max(max,i - left + 1);
            }

            return max;
        }
    }
}