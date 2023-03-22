namespace _85.最大矩形
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[][] matrix = new char[4][]
            {
                new char[]{'1','0','1','0','0'},
                new char[]{'1','0','1','1','1'},
                new char[]{'1','1','1','1','1'},
                new char[]{'1','0','0','1','0'}
            };
            var s = new Solution();
            s.MaximalRectangle(matrix);
        }
    }

    public class Solution
    {
        public int MaximalRectangle(char[][] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix[0].Length;
            Stack<int> frontStack = new Stack<int>();
            Stack<int> behindStack = new Stack<int>();
            int[,] left = new int[m, n];
            int max = int.MinValue;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == '0')
                    {
                        Console.Write("0 ");
                        continue;
                    }
                    else
                    {
                        left[i, j] = j == 0 ? 1 : left[i, j - 1] + 1;
                        Console.Write(left[i, j].ToString() + " ");
                    }
                }
                Console.WriteLine();
            }
            //横着遍历不同底边
            for (int i = 0; i < n; i++)
            {
                frontStack.Clear();
                behindStack.Clear();
                int[] frontRes = new int[m];
                int[] behindRes = new int[m];
                frontStack.Push(0);
                behindStack.Push(m - 1);
                for (int j = 0; j < m; j++)
                {
                    //如果当前元素小于栈顶元素，则说明该元素是栈顶元素左边第一个比它的小的数
                    //反之则入栈
                    if (frontStack.Count > 0 && left[j, i] >= left[frontStack.Peek(), i])
                    {
                        frontStack.Push(j);
                    }
                    else
                    {
                        while (frontStack.Count > 0 && left[j, i] < left[frontStack.Peek(), i])
                        {
                            frontRes[frontStack.Pop()] = j;
                        }
                        frontStack.Push(j);
                    }
                }
                
                while (frontStack.Count > 0)
                {
                    frontRes[frontStack.Pop()] = m;
                }

                for (int j = m - 1; j >= 0; j--)
                {
                    if (behindStack.Count > 0 && left[j, i] >= left[behindStack.Peek(), i])
                    {
                        behindStack.Push(j);
                    }
                    else
                    {
                        while (behindStack.Count > 0 && left[j, i] < left[behindStack.Peek(), i])
                        {
                            behindRes[behindStack.Pop()] = j;
                        }
                        behindStack.Push(j);
                    }
                }

                while (behindStack.Count > 0)
                {
                    behindRes[behindStack.Pop()] = -1;
                }

                for (int k = 0; k < m; k++)
                {
                    max = Math.Max(max, (frontRes[k] - behindRes[k] - 1) * left[k, i]);
                    Console.WriteLine(max);
                }

            }
            return max;
        }
    }
}