namespace 字符串转换整数
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("    43Hello, World!");
            string s = "2147483648";
            Console.WriteLine(Solution.MyAtoi(s).ToString());
        }
    }

    public class Solution
    {
        public static int MyAtoi(string s)
        {
            int ans = 0;bool flag = true;//标志-是否为第一次发现
            bool record = false;//是否录入数字
            for(int i = 0;i < s.Length;i++)
            {
                //空格，跳过
                if (s[i] == ' ' && !record)
                {
                    continue;
                }
                //若为第一次录入-则记录
                else if (s[i] == '-' && flag&&!record)
                {
                    // -后面前面不能有空格或字符，否则就当字符处理停止循环
                    if (i >= 1 && i < s.Length - 1)
                        if (s[i - 1] != ' ' || (s[i + 1]<'0' && s[i+1]>'9')) break;
                    flag = false;
                }
                else if (s[i] == '+')
                {
                    // +后面前面不能有空格或字符，否则就当字符处理停止循环
                    if (i >= 1&&i < s.Length - 1)
                        if (s[i - 1] != ' ' || (s[i + 1] < '0' && s[i + 1] > '9')) break;
                }
                else if (s[i] <= '9' && s[i] >= '0')
                {
                    //flag = true;
                    record = true;
                    if (ans == 0 && s[i] == '0') continue;
                    //若前8位数字超过int/10边界则返回
                    if (ans < int.MinValue / 10 || ans > int.MaxValue / 10)
                    {
                        if (!flag) ans = int.MinValue;
                        else ans = int.MaxValue; 
                        break;
                    }
                    if(ans == int.MaxValue / 10)
                    {
                        //若ans为int最大值除10且s[i] > 7则越界
                        if (flag && s[i] > '7' && s[i] <= '9')
                        {
                            ans = int.MaxValue; break;
                        }
                        if (!flag && s[i]=='9')
                        {
                            ans = int.MinValue; break;
                        }
                    }
                    ans = 10 * ans + (s[i] - '0');
                }//若还是录入数字状态，且遇到不是数字的字符，则停止循环
                else break;
            }
            return flag ? ans:-ans;
        }
    }
}