namespace 课程表2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] pre = new int[1][] { new int[]{ 1, 0 } };
            var s = new Solution();
            s.FindOrder(2,pre);
        }
    }

    public class Solution
    {
        Stack<int> ans = new Stack<int>();
        int[] vis;
        bool invalid = false;
        Dictionary<int, List<int>> edge;
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            edge = new Dictionary<int, List<int>>();
            vis = new int[numCourses];
            for (int i = 0; i < prerequisites.GetLength(0); i++)
            {
                if (!edge.ContainsKey(prerequisites[i][1]))
                {
                    edge.Add(prerequisites[i][1], new List<int>() { prerequisites[i][0] });
                }
                else
                {
                    edge[prerequisites[i][1]].Add(prerequisites[i][0]);
                }
            }

            for (int i = 0; i < numCourses; i++)
            {
                if (!invalid && vis[i] == 0)
                    dfs(i);
            }

            return ans.Count == numCourses ? ans.ToArray() : new int[] { };

        }

        public void dfs(int u)
        {
            vis[u] = 1;
            if (edge.ContainsKey(u))
            {
                for (int v = 0; v < edge[u].Count; v++)
                {
                    if (vis[edge[u][v]] == 0)
                    {
                        dfs(edge[u][v]);
                        if (invalid) return;
                        //vis = 1表示该节点在搜索过程中又被搜索到了，代表有环，invalid= true
                    }
                    else if (vis[edge[u][v]] == 1)
                    {
                        invalid = true;
                        return;
                    }
                }
            }
            //2代表搜索过了
            vis[u] = 2;
            ans.Push(u);
        }
    }
}