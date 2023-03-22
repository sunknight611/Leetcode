namespace 每日温度
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 73, 74, 75, 71, 69, 72, 76, 73 };
            var s = new Solution();
            var ans = s.DailyTemperatures(nums);
        }
    }

    public class Solution
    {
        public int[] DailyTemperatures(int[] temperatures)
        {
            int n = temperatures.Length;
            Stack<int> lookup = new Stack<int>();
            int[] res = new int[n];

            lookup.Push(0);
            for (int i = 1; i < n; i++)
            {
                //当前元素比栈顶元素小，则加入该元素索引
                if (temperatures[i] <= temperatures[lookup.Peek()])
                {
                    lookup.Push(i);
                }
                else
                {
                    //当前值大于单调栈栈顶元素，则当前值就是比栈顶元素大的第一个值，此时栈顶元素出栈并加入当前值
                    while (lookup.Count > 0&& temperatures[i] > temperatures[lookup.Peek()])
                    {
                        int top = lookup.Pop();
                        res[top] = i - top;
                    }
                    lookup.Push(i);
                }
            }
            return res;
        }
    }
}