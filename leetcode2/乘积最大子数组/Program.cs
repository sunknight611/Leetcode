namespace 乘积最大子数组
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Solution
    {
        public int MaxProduct(int[] nums)
        {
            int n = nums.Length;
            int[] dp_pos = new int[n];
            int[] dp_nag = new int[n];
            if (n == 1) return nums[0];
            //pos维护到当前i为止最大的数
            dp_pos[0] = nums[0];
            //pos维护到目前i为止最小的数
            dp_nag[0] = nums[0];
            int ans = dp_pos[0];
            for (int i = 1; i < n; i++)
            {
                if (nums[i] > 0)
                {
                    dp_pos[i] = Math.Max(dp_pos[i - 1] * nums[i], nums[i]);
                    dp_nag[i] = Math.Min(dp_nag[i - 1] * nums[i], nums[i]);
                }
                else if (nums[i] == 0)
                {
                    dp_nag[i] = 0;
                    dp_pos[i] = 0;
                }
                else
                {
                    dp_pos[i] = Math.Max(dp_nag[i - 1] * nums[i], nums[i]);
                    dp_nag[i] = Math.Min(dp_pos[i - 1] * nums[i], nums[i]);
                }
                ans = Math.Max(ans, dp_pos[i]);
                Console.WriteLine("当前最大数: " + dp_pos[i]);
                Console.WriteLine("当前最小数: " + dp_nag[i]);
                if (dp_nag[i] == 0) dp_nag[i] = 1;
                if (dp_pos[i] == 0) dp_pos[i] = 1;
            }

            return ans;
        }
    }
}