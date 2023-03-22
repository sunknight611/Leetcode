using System.Runtime.ConstrainedExecution;

namespace 盛最多水的容器
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            Console.WriteLine(Solution.MaxArea(height).ToString());
        }
    }

    public class Solution
    {
        public static int MaxArea(int[] height)
        {
            int size = height.Length;
            int left = 0,right = size-1;
            int max = Math.Min(height[right], height[left]) * (right - left);
            while(left < right)
            {   //左边界比右边界小时，从左边开始找比左边界大的数
                if (height[left] < height[right])
                {
                    int cur = left + 1;
                    while (height[left] > height[cur])
                    {
                        cur++;
                    }
                    left = cur;
                    if (cur >= right) break;
                    max = Math.Max(max, Math.Min(height[cur], height[right]) * (right - cur));
                }else if(height[left] > height[right])
                {
                    //右边界比左边界小时，从右边开始找比右边界大的数
                    int cur = right - 1;
                    while (height[right] > height[cur])
                    {
                        cur--;
                    }
                    right = cur;
                    if (cur <= left) break;
                    max = Math.Max(max, Math.Min(height[cur], height[left]) * (cur - left));
                }
                else
                {                                    
                    left++;
                    if (left >= right) break;
                }
            }
            return max; 
        }
    }
}