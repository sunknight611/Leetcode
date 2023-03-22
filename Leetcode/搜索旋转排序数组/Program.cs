using System.Security.AccessControl;

namespace 搜索旋转排序数组
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] {4,5,6,7,0,1,2 };
            int ans = Solution.Search(nums, 3);
            Console.WriteLine(ans.ToString());
        }
    }

    public class Solution
    {
        public static int Search(int[] nums, int target)
        {
            int l = 0, r = nums.Length - 1;
            int mid = (l + r) / 2;
            while (l <= r)
            {
                //说明mid右边的数都是有序的，对右边做二分查找
                if (nums[mid] < nums[l])
                {
                    //答案在右边有序数组中
                    int ans = BinaySearch(nums, mid + 1, r, target);
                    if (ans != -1)
                    {
                        return ans;
                    }//不在右边，则继续对左边切分
                    else
                    {
                        r = mid;
                        mid = (l + r) / 2;
                    }
                }
                else
                {
                    int ans = BinaySearch(nums, l, mid, target);
                    if (ans != -1)
                    {
                        return ans;
                    }//不在右边，则继续对左边切分
                    else
                    {
                        l = mid + 1;
                        mid = (r + l) / 2;
                    }
                }
            }

            return -1;
        }

        public static int BinaySearch(int[] nums,int left,int right,int val)
        {
            while(left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == val)
                {
                    return mid;
                }
                else if (nums[mid] < val)
                {
                    left = mid+1;
                }
                else
                {
                    right = mid-1;
                }
            }

            return -1;
        }
    }
}