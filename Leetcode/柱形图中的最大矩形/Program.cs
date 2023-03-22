namespace 柱形图中的最大矩形
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] heights = { 2, 1, 5, 6, 2, 3 };
            var solution = new Solution();
            solution.LargestRectangleArea(heights);
        }
    }

    public class Solution
    {
        public int LargestRectangleArea(int[] heights)
        {
            Stack<int> frontStack = new Stack<int>();
            Stack<int> behindStack = new Stack<int>();

            int n = heights.Length;
            int[] resFront = new int[n];
            int[] resBehind = new int[n];
            frontStack.Push(0);
            behindStack.Push(n - 1);

            for (int i = 1; i < n; i++)
            {
                //如果当前值大于单调栈顶值，则加入该数索引
                if (heights[i] >= heights[frontStack.Peek()])
                {
                    frontStack.Push(i);
                }
                else
                {
                    while (frontStack.Count > 0 && heights[i] < heights[frontStack.Peek()])
                    {
                        int top = frontStack.Pop();
                        resFront[top] = i - top;
                        
                    }
                    frontStack.Push(i);
                }
            }
            
            for (int i = n - 2; i >= 0; i--)
            {
                //如果当前值大于单调栈顶值，则加入该数索引
                if (heights[i] >= heights[behindStack.Peek()])
                {
                    behindStack.Push(i);
                }
                else
                {
                    while (behindStack.Count > 0 && heights[i] < heights[behindStack.Peek()])
                    {
                        int top = behindStack.Pop();
                        resBehind[top] = top - i;
                        
                    }
                    behindStack.Push(i);
                }
            }
            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                max = Math.Max(Math.Abs(resFront[i] - resBehind[i]) * heights[i], max);
            }

            return max;
        }
    }
}