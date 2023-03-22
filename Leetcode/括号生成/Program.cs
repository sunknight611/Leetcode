using System.Security.AccessControl;

namespace 括号生成
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<string> ans = Solution.GenerateParenthesis(2);
            foreach (string s in ans)
            {
                Console.WriteLine(s);
            }
        }
    }
    //在生成中，左括号的数量要始终大于右括号的数量，否则就生成失败.如果最后左括号的数量等于右括号的数量
    //则生成成功
    public class Solution
    {       
        public static void Generate(int n,string cur,List<string> ans,int left,int right)
        {
            //如果添加到最后一个括号也能匹配，则添加答案
            if(cur.Length == 2 * n)
            {
                ans.Add(cur);
                return;
            }
            if(left < n)
            {
                cur += '(';
                Generate(n, cur, ans,left + 1,right);
                cur = cur.Remove(cur.Length - 1);
            }
            
            if(right < left)
            {
                cur += ')';
                Generate(n, cur, ans,left,right+1);
                cur = cur.Remove(cur.Length - 1);
            }
            
        }
        public static IList<string> GenerateParenthesis(int n)
        {
            List<string> ans = new List<string>();
            string cur = "";
            Generate(n, cur,ans,0,0);
            return ans;
        }
    }
}