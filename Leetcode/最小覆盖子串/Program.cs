namespace 最小覆盖子串
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "ADOBECODEBANC";
            string t = "ABC";
            var solution = new Solution();
            solution.MinWindow(s, t);
        }
    }

    public class Solution
    {
        //ori存储t中的字符和其原本个数，cnt动态存储滑动窗口中的字符和其个数
        Dictionary<char, int> ori = new Dictionary<char, int>();
        Dictionary<char, int> cnt = new Dictionary<char, int>();
        public string MinWindow(string s, string t)
        {
            foreach (var key in t)
            {
                if (ori.ContainsKey(key))
                {
                    ori[key]++;
                }
                else
                {
                    ori.Add(key, 1);
                }
            }
            int l = 0, r = -1, ansl = -1, len = int.MaxValue;
            int n = s.Length;
            while (r < n)
            {
                //右指针往右移动一格，如果t中有这个字符，则动态维护cnt
                r++;
                if (r < n && ori.ContainsKey(s[r]))
                    if (cnt.ContainsKey(s[r]))
                        cnt[s[r]]++;
                    else cnt.Add(s[r], 1);

                //若左指针小于右指针且滑动窗口仍满足包含t中所有字符
                while (l <= r && check())
                {
                    if (len > r - l + 1)
                    {
                        len = r - l + 1;
                        ansl = l;
                    }

                    if (ori.ContainsKey(s[l]))
                        cnt[s[l]]--;

                    l++;
                }
            }
            return ansl == -1 ? string.Empty : s.Substring(ansl, len);
        }
        //检查滑动窗口是否包含t
        bool check()
        {
            foreach ((char key, int value) in ori)
            {
                if (!cnt.ContainsKey(key)||ori[key] != cnt[key]  )
                {
                    return false;
                }
            }
            return true;
        }
    }
}