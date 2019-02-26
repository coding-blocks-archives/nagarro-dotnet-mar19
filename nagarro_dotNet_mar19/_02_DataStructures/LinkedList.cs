using System;
using System.Collections.Generic;
using System.Text;

namespace nagarro_dotNet_mar19.datastructures
{
    class LinkedListFunctionalities
    {
        public static void main()
        {
            //Node head = createLL();
            //printLL(head);

            //head = reverseLLIter(head);
            //printLL(head);

            #region add Numbers
            Node num1 = createLL();
            Node num2 = createLL();
            Node result = add2LL(num1, num2);
            printLL(num1);
            printLL(num2);
            printLL(result);
            #endregion

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
            if (head == null) return head;
            if (head.next == null) return head;

            Node smallRevHead = reverseLL(head.next);
            head.next.next = head;
            head.next = null;
            return smallRevHead;
        }

        public static Node reverseLLIter(Node head)
        {
            Node prev = null;
            Node cur = head;
            while (cur != null)
            {
                Node next = cur.next;
                cur.next = prev;
                prev = cur;

                cur = next;
            }
            return prev;
        }

        public static Node add2LL(Node number1, Node number2)
        {

            var rNumber1 = reverseLL(number1);
            var rNumber2 = reverseLL(number2);

            Node ansHead = null;
            Node ansTail = null;

            Node cur1 = rNumber1;
            Node cur2 = rNumber2; ;

            int carry = 0;
            while(cur1 != null || cur2 != null)
            {
                int sum = carry;
                sum += cur1 != null ? cur1.data : 0;
                sum += cur2 != null ? cur2.data : 0;

                int digit = sum % 10;
                carry = sum /  10;

                Node newNode = new Node(digit);
                if (ansHead == null)
                {
                    ansHead = ansTail = newNode;
                }
                else
                {
                    ansTail.next = newNode;
                    ansTail = ansTail.next;
                }

                if (cur1 != null) cur1 = cur1.next;
                if (cur2 != null) cur2 = cur2.next;
            }
            
            if (carry != 0)
            {
                Node newNode = new Node(carry);
                ansTail.next = newNode;
            }

            reverseLL(rNumber1);
            reverseLL(rNumber2);
            return reverseLL(ansHead);
        }

        public static Node mergeSort(Node head)
        {
            return null;
        }

        public static Node middleNode(Node head)
        {
            return null;

        }

        public static Node mergeSortedList(Node list1, Node list2)
        {
            return null;

        }


    }
}
