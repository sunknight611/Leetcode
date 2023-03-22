namespace 有效的括号
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String s = "(){}}{";
            Console.WriteLine(Solution.IsValid(s).ToString());
        }
    }

    public class Solution
    {
        
        public static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> lookup = new Dictionary<char, char>();
            lookup.Add(')', '(');
            lookup.Add(']', '[');
            lookup.Add('}', '{');
            stack.Push(s[0]);
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '{' || s[i] == '[')
                    stack.Push(s[i]);
                else if (stack.Count == 0 && (s[i] == ')' || s[i] == '}' || s[i] == ']')) return false;
                //s[i] 和栈顶元素不匹配则入栈
                else if (lookup[s[i]] != stack.Peek())
                    stack.Push(s[i]);
                //匹配的话则两个都出栈
                else if (stack.Count != 0)
                {
                    stack.Pop();
                }
            }

            //while(stack.Count > 0)
            //{
            //    if()
            //
            if (stack.Count == 0) return true;
            else return false;
        }
    }
}