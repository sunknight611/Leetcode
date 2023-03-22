namespace 组合总和
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Solution
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            IList<int> cur = new List<int>();
            dfs(cur, ans, candidates, target, 0);
            return ans;
        }

        //每次加入一个数的时候可以选择加入这个数也可以选择不加入这个数
        public void dfs(IList<int> cur, IList<IList<int>> ans, int[] candidates, int target, int index)
        {
            //所有数字都已经用过了还是达不到target则退出搜索
            if (index == candidates.Length)
                return;
            //当前组合之和已等于指定值
            if (target == 0)
            {
                List<int> temp = new List<int>();
                foreach (var item in cur)
                {
                    temp.Add(item);
                }
                ans.Add(temp);
                return;
            }

            //不加入当前值
            dfs(cur, ans, candidates, target, index + 1);
            //加入当前值(target值要大于等于当前值，否则就剪枝)
            if (target - candidates[index] >= 0)
            {
                cur.Add(candidates[index]);
                dfs(cur, ans, candidates, target - candidates[index], index);
                cur.Remove(candidates[index]);
            }
        }
    }
}