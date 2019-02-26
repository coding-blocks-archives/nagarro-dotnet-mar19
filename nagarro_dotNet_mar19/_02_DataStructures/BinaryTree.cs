using System;
using System.Collections.Generic;
using System.Text;

namespace nagarro_dotNet_mar19
{
    namespace datastructures
    {
        public class TreeNode
        {
            public int data;
            public TreeNode left;
            public TreeNode right;

            public TreeNode()
            {
            }

            public TreeNode(int _data)
            {
                data = _data;
            }
        }

        public class BinaryTreeFunctionalities
        {
            public static void main()
            {
                TreeNode root = createTree();
                //PrintTree(root);
                PrintTreeLevelWise(root);
            }

            public static TreeNode createTree()
            {
                int x = int.Parse(Console.ReadLine());

                if (x == -1) return null;

                TreeNode root = new TreeNode(x);
                Console.Write($"Left Child of {x}: ");
                root.left = createTree();
                Console.Write($"Rght Child of {x}: ");
                root.right = createTree();

                return root;
            }

            public static void PrintTree(TreeNode root)
            {
                if (root == null) return;

                PrintTree(root.left);
                Console.Write($"{root.data}, ");
                PrintTree(root.right);
            }

            public static void PrintTreeLevelWise(TreeNode root)
            {
                if (root == null) return;

                Queue<TreeNode> q = new Queue<TreeNode>();
                TreeNode MARKER = null;

                q.Enqueue(root);
                q.Enqueue(MARKER);

                while (q.Count != 0)
                {
                    TreeNode cur = q.Dequeue();
                    if (cur == MARKER)
                    {
                        Console.WriteLine();
                        if (q.Count != 0) q.Enqueue(MARKER);
                        continue;
                    }

                    Console.Write($"{cur.data}, ");
                    if (cur.left != null)  q.Enqueue(cur.left);
                    if (cur.right != null) q.Enqueue(cur.right);
                }
            }

        }
    }
}
