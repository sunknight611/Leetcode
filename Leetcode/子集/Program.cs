namespace 子集
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            int[] nums = { 1, 2, 3 };
            solution.Subsets(nums);
        }
    }

    public class Solution
    {
        IList<IList<int>> ans = new List<IList<int>>();
        public IList<IList<int>> Subsets(int[] nums)
        {
            ans.Add(new List<int>());
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                ans.Add(new List<int>() { nums[i] });
                dfs(new List<int>() { nums[i] }, i + 1, nums, n);
            }
            return ans;

        }

        void dfs(IList<int> temp, int cur, int[] nums, int n)
        {
            if (cur == n) return;
            for (int i = cur; i < n; i++)
            {
                List<int> copy = new List<int>(temp);
                copy.Add(nums[i]);
                ans.Add(copy);
                dfs(copy, i + 1, nums, n);
            }
        }
    }
}