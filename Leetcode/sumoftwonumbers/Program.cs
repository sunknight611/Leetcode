namespace sumoftwonumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 3};
            int[] ans = Solution.TwoSum(nums,6);
            foreach(var i in ans) { Console.WriteLine(i); }
        }
    }

    public class Solution
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            int[] numcopy = new int[nums.Length];
            bool flag = true;
            Array.Copy(nums, numcopy, nums.Length);
            Array.Sort(nums);                    
            int idx1 = 0, idx2 = nums.Length - 1, ans1 = 0, ans2 = 0;
            while (nums[idx1] + nums[idx2] != target)
            {
                if (nums[idx1] + nums[idx2] > target)
                    idx2--;
                else idx1++;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (numcopy[i] == nums[idx1] && flag)
                {
                    ans1 = i;
                    flag = false;
                }                   
                if (numcopy[i] == nums[idx2])
                    ans2 = i;
            }
            int[] ans = new int[2] { ans1, ans2 };
            return ans;
        }
    }
}