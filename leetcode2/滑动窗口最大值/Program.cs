using System;
using System.Collections;

namespace 滑动窗口最大值
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 9, 10, 9, -7, -4, -8, 2, -6 };
            var s = new Solution();
            s.MaxSlidingWindow(nums, 5);
        }
    }

    public struct Node
    {
        //标记该元素在list的位置
        public int index;
        public int val;
        public Node(int index, int val)
        {
            this.index = index;
            this.val = val;
        }
    }

    public class MyCompare : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y) return -1;
            else if (x == y) return 0;
            else return 1;
        }
    }



    public class Solution
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int n = nums.Length;
            int[] ans = new int[n - k + 1];
            IComparer<int> myCompare = new MyCompare();
            PriorityQueue<Node,int> priQueue = new PriorityQueue<Node,int>(myCompare);

            //将一次滑动窗口中的元素加入优先队列
            for (int i = 0; i < k; i++)
            {
                priQueue.Enqueue(new Node(i, nums[i]), nums[i]);
            }
            ans[0] = priQueue.Peek().val;

            for (int i = k; i < n; i++)
            {
                priQueue.Enqueue(new Node(i, nums[i]), nums[i]);
                //如果当前堆顶元素的索引在栈外，则移除元素
                if (priQueue.Peek().index <= i - k)
                {
                    while(priQueue.Peek().index <= i - k)
                        priQueue.Dequeue();
                    ans[i - k + 1] = priQueue.Peek().val;
                }
                else
                {
                    ans[i - k + 1] = priQueue.Peek().val;
                }
            }

            return ans;
        }
    }
}