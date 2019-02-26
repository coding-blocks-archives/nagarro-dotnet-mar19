using System;
using System.Collections.Generic;
using System.Text;

namespace utils
{
    public class Utils
    {
        public static void PrintArr(int[] arr, int elementsToPrint)
        {
            for (int i = 0; i < elementsToPrint; ++i)
            {
                Console.Write($"{arr[i]} ");
            }

        }

        public static void Swap(ref int element1, ref int element2)
        {
            int tmp = element1;
            element1 = element2;
            element2 = tmp;
        }

        public static int[] InpArr(int nelements)
        {
            int[] arr = new int[nelements];
            for (int i = 0; i < nelements; ++i)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            return arr;
        }

        public static void PrintList(LinkedList<int> list)
        {
            foreach(int x in list)
            {
                Console.Write($"{x}, ");
            }

        }
    }
}
