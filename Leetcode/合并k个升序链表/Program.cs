namespace 合并k个升序链表
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListNode list12 = new ListNode(4, null);
            ListNode list11 = new ListNode(2, list12);
            ListNode list1 = new ListNode(1, list11);

            ListNode list22 = new ListNode(4, null);
            ListNode list21 = new ListNode(3, list22);
            ListNode list2 = new ListNode(1, list21);

            //Solution.MergeTwoLists(list1, list2);
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
        public static ListNode MergeTwoLists(ListNode list1,ListNode list2)
        {
            ListNode head;
            if (list1.val <= list2.val)
            {
                head = list1;
                list1 = list1.next;
            }
            else
            {
                head = list2;
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

                if (list2 == null)
                {
                    cur.next = list1;
                    break;
                }

                if(list1.val <= list2.val)
                {
                    cur.next = list1;
                    list1 = list1.next;                   
                }
                else
                {
                    cur.next = list2;
                    list2 = list2.next;
                }
                cur = cur.next;
            }
            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }
            return head;
        }

        public static ListNode Merge(ListNode[] list,int l,int r)
        {
            if (l == r) return list[l];
            else if (l > r) return null;

            int mid = (r + l) / 2;
            return MergeTwoLists(Merge(list,l,mid),Merge(list,mid+1,r));                    
        }
        public static ListNode MergeKLists(ListNode[] lists)
        {
            return Merge(lists,0,lists.Length - 1);
        }
    }
}