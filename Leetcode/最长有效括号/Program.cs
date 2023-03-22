using System.Security.AccessControl;

namespace 最长有效括号
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "(()";
            Console.WriteLine(Solution.LongestValidParentheses(s).ToString());
        }
    }

    public class Solution
    {
        //public void Generate(int left,int right,string s,string cur)
        //{
        //    //如果当前字符串遍历结束，则递归结束
        //    if(cur.Length == s.Length)
        //    {
        //        return;
        //    }
        //}
        public static int LongestValidParentheses(string s)
        {
            int left = 0, right = 0;
            int maxCount = 0, curCount = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') left++;
                else right++;
                
                //若当前右括号数大于左括号数，则不构成有效括号，
                //更新当前有效括号数和最大括号数
                if(right > left)
                {
                    maxCount = Math.Max(curCount, maxCount);
                    curCount = 0;
                    left = right = 0;
                }
                //
                else if(right == left)
                {
                    maxCount = Math.Max(2 * right, maxCount);
                }
            }

            left = right = 0;

            for (int i = s.Length - 1; i >=0; i--)
            {
                if (s[i] == '(') left++;
                else right++;

                if (right < left)
                {
                    curCount = 0;
                    left = right = 0;
                }
                //
                else if (right == left)
                {
                    maxCount = Math.Max(2 * left, maxCount);
                }
            }
            return maxCount;
        }
    }
}