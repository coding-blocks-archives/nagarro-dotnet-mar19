using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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

                int n = int.Parse(Console.ReadLine());
                int[] arr = utils.Utils.InpArr(n);
                var result = NextLargestRight(arr);
                Utils.PrintList(result);
            }

            public static LinkedList<int> NextLargestRight(int[] arr)
            {
                return null;
            }



        }
    }
}
