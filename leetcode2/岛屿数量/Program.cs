namespace 岛屿数量
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[][] grid = new char[4][]{ new char[]{'1', '1', '1', '1', '0' },
                                        new char[]{'1', '1', '0', '1', '0' },
                                         new char[]{'1', '1', '0', '0', '0' },
                                        new char[]{'0', '0', '0', '0', '0' }};
            var solution = new Solution();
            solution.NumIslands(grid);
        }
    }

    public class Solution
    {
        public int[,] dir = new int[4, 2] { { -1, 0 }, { 0, 1 }, { 0, -1 }, { 1, 0 } };
        public int NumIslands(char[][] grid)
        {
            int m = grid.GetLength(0);
            if (m == 0) return 0;
            int n = grid[0].Length;
            int ans = 0;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        ans++;
                        dfs(ref grid, i, j,m,n);
                    }
                }
            return ans;
        }

        public void dfs(ref char[][] grid, int m, int n,int max_m,int max_n)
        {
            grid[m][n] = '0';
            //没有可搜索的地方了，则ans+1
            for (int i = 0; i < 4; i++)
            {
                int next_m = m + dir[i, 0];
                int next_n = n + dir[i, 1];
                if (next_m < 0 || next_m >= max_m || next_n < 0 || next_n >= max_n) continue;
                //当前节点没访问过
                if (grid[next_m][next_n] == '1')
                {
                    dfs(ref grid, next_m, next_n,max_m,max_n);
                }
            }
        }
    }
}