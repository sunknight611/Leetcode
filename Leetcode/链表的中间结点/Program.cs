using System.Data;
using System.Xml.Linq;

namespace 链表的中间结点
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

            ListNode fast = head;
            ListNode slow = head;
            
            while(fast != null || fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            Console.WriteLine(slow.val);

        }
    }
}