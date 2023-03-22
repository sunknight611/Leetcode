namespace 二叉树中的最大路径和
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val,TreeNode left = null,TreeNode right = null) { 
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        public int MaxPathSum(TreeNode root)
        {
            int val = int.MinValue;
            dfs(root, ref val);
            return val;
        }

        //一条路径有三种可能，当前节点加上左孩子并向上，当前节点加上右孩子并向上，当前节点加上左孩子和右孩子
        //val记录全局最大和
        public int dfs(TreeNode root, ref int val)
        {
            //递归出口，访问到空节点
            if (root == null) return 0;
            //递归获得左节点的最大和,若小于0，则说明需要舍弃左节点，我们将它置为0
            int left = Math.Max(0, dfs(root.left,ref val));
            //右节点同理
            int right = Math.Max(0, dfs(root.right,ref val));
            //当前节点加上左孩子和右孩子的值
            int lmr = left + root.val + right;
         //选取三种可能中的最大值
            int ret = Math.Max(lmr, Math.Max(left, right));
            //如果当前节点的最大路径和小于0，我们则舍弃，将它置为0；
            val = Math.Max(val, Math.Max(0, ret));
            return ret;
        }
    }
}