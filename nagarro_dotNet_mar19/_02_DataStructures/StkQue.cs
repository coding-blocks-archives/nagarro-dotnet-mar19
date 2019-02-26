using System;
using System.Collections.Generic;
using utils;

namespace nagarro_dotNet_mar19
{
    namespace datastructures
    {
        public class StkQue
        {
            public static void main()
            {
                Stack<int> s = new Stack<int>();
                Queue<int> q = new Queue<int>();
                LinkedList<int> l = new LinkedList<int>();
                List<int> ls = new List<int>();

                int n = int.Parse(Console.ReadLine());
                int[] arr = utils.Utils.InpArr(n);
                var result = NextLargestRight(arr);
                Utils.PrintList(result);

            }

            public static LinkedList<int> NextLargestRight(int[] arr)
            {
                Stack<int> stk = new Stack<int>();
                LinkedList<int> result = new LinkedList<int>();

                for (int i = arr.Length - 1; i >= 0; --i)
                {
                    int curElement = arr[i];
                    while(stk.Count != 0 && stk.Peek() <= curElement)
                    {
                        // top contains something that cannot be used
                        stk.Pop();
                    }

                    int ans = stk.Count == 0 ? -1 : stk.Peek();
                    result.AddFirst(ans);

                    stk.Push(curElement);
                }

                return result;
            }
        }
    }
}
