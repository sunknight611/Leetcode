namespace _102.二叉树的层次遍历
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            TreeNode node1 = new TreeNode(2);
            TreeNode node2 = new TreeNode(3);
            TreeNode node3 = new TreeNode(4);
            TreeNode node4 = new TreeNode(5);
            root.left = node1;
            node1.left = node2;
            node2.left = node3;
            node3.left = node4;
            var s = new Solution();
            s.LevelOrder(root);
        }
    }

    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
         }
    }
    public class Solution
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            IList<int> layer = new List<int>();
            if (root == null) return ans;

            //Judge(ans,root);
            bfs(root, ans);
            return ans;
        }

        // public void Judge(IList<IList<int>> ans,TreeNode root){
        //     //cur存储当前层遍历的结点
        //     List<TreeNode> cur = new List<TreeNode>();

        //     cur.Add(root);
        //     ans.Add(new List<int>(){root.val});

        //     while(cur.Count > 0){
        //         List<int> tempValue = new List<int>();
        //         //next存储下一层的结点
        //         List<TreeNode> next = new List<TreeNode>();
        //         for(int i = 0;i < cur.Count;i++){
        //             if(cur[i].left != null){
        //                 next.Add(cur[i].left);
        //                 tempValue.Add(cur[i].left.val);
        //             }                   
        //             if(cur[i].right != null){
        //                 next.Add(cur[i].right);
        //                 tempValue.Add(cur[i].right.val);
        //             }                   
        //         }
        //         cur = next;
        //         if(tempValue.Count != 0)
        //             ans.Add(tempValue);
        //     }
        // }

        public void bfs(TreeNode root, IList<IList<int>> ans)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                List<int> layer = new List<int>();
                int length = queue.Count;
                for (int i = 0; i < length; i++)
                {
                    TreeNode rootTemp = queue.Dequeue();
                    layer.Add(rootTemp.val);
                    if (rootTemp.left != null)
                    {
                        queue.Enqueue(rootTemp.left);
                    }

                    if (rootTemp.right != null)
                    {
                        queue.Enqueue(rootTemp.right);
                    }
                }
                if (layer.Count != 0)
                    ans.Add(layer);
            }
        }
    }
}