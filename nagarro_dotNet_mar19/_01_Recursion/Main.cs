using System;
using System.Collections.Generic;
using System.Text;

namespace nagarro_dotNet_mar19
{
    namespace recursion
    {
        public class Program
        {
            public static void main()
            {
                #region Factorial
                //String inpLine = Console.ReadLine();
                //int n = int.Parse(inpLine);
                //int nFact = Factorial(n);
                //Console.WriteLine(nFact);
                #endregion

                #region BubbleSort
                //int[] arr = new int[100];
                //int nelements = int.Parse(Console.ReadLine());
                //for (int i = 0; i < nelements; ++i)
                //{
                //    arr[i] = int.Parse(Console.ReadLine());
                //}
                //BubbleSort(arr, 0, nelements - 1);
                //PrintArr(arr, nelements);
                #endregion

                #region BinarySearch
                int[] bsArr = { 1, 2, 4, 7, 9 };
                int idx = BinarySearch(bsArr, 0, 4, 3);
                Console.WriteLine(idx);
                #endregion

                Console.ReadLine();
            }

            public static int Factorial(int n)
            {
                if (n <= 0) return 1;

                int smallFact = Factorial(n - 1);
                int nFact = n * smallFact;
                return nFact;
            }

            public static void BubbleSort(int[] arr, int beginIdx, int endIdx)
            {
                if (endIdx - beginIdx == 0) return;

                int nextIdx = beginIdx + 1;
                BubbleSort(arr, nextIdx, endIdx);
                if (arr[beginIdx] > arr[nextIdx])
                {
                    Swap(ref arr[beginIdx], ref arr[nextIdx]);
                    BubbleSort(arr, nextIdx, endIdx);
                }
            }

            public static void Swap(ref int element1, ref int element2)
            {
                int tmp = element1;
                element1 = element2;
                element2 = tmp;
            }

            public static void PrintArr(int[] arr, int elementsToPrint)
            {
                for (int i = 0; i < elementsToPrint; ++i)
                {
                    Console.Write($"{arr[i]} ");
                }

            }

            public static int BinarySearch(int[] arr, int elementToSearch)
            {
                return BinarySearch(arr, 0, arr.Length - 1, elementToSearch);
            }

            private static int BinarySearch(int[] arr, int beginIdx, int endIndx, int elementToSearch)
            {
                if (beginIdx > endIndx) return -1;

                int mid = (beginIdx + endIndx) / 2;
                if (arr[mid] > elementToSearch)
                {
                    return BinarySearch(arr, beginIdx, mid - 1, elementToSearch);
                }
                else if (arr[mid] < elementToSearch)
                {
                    return BinarySearch(arr, mid + 1, endIndx, elementToSearch);
                }
                else
                {
                    return mid;
                }
            }
        }
    }
}
