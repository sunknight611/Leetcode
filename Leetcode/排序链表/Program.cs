namespace 排序链表
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
            ListNode root = new ListNode(4);
            ListNode node1 = new ListNode(2);
            ListNode node2 = new ListNode(1);
            ListNode node3 = new ListNode(3);
            root.next = node1;
            node1.next = node2;
            node2.next = node3;

            var solution = new Solution();
            solution.SortList(root);
        }
    }

    public class Solution
    {
        public ListNode SortList(ListNode head)
        {
            return Sort(head, null);
        }

        public ListNode Sort(ListNode head, ListNode tail)
        {
            if (head == null)
                return null;
            //如果head.next为tail，，说明只有一个节点,直接返回
            if (head.next == tail)
            {
                head.next = null;
                return head;
            }

            ListNode slow = head;
            ListNode fast = head;

            //找到链表中间结点，做归并排序
            while (fast != tail)
            {
                slow = slow.next;
                fast = fast.next;
                if (fast != tail)
                    fast = fast.next;
            }
            ListNode mid = slow;
            ListNode left = Sort(head, mid);
            ListNode right = Sort(mid, tail);
            ListNode ans = Merge(left, right);
            return ans;
        }

        public ListNode Merge(ListNode list1, ListNode list2)
        {
            //设置哨兵结点
            ListNode dummy = new ListNode(0);
            ListNode temp = dummy, temp1 = list1, temp2 = list2;
            while (temp1 != null && temp2 != null)
            {
                if (temp1.val <= temp2.val)
                {
                    temp.next = temp1;
                    temp1 = temp1.next;
                    temp = temp.next;
                }
                else
                {
                    temp.next = temp2;
                    temp2 = temp2.next;
                    temp = temp.next;
                }
                //合并剩下的链表
                if (temp1 == null)
                {
                    temp.next = temp2;
                }

                if (temp2 == null)
                {
                    temp.next = temp1;
                }

            }
            return dummy.next;
        }
    }
}