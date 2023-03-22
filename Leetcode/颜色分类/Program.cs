namespace 颜色分类
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 0, 0 };
            Solution.SortColors(nums);
        }
    }

    public class Solution
    {
        public static void SortColors(int[] nums)
        {
            int p0 = 0;
            int p2 = nums.Length - 1;
            for (int i = 0; i <= p2; i++)
            {
                while (i <= p2 && nums[i] == 2)
                {
                    swap(ref nums[i], ref nums[p2]);
                    p2--;
                }

                if (nums[i] == 0)
                {
                    swap(ref nums[i], ref nums[p0]);
                    p0++;
                }
            }
        }

        static void swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
    }
}