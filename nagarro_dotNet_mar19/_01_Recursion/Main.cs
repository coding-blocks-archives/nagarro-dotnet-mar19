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
                //int[] bsArr = { 1, 2, 4, 7, 9 };
                //int idx = BinarySearch(bsArr, 0, 4, 3);
                //Console.WriteLine(idx);
                #endregion

                #region MergeSort
                //int[] msArr = { 5, 50, 1, 3, 87 };
                //MergeSort(msArr, 0, msArr.Length - 1);
                //PrintArr(msArr, msArr.Length);
                #endregion

                ChessMove.main();

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
                    utils.Utils.Swap(ref arr[beginIdx], ref arr[nextIdx]);
                    BubbleSort(arr, nextIdx, endIdx);
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

            public static void MergeSort(int[] arr, int beIdx, int endIdx)
            {
                if (endIdx <= beIdx) return;

                int mid = (beIdx + endIdx) / 2;
                MergeSort(arr, beIdx, mid);     // left sort...[be,mid]
                MergeSort(arr, mid + 1, endIdx);    // right sort...(mid + 1, end]
                MergeSortedArrays(arr, beIdx, endIdx, mid);
            }

            public static void MergeSortedArrays(int[] arr, int beIdx, int endIdx, int mid)
            {
                int nelements = (endIdx - beIdx + 1);
                int[] tmp = new int[nelements];

                int idx = 0;
                int leftIdx = beIdx;
                int rightIdx = mid + 1;

                while (leftIdx <= mid && rightIdx <= endIdx)
                {
                    if (arr[leftIdx] < arr[rightIdx])
                    {
                        tmp[idx] = arr[leftIdx];
                        idx++; leftIdx++;
                    }
                    else
                    {
                        tmp[idx++] = arr[rightIdx++];
                    }
                }
                
                // copy remaining elements from left
                while (leftIdx <= mid)
                {
                    tmp[idx++] = arr[leftIdx++];
                }

                // copy remaining elements from right
                while (rightIdx <= endIdx)
                {
                    tmp[idx++] = arr[rightIdx++];
                }

                // copy the tmp arr to original arr
                idx = 0;
                while(beIdx <= endIdx)
                {
                    arr[beIdx++] = tmp[idx++];
                }
            }


        }
    }
}
