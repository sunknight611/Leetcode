namespace N字形变换
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "PAYPALISHIRING";
            Console.WriteLine(Solution.Convert(s, 4));
        }
    }

    public class Solution
    {
        public static string Convert(string s, int numRows)
        {
            char[,] nums = new char[numRows, 1000];
            string ansstring = "";
            int index = 0;
            int curColumn = 0;
            if (numRows == 1) return s;
            for(int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < 1000; j++)
                    nums[i, j] = (char)('0');
            }
            while(index != s.Length)
            {
                for(int i = 0; i < numRows && index< s.Length; i++)
                {
                    nums[i, curColumn] = s[index];
                    index++;
                }
                //index += numRows;
                for(int i = 1;i < numRows - 1&&index < s.Length; i++)
                {
                    nums[numRows - i - 1,curColumn + i ] = s[index];
                    index++;
                }
                curColumn += (numRows - 1);
                //index += (numRows - 2);
            }

            foreach (var ans in nums)
            {
                if (ans != '0')
                    ansstring += ans;
            }

            //for(int i = 0;i < numRows; i++)
            //{
            //    for (int j = 0; j < 7; j++)
            //        Console.Write(nums[i, j] + " ");

            //    Console.Write('\n');
            //}
            return ansstring;
        }
    }
}