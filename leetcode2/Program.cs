namespace leetcode2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3 };
            var solution = new Solution();
            solution.NextPermutation(nums);
        }
    }

    public class Solution
    {
        public void NextPermutation(int[] nums)
        {
            int n = nums.Length;
            int l = 0, r = 0;
            if (n < 2) return;
            //找到一个比右边数略小的数
            for (l = n - 2; l >= 0; l--)
            {
                //Console.WriteLine(l);
                if (nums[l] < nums[l + 1])
                    break;
            }

            //在右边找到比这个数略大的数
            for (r = n - 1; r >= 0; r--)
            {
                //Console.WriteLine(r);
                if (nums[r] > nums[l])
                    break;
            }
            swap(ref nums[l], ref nums[r]);
            reverse(nums, l + 1, n - 1);
        }


        void swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        void reverse(int[] nums, int l, int r)
        {
            while (l < r)
            {
                swap(ref nums[l], ref nums[r]);
                l++;
                r--;
            }
        }
    }
}