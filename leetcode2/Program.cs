namespace leetcode2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 1 };
            var s = new Solution();
            s.Search(nums, 1);
        }


    }

    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            int n = nums.Length;
            int left = 0, right = n - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                //左边是有序的
                if (nums[mid] > nums[left])
                {
                    int ans = BinaySearch(nums, left, mid, target);
                    if (ans == -1)
                    {
                        left = mid;
                    }
                    else
                    {
                        return ans;
                    }
                }
                else
                {//右边是有序的
                    int ans = BinaySearch(nums, mid, right, target);
                    if (ans == -1)
                    {
                        right = mid;
                    }
                    else
                    {
                        return ans;
                    }
                }
            }
            return -1;
        }

        public int BinaySearch(int[] nums, int left, int right, int val)
        {
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == val)
                    return mid;
                else if (nums[mid] > val)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return -1;
        }
    }



}