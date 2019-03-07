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
            public TreeNode next;

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
                ConnectLevels(root);
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

                    Console.Write($"{cur.data}({(cur.next != null?cur.next.data : 0 )}),");
                    if (cur.left != null)  q.Enqueue(cur.left);
                    if (cur.right != null) q.Enqueue(cur.right);
                }
            }

            public static void ConnectLevels(TreeNode root)
            {
                Queue<TreeNode> curLevelQ = new Queue<TreeNode>();
                TreeNode END_OF_LEVEL = null;

                curLevelQ.Enqueue(root);
                curLevelQ.Enqueue(END_OF_LEVEL);

                while(curLevelQ.Count != 0)
                {
                    TreeNode curNode = curLevelQ.Dequeue();
                    if (curNode == END_OF_LEVEL)
                    {
                        if (curLevelQ.Count != 0)
                        {
                            curLevelQ.Enqueue(END_OF_LEVEL);
                        }
                        continue;
                    }
                    curNode.next = curLevelQ.Peek();
                    if (curNode.left != null) curLevelQ.Enqueue(curNode.left);
                    if (curNode.right != null) curLevelQ.Enqueue(curNode.right);
                }
            }

            public static void ConnectLevels2(TreeNode root)
            {
                while (root != null)
                {
                    TreeNode cur = root;
                    TreeNode child = null;
                    while (cur != null)
                    {
                        if (cur.left != null)
                        {
                            if (child != null)
                            {
                                child.next = cur.left;
                                child = child.next;
                            }
                            else
                            {
                                root = cur.left;
                                child = root;
                            }
                        }

                        if (cur.right != null)
                        {
                            if (child != null)
                            {
                                child.next = cur.right;
                                child = child.next;
                            }
                            else
                            {
                                root = cur.left;
                                child = root;
                            }
                        }
                        cur = cur.next;
                    }
                }

        }
    }
}
