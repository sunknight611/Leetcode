namespace 最小栈
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            minStack.GetMin();
            minStack.Pop();
            minStack.Top();
            minStack.GetMin();
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

    public class MinStack
    {
        Stack<int> stack;
        ListNode head;
        public MinStack()
        {
            stack = new Stack<int>();
            head = new ListNode(int.MinValue);
        }

        public void Push(int val)
        {
            stack.Push(val);
            //创建节点添加到链表中
            ListNode cur = new ListNode(val);
            //如果链表为空，则直接添加到头结点后面
            if (head.next == null)
                head.next = cur;
            else
            {
                //链表不为空则找插入位置
                ListNode temp = head;
                while (temp.next != null)
                {
                    if (temp.val <= val && temp.next.val > val) break;
                    temp = temp.next;
                }
                //如果找到的结点不是最后一个节点
                if (temp.next != null)
                {
                    ListNode next = temp.next;
                    temp.next = cur;
                    cur.next = next;
                }
                else
                {
                    temp.next = cur;
                }
            }       
        }

        public void Pop()
        {
            int top = stack.Peek();
            stack.Pop();
            //从链表移除节点
            ListNode fast = head.next;
            ListNode slow = head;
            while (fast != null && fast.val != top)
            {
                fast = fast.next;
                slow = slow.next;
            }

            slow.next = fast.next;
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return head.next.val;
        }
    }

}