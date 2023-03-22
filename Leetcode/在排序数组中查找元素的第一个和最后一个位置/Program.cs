using System.IO.Pipes;

namespace 在排序数组中查找元素的第一个和最后一个位置
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] {1 };
            int[] ans = Solution.SearchRange(nums,1);
            Console.WriteLine("{0} {1}", ans[0].ToString(), ans[1].ToString());
        }
    }

    //找最左边的数就是找大于等于target的第一个数
    //找最右边的数就是大于target的第一个数左边那个数
    public class Solution
    {
        //public static int[] SearchRange(int[] nums, int target)
        //{
        //    if (nums.Length == 0) return new int[] { -1, -1 };
        //    int left = getNum(nums, target, true);
        //    int right = getNum(nums, target, false)-1;
        //    if (nums[left] == target && nums[right] == target && left <= right && right < nums.Length)
        //    {
        //        return new int[] {left,right};
        //    }

        //    return new int[] { -1, -1 };
        //}


        //public static int getNum(int[] nums, int target,bool low)
        //{

        //    int l = 0, r = nums.Length - 1;
        //    int mid = 0;
        //    int ans = nums.Length-1;
        //    while (l <= r)
        //    {
        //        mid = (l + r) >> 1;     
        //        if (nums[mid] > target || (low && nums[mid] >= target)){
        //            r = mid - 1;
        //            ans = mid;
        //        }
        //        else
        //        {
        //            l = mid + 1;
        //        }
        //    }
        //    return ans;
        //}

        //while(l <=r)
        //num[mid] >= target ,r = mid-1;
        //num[mid] < target, l = mid + 1;
        //最后找到大于等于target的第一个数
        //大于target可转化为找到大于等于(target+1）的第一个数
        //小于target的数可以转化为大于等于target的第一个数左边第一个数
        //小于等于target的数可以转化为大于target的左边第一个数

        public static int[] SearchRange(int[] nums, int target)
        {
            int start = lower_bound(nums, target);
            if (start == nums.Length || nums[start] != target)
                return new int[2] { -1, -1 };
            int end = lower_bound(nums, target + 1) - 1;
            return new int[] { start, end };
        }

        public static int lower_bound(int[] nums, int target)
        {
            int l = 0, r = nums.Length - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] >= target)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return l;
        }
    }
}