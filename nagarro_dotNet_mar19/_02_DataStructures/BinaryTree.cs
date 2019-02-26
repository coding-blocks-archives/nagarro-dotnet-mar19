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
                PrintTree(root);
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

        }
    }
}
