namespace 全排列
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 6, 3, 2, 7, 4, -1 };
            Solution s = new Solution();
            var ans = new List<int>();
            bool[] vis = new bool[nums.Length];
            IList<IList<int>> lists = new List<IList<int>>();   
            s.permutation(lists,ans, vis, nums);
            return;
        }
    }

    public class Solution
    {
        public void permutation(IList<IList<int>> lists,List<int> ans, bool[] vis, int[] nums)
        {
            int n = nums.Length;
            if (ans.Count == n)
            {
                var list = new List<int>();
                foreach(var item in ans) 
                    {
                        list.Add(item);
                    } 
                lists.Add(list);
                //foreach (var item in ans)
                //    Console.Write(item.ToString());
                //Console.WriteLine();
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (!vis[i])
                {
                    ans.Add(nums[i]);
                    vis[i] = true;
                    permutation( lists,ans, vis, nums);
                    ans.Remove(nums[i]);
                    vis[i] = false;
                }
            }
        }
        //public IList<IList<int>> Permute(int[] nums)
        //{
           
        //    List<int> ans = new List<int>();
        //    bool[] vis = new bool[4];
        //    permutation( ans, vis, nums);
        //    return lists;
        //}
    }
}