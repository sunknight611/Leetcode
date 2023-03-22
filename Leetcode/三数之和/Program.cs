using System.Reflection.Metadata.Ecma335;

namespace 三数之和
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[]{ 0,0,0,0 };
            var ans = Solution.ThreeSum(nums);
            foreach(var i in ans)
            {
                foreach(var j in i)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
        }
    }

    public class Solution
    {
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            var lookup = new Dictionary<String, int>();    
            Array.Sort(nums);
            int n = nums.Length;
            //for(int i = 0; i < nums.Length-2; i++)
            //{
            //    for(int j = i + 1; j < nums.Length-1; j++)
            //    {
            //        for(int k = j + 1; k < nums.Length; k++)
            //        {
            //            if (k < nums.Length - 1 && nums[k] == nums[k + 1]) continue;
            //            if (nums[i] + nums[j] + nums[k] == 0)
            //            {
            //                List<int> result = new List<int>();
            //                result.Add(nums[i]);
            //                result.Add(nums[j]);
            //                result.Add(nums[k]);

            //                var key = nums[i].ToString() + "-" + nums[j].ToString() + "-" + nums[k].ToString();
            //                if (!lookup.ContainsKey(key))
            //                {
            //                    lookup.Add(key, 1);
            //                    ans.Add(result);
            //                }
                           
            //            }
            //        }
            //    }

            //    if (nums[i] + nums[i + 1] >= 0) break;
            bool flag = false;//如果为true代表前面已经有两个一样的数
            if(nums.Length < 3) return ans;
            //i代表最左边的数
            for(int i = 0; i < n; i++)
            {
                //如果最小的数大于0代表三数之和必大于0
                if (nums[i] > 0) break;
                //如果一个数和前面的数相等，则跳过
                if(i > 1 && nums[i] == nums[i - 1])
                {
                    continue;
                }
                int left = i + 1;
                int right = n - 1;
                while (left < right)
                {
                    //如果三数之和等于0
                    int sum = nums[left] + nums[right] + nums[i];
                    if (sum == 0)
                    {
                        List<int> list = new List<int>();
                        list.Add(nums[i]);
                        list.Add(nums[left]);                  
                        list.Add(nums[right]);
                        ans.Add(list);
                        //如果左指针数和后一个数重复，则向后找到不重复的数
                        while (nums[left] == nums[left + 1] && left < right)
                        {
                            left++;
                            if (left >= n-1) break;
                        }
                        //如果右指针数和前一个数重复，则向前找到不重复的数
                        while (nums[right] == nums[right - 1] && left < right)
                        {
                            right--;
                            if (right <= 0) break;
                        }
                        
                        left++; right--;
                    }
                    else if (sum < 0) left++;
                    else right--;
                }          
            }
            return ans;
        }
    }
}