namespace 多数元素
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {2,3,1,1,1,2,2 };
            Console.WriteLine(Solution.MajorityElement(nums).ToString());
        }
    }

    public class Solution
    {
        public static int MajorityElement(int[] nums)
        {
            int count = 0;
            int prenum = nums[0];
            for(int i = 0;i < nums.Length; i++)
            {
                if (nums[i] == prenum)
                {
                    count++;
                }
                else
                {
                    if (count != 0)
                        count--;
                    else prenum = nums[i];
                }
            }

            return prenum;
        }
    }
}