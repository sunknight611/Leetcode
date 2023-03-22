namespace 电话号码的字母组合
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string digits = "23";
            var ans = Solution.LetterCombinations(digits);
            foreach(var temp in ans)
                Console.WriteLine(temp);
        }
    }

    public class Solution
    {
        public static IList<string> LetterCombinations(string digits)
        {
            IList<string> ans = new List<string>();
            var lookup = new Dictionary<char, string>();
            lookup.Add('2', "abc");
            lookup.Add('3', "def");
            lookup.Add('4', "ghi");
            lookup.Add('5', "jkl");
            lookup.Add('6', "mno");
            lookup.Add('7', "pqrs");
            lookup.Add('8', "tuv");
            lookup.Add('9', "wxyz");
            int n = digits.Length;
            List<string> res = new List<string>();
            for (int i = 0;i < n; i++)
            {
                //List<string> temp = new List<string>();
                List<string> res1 = new List<string>();
                for (int j = 0;j < lookup[digits[i]].Length; j++)
                {
                    if (res.Count == 0)
                    {
                        string temp = lookup[digits[i]][j].ToString();
                        res1.Add(temp);
                    }
                    else
                    {                       
                        for(int k = 0;k < res.Count;k++)
                        {
                            string temp = res[k] + lookup[digits[i]][j].ToString();
                            res1.Add(temp);
                        }
                    }
                }
                res = res1;
            }
            return res;
        }
    }
}