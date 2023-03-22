namespace 单词搜索
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[3][]
            {
                new char[]{'C','A','A'},
                new char[]{'A','A','A'},
                new char[]{'B','C','D'}
            };

            String word = "AAB";
            var solution = new Solution();
            var ans = solution.Exist(board, word);
        }
    }

    public class Solution
    {
        int[,] dir = new int[4, 2] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
        bool res = false;
        public bool Exist(char[][] board, string word)
        {
            int m = board.GetLength(0);
            int n = board[0].Length;
            bool[,] vis = new bool[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    dfs(board, vis, 0, i, j, m, n, word, word.Length - 1);

            return res;
        }

        //vis记录board中各元素是否访问过，cur记录word当前的匹配位置
        public void dfs(char[][] board, bool[,] vis, int cur, int row, int column, int m, int n, string word, int wordSize)
        {
            Console.WriteLine(board[row][column]);
            //当前访问的结点值不等于word中的值，则返回false
            if (board[row][column] != word[cur])
            {
                return;
            }
            //word全部匹配了，则返回true
            if (cur == wordSize)
            {
                res = true;
                return;
            }
            vis[row, column] = true;

            //遍历4个方向
            for (int i = 0; i < 4; i++)
            {
                int new_m = row + dir[i, 0];
                int new_n = column + dir[i, 1];
                //超出边界则继续找下一个位置
                if (new_m >= m || new_m < 0 || new_n < 0 || new_n >= n) continue;
                //下个节点没访问过的话就访问它
                if (!vis[new_m, new_n])
                {
                    vis[new_m, new_n] = true;
                    dfs(board, vis, cur + 1, new_m, new_n, m, n, word, wordSize);
                    vis[new_m, new_n] = false;
                }
            }

        }
    }
}