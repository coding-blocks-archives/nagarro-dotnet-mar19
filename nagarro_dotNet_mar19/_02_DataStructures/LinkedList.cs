using System;
using System.Collections.Generic;
using System.Text;

namespace nagarro_dotNet_mar19.datastructures
{
    class LinkedListFunctionalities
    {
        public static void main()
        {
            Node head = createLL();
            printLL(head);
            Console.ReadLine();
        }

        public class Node
        {
            public int data;
            public Node next;

            public Node()
            {
                data = 0;
                next = null;
            }

            public Node(int _data)
            {
                data = _data;
                next = null;
            }
        }

        public static Node createLL()
        {
            Node head = null;
            while (true)
            {
                int x = int.Parse(Console.ReadLine());
                if (x == -1) break;
                head = insertIntoLL(head, x);
            }
            return head;
        }

        public static Node insertIntoLL(Node head, int data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node tail = getTail(head);
                tail.next = newNode;
            }
            return head;
        }

        public static Node getTail(Node head)
        {
            Node cur = head;
            while(cur != null && cur.next != null)
            {
                cur = cur.next;
            }
            return cur;
        }

        public static void printLL(Node head)
        {
            Node cur = head;
            while (cur != null)
            {
                Console.Write($"{cur.data}-->");
                cur = cur.next;
            }
            Console.WriteLine();
        }

        public static Node reverseLL(Node head)
        {

        }

        public static Node add2LL(Node number1, Node number2)
        {

        }

        public static Node mergeSort(Node head)
        {
        
        }

        public static Node middleNode(Node head)
        {

        }

        public static Node mergeSortedList(Node list1, Node list2)
        { }
        

    }
}
