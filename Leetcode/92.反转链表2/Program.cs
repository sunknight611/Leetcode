namespace _92.反转链表2
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
        }

        public class Solution
        {
            public ListNode ReverseBetween(ListNode head, int left, int right)
            {
                //设置哨兵结点，防止left == 0的情况
                ListNode dummy = new ListNode(0, head);
                ListNode p0 = dummy;
                int index = 1;
                while (index < left)
                {
                    p0 = p0.next;
                    index++;
                }

                ListNode cur = p0.next;
                ListNode pre = null;
                while (index <= right)
                {
                    ListNode nextNode = cur.next;
                    cur.next = pre;
                    pre = cur;
                    cur = nextNode;
                    index++;
                }

                p0.next.next = cur;
                p0.next = pre;
                return dummy.next;
            }
        }
    }
}