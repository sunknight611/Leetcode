namespace 寻找旋转数组中的最小值
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
        public int FindMin(int[] nums)
        {
            int l = 0;
            int r = nums.Length - 2;
            int n = nums.Length;
            //最右边元素只可能是最小值或在最小值右边
            //用nums[mid]和最右边值作比较
            //若nums[mid] > 最右边值，说明nums[mid]只可能在最小值左边
            //若nums[mid] < 最右边值，说明nums[mid]只可能在最小值右边
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] > nums[n - 1])
                {
                    l = mid + 1;
                    Console.WriteLine(l.ToString());
                }
                else
                {
                    r = mid - 1;
                }
            }
            return nums[l];
        }
    }
}