using System.Runtime.InteropServices;

namespace 寻找重复数
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int nums = 
        }
    }

    public class Solution
    {
        public int FindDuplicate(int[] nums)
        {
            int n = nums.Length;

        }

        public static int Bianry(int[] nums,int left,int right,int target)
        {
            int l = left;
            int r= right;
            while(l <= r)
            {
                int mid = (r+l)/2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if(nums[mid] < target)
                {
                    l = mid + 1;                   
                }else if (nums[mid] > target)
                {
                    r = mid - 1;
                }
            }
            return -1;
        }
    }
}