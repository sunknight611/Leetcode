namespace 字符串中的第一个唯一字符
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "aabb";
            Console.WriteLine(Solution.FirstUniqChar(s).ToString());
        }
    }

    public class Solution
    {
        
        public static int FirstUniqChar(string s)
        {
            var lookUp = new Dictionary<char, int>();
            for(int i = 0; i < s.Length; i++)
            {
                if (!lookUp.ContainsKey(s[i]))
                {
                    lookUp.Add(s[i], 1);
                }
                else
                {
                    lookUp[s[i]]++;
                }
            }

            for(int i =0;i < s.Length; i++)
            {
                if (lookUp[s[i]] == 1)
                    return i;
            }

            return -1;
        }
    }
}