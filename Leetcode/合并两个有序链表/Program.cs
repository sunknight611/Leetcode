namespace 合并两个有序链表
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListNode list12 = new ListNode(4, null);
            ListNode list11 = new ListNode(2, list12);
            ListNode list1 = new ListNode(1,list11);
            
            ListNode list22 = new ListNode(4,null);
            ListNode list21 = new ListNode(3,list22);
            ListNode list2 = new ListNode(1, list21);

            Console.WriteLine(Solution.MergeTwoLists(list1,list2));
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
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode head = null;
            if (list1 == null) return list2;
            if (list2 == null) return list1;
            if (list1 == null && list2 == null) return null;
            //ListNode head = list1.val < list2.val ? list1 : list2;
            if (list1.val < list2.val)
            {
                head = new ListNode(list1.val,null);
                list1 = list1.next;
            }
            else
            {
                head = new ListNode(list2.val, null);
                list2 = list2.next;
            }
            ListNode cur = head;         
            while(list1 != null || list2 != null)
            {
                if (list1 == null)
                {
                    cur.next = list2;
                    break;
                }

                if(list2 == null)
                {
                    cur.next = list1;
                    break;  
                }

                if(list1.val <= list2.val)
                {
                    cur.next = list1;
                    list1 = list1.next;
                    cur = cur.next;
                }
                else
                {
                    cur.next = list2;
                    list2 = list2.next;
                    cur = cur.next;
                }
            }
            return head;
        }
    }
}