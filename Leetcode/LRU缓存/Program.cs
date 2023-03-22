using System.Runtime.ConstrainedExecution;

namespace LRU缓存
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LRUCache lRUCache = new LRUCache(2);
            lRUCache.Put(2, 1); // 缓存是 {1=1}
            lRUCache.Put(2, 2); // 缓存是 {1=1, 2=2}
            Console.WriteLine(lRUCache.Get(2));    // 返回 1
            lRUCache.Put(1, 1); // 该操作会使得关键字 2 作废，缓存是 {1=1, 3=3}
            //Console.WriteLine(lRUCache.Get(2));    // 返回 -1 (未找到)
            lRUCache.Put(4, 1); // 该操作会使得关键字 1 作废，缓存是 {4=4, 3=3}
            Console.WriteLine(lRUCache.Get(2));    // 返回 -1 (未找到)
            //Console.WriteLine(lRUCache.Get(3));    // 返回 3
            //Console.WriteLine(lRUCache.Get(4));    // 返回 4
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode pre;
        public int key;
        public ListNode(int key = 0, int val = 0, ListNode next = null, ListNode pre = null)
        {
            this.key = key;
            this.val = val;
            this.next = next;
            this.pre = pre;
        }
    }

    public class LRUCache
    {
        int capacity;
        int curCapacity;
        Dictionary<int, ListNode> lookup;
        ListNode head;
        ListNode rear;
        public LRUCache(int capacity)
        {
            head = new ListNode();
            rear = head;
            this.capacity = capacity;
            lookup = new Dictionary<int, ListNode>();
            curCapacity = 0;
        }

        public int Get(int key)
        {
            if (lookup.ContainsKey(key))
            {
                ListNode cur = lookup[key];
                if (cur != rear)
                {
                    ListNode temp = lookup[key].pre;
                    temp.next = lookup[key].next;
                    lookup[key].next.pre = temp;

                    rear.next = lookup[key];
                    //head.pre = lookup[key];
                    lookup[key].pre = rear;
                    lookup[key].next = null;
                    //lookup[key].next = head;
                    rear = rear.next;
                }
                return lookup[key].val;
            }
                
            else return -1;
        }

        public void Put(int key, int value)
           {
            if (lookup.ContainsKey(key))
            {
                //如果缓存中已经存在该key，则变更其数据,并且将该数据的链表节点放置到最后，因为它刚访问过
                lookup[key].val = value;
                if (head == rear)
                {
                    head.next = lookup[key];
                    lookup[key].pre = head;
                    rear = lookup[key];
                }else if (lookup[key] == rear)//若当前节点已经为最后rear
                {
                    return;
                }
                else
                {
                    //将当前节点移到链表的最后
                    ListNode temp = lookup[key].pre;
                    temp.next = lookup[key].next;
                    lookup[key].next.pre = temp;

                    rear.next = lookup[key];
                    //head.pre = lookup[key];
                    lookup[key].pre = rear;
                    lookup[key].next = null;
                    //lookup[key].next = head;
                    rear = rear.next;
                }
            }
            else
            {//缓存中不存在key，则加入该key，val对，并在字典中记录
                curCapacity++;
                ListNode cur = new ListNode(key, value);
                //如果当前容量不超，则直接加入尾部
                if (curCapacity <= capacity)
                {
                    rear.next = cur;
                    //head.pre = cur;
                    cur.pre = rear;
                    //cur.next = head;
                    rear = rear.next;
                    //将该节点存入字典
                    lookup.Add(key, cur);
                }
                else
                {
                    //将rear移除，将新节点插入
                    lookup.Remove(head.next.key);

                    //插入新节点
                    rear.next = cur;
                    //head.pre = cur;
                    cur.pre = rear;
                    //cur.next = head;
                    rear = rear.next;
                    //删除最久没使用的结点
                    ListNode temp = head.next.next;
                    head.next = temp;
                    temp.pre = head;
                    //将该节点存入字典
                    lookup.Add(key, cur);                  
                }
            }
        }
    }
}