namespace 反转链表
{
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
    internal class Program
    {
        static void Main(string[] args)
        {
            ListNode node4 = new ListNode(5, null);
            ListNode node3 = new ListNode(4, node4);
            ListNode node2 = new ListNode(3, node3);
            ListNode node1 = new ListNode(2, node2);
            ListNode head = new ListNode(1, node1);
            ListNode ans = Solution.ReverseList(head);
            while(ans!= null)
            {
                Console.WriteLine(ans.val.ToString());
                ans = ans.next;
            }
        }
    }

    public class Solution
    {
        public static ListNode ReverseList(ListNode head)
        {
            ListNode cur = head;
            ListNode pre = null;
            ListNode nextNode = cur.next;

            while (nextNode!= null)
            {
                cur.next = pre;
                pre = cur;
                cur = nextNode;
                nextNode = nextNode.next;
            }
            cur.next = pre;
            return cur;
        }
    }
}