using System.Linq.Expressions;

namespace 从前序序列和中序序列构造二叉树
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(3);
            TreeNode node1 = new TreeNode(9);
            TreeNode node2 = new TreeNode(20);
            TreeNode node3 = new TreeNode(15);
            TreeNode node4 = new TreeNode(7);
            root.left = node1;
            root.right = node2;
            node2.left = node3;
            node2.right = node4;
            var s = new Solution();
            s.BuildTree(new int[] { 3, 9, 20, 15, 7 }, new int[] { 9, 3, 15, 20, 7 });
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
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            TreeNode root = Build(preorder, inorder, 0, inorder.Length, 0);
            return root;
        }

        public TreeNode Build(int[] preorder, int[] inorder, int l, int r, int cur)
        {
            if (l > r) return null;
            if (l == r) return new TreeNode(preorder[cur]);
            TreeNode root = new TreeNode(preorder[cur]);
            int i = l;
            //找到根节点在中序遍历中位置，左边为左子树，右边为右子树
            for (i = l; i < r; i++)
            {
                if (inorder[i] == preorder[cur])
                    break;
            }

            root.left = Build(preorder, inorder, 0, i - 1, cur+1);
            root.right = Build(preorder, inorder, i + 1, r, cur+2);

            return root;
        }
    }
}