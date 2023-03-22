using System.Reflection.Metadata.Ecma335;

namespace 整数反转
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.Reverse(0).ToString());
        }
    }

    public class Solution
    {
        public static int Reverse(int x)
        {
            int ans = 0;
            while (x != 0)
            {
                if (ans < int.MinValue / 10 || ans > int.MaxValue / 10) return 0;
                ans = ans * 10 + x % 10;
                x /= 10;
            }
            return ans;
        }
    }
}