using System.Reflection;

namespace 下一个排列
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] nums = new int[] { 1, 2, 3 };
            s.NextPermutation(nums);
           
        }
    }

    public class Solution
    {
        //public static void 
        //先从后往前找到一个较大的值i，使得它后面的数都降序排列，
        //说明此时后面的排列已经全部排过了
        //再从后面的数中找第一个比它大的数j
        //下一个排列应该从j开始，所以交换两个数
        //同时将j后面的数从最小开始排列(j后面的数一定是降序排列的)
        public void NextPermutation(int[] nums)
        {
            int i = nums.Length - 2, j = nums.Length - 1;
            while(i >= 0 && nums[i] >= nums[i+1])
            {               
                i--;
            }

            if(i >= 0){
                while (j >= 0 && nums[j] <= nums[i])
                {
                    j--;
                }
                swap(nums, i, j);
            }            
            reverse(nums,i + 1,nums.Length-1);
        }

        public void swap(int[] nums,int i,int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        public void reverse(int[] nums,int left,int right)
        {
            int r = right;
            int l = left;
            while (l < r)
            {
                swap(nums, l, r);
                l++;
                r--;
            }
        }
    }
}