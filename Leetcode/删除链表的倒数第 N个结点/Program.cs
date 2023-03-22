using System.Xml.Linq;

namespace 删除链表的倒数第_N个结点
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ListNode node4 = new ListNode(5, null);
            //ListNode node3 = new ListNode(4, node4);
            //ListNode node2 = new ListNode(3, node3);
            //ListNode node1 = new ListNode(2, null);
            ListNode head = new ListNode(1,null);
            Solution.RemoveNthFromEnd(head, 0);
        }
    }


    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) 
        {
          this.val = val;
          this.next = next;
        }
    }

    public class PreNode
    {
        public PreNode pre;
        public int val;
        public PreNode(PreNode pre = null,int val = 0)
        {
            this.pre = pre;
            this.val = val;
        }
    }

    public class Solution
    {
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            List<int> ans = new List<int> ();
            ListNode tempNode = head;
            PreNode preHead = new PreNode(null,tempNode.val);
            while(tempNode.next != null)
            {
                PreNode node = new PreNode(preHead,tempNode.next.val);
                preHead = node;
                tempNode = tempNode.next;
            }
            PreNode tempPre = preHead;
            int num = 0;
            while(tempPre != null)
            {
                ans.Add (tempPre.val);
                tempPre = tempPre.pre;
            }
            ans.RemoveAt(n - 1);
            ListNode Head = new ListNode();
            ListNode temp = Head;
            for(int i = ans.Count-1;i >=0; i--)
            {
                ListNode node = new ListNode(ans[i]);
                temp.next = node;
                temp = node;
            }

            return Head.next;
        }
    }
}