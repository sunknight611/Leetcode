using System;
using System.Text;

namespace Leetcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            num1 = int.Parse(Console.ReadLine());
            num2 = int.Parse(Console.ReadLine());
            ListNode l1 = new ListNode();
            ListNode l2 = new ListNode();
            ListNode p1 = l1, p2 = l2;
            int n1 = int.Parse((Console.ReadLine()));
            p1.val= n1;
            for (int i = 0; i < num1-1; i++)
            {
                int num = int.Parse((Console.ReadLine()));               
                ListNode s = new ListNode();
                s.val = num;               
                p1.next = s;
                p1 = s;
            }
            int n2 = int.Parse((Console.ReadLine()));
            p2.val = n2;
            for (int i = 0; i < num2 - 1; i++)
            {
                int num = int.Parse((Console.ReadLine()));
                ListNode s = new ListNode();
                s.val = num;
                p2.next = s;
                p2 = s;
            }
            
            ListNode ans = Solution.AddTwoNumbers(l1, l2);
            while(ans != null) { Console.WriteLine(ans.val); }
        }
    }

    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int val = 0, ListNode next = null)
      {
            this.val = val;
            this.next = next;
       }
    }
    public class Solution
    {
        //public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        //{
        //    // Stack ans = new Stack();
        //    int[] L1 = new int[100];
        //    int[] L2 = new int[100];
        //    int index1 = 0,index2 = 0;
        //    int Length = 0;
        //    bool carry = false;
        //    //ListNode L1 = l1,L2 = l2;
        //    while (l1 != null)
        //    {
        //        L1[index1++] = l1.val;
        //        l1 = l1.next;
        //    }

        //    while (l2 != null)
        //    {
        //        L2[index2++] = l2.val;
        //        l2 = l2.next;
        //    }

        //    Length = Math.Max(index1, index2);
        //    int[] ans = new int[Length];
        //    for (int i = 0; i < Length; i++)
        //    {
        //        ans[i] = carry ? L1[i] + L2[i] + 1 : L1[i] + L2[i];
        //        if (ans[i] > 9)
        //        {
        //            ans[i] = ans[i] % 10;
        //            carry = true;
        //        }
        //        else
        //            carry = false;
        //    }
        //ListNode ansNode = new ListNode();
        //ListNode p = new ListNode();
        // p = ansNode;
        //for(int i = 0; i<Length;i++){
        //    ListNode s = new ListNode();
        //    s.val = ans[i];
        //    p.next = s;
        //    p = s;       
        //    }

        //    if (carry)
        //    {
        //        ListNode s = new ListNode();
        //        s.val = 1;
        //        p.next = s;
        //    }
        //return ansNode.next;
        //}
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            // Stack ans = new Stack();
            ListNode head = new ListNode(0);
            ListNode cur = head;
            int carry = 0;
            while (l1 != null || l2 != null)
            {
                int cur1 = l1 == null ? 0 : l1.val;
                int cur2 = l2 == null ? 0 : l2.val;

                int sum = cur1 + cur2 + carry;

                if (sum >= 10)
                {
                    carry = 1;
                    sum %= 10;
                }

                cur.next = new ListNode(sum);

                cur = cur.next;
                if (l1.next != null) l1 = l1.next;
                if (l2.next != null) l2 = l2.next;
            }

            if (carry == 1)
            {
                cur.next = new ListNode(1);
                cur = cur.next;
            }
            return head.next;
        }
    }
}