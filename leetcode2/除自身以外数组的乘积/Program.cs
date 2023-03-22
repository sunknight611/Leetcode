namespace 除自身以外数组的乘积
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4 };
            var s = new Solution();
            s.ProductExceptSelf(nums);
        }
    }

    public class Solution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] ans = new int[n];
            ans[0] = 1;
            for (int i = 1; i <n; i++)
            {
                ans[i] = ans[i-1] * nums[i-1];
            }

            int r = 1;
            for (int i = n - 1; i >= 0; i++)
            {
                ans[i] = ans[i] * r;
                r *= nums[i];
            }
                
            return ans;
        }
    }
}