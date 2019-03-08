using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nagarro_dotNet_mar19
{
    namespace dynamicprogramming
    {
        class Questions
        {
            static int[] fibArr;
            static int[] jumparr;

            public static int fibonnaciRec(int n)
            {
                if (n <= 0) return 0;
                if (n == 1) return 1;
                if (fibArr[n] != 0) return fibArr[n];

                int prev = fibonnaciRec(n - 1);
                int superPrev = fibonnaciRec(n - 2);

                fibArr[n] = prev + superPrev;
                return fibArr[n];
            }

            public static int fibonnaciDP(int n)
            {
                int[] fibArr = new int[n+ 1];
                fibArr[0] = 0;
                fibArr[1] = 1;
                for (int i = 2; i <= n; ++i)
                {
                    fibArr[i] = fibArr[i - 1] + fibArr[i - 2];
                }
                return fibArr[n];

            }

            public static int nJumpsRec(int[] potential, int startIdx)
            {
                if (startIdx == potential.Length) return 0;
                if (jumparr[startIdx] != -1) return jumparr[startIdx];

                int minJumps = (int)1e9;

                int curPotential = potential[startIdx];
                for(int jumpLen = 1; jumpLen <= curPotential; ++jumpLen)
                {
                    int landingIdx = jumpLen + startIdx;
                    if (landingIdx > potential.Length) break;
                    int jumpsReq = nJumpsRec(potential, landingIdx) + 1;
                    minJumps = jumpsReq < minJumps ? jumpsReq : minJumps;
                }

                return jumparr[startIdx] = minJumps;
            }

            public static int nJumpsDP(int[] potential)
            {
                // this array represents the MIN number of jumps required to reach at ith box
                // from the START
                int[] jumparr = Enumerable.Repeat(potential.Length, (int)1e9).ToArray();

                //int[] jumparr = new int[potential.Length];
                //for (int i = 0; i < potential.Length; ++i) jumparr[i] = (int)1e9;

                jumparr[0] = 0;

                for(int i = 0; i < potential.Length; ++i)
                {
                    int maxPotential = potential[i];
                    for(int jumpLen = 1; jumpLen < maxPotential; ++jumpLen)
                    {
                        int landingIdx = jumpLen + i;
                        if (landingIdx >= potential.Length) break;
                        jumparr[landingIdx] = Math.Min(jumparr[landingIdx], jumparr[i] + 1); 
                    }
                }
                return jumparr[potential.Length - 1];

            }

            public static int longesetCommonSubstr(string wordA, string wordB)
            {
                int[,] lcsAtB = new int[wordA.Length + 1, wordB.Length + 1];
                int maxLcs = 0;

                for(int row = 1; row <= wordA.Length; ++row)
                {
                    for(int col = 1; col <= wordB.Length; ++col)
                    {
                        if (wordA[row - 1] == wordB[col - 1])
                        {
                            lcsAtB[row, col] = 1 + lcsAtB[row - 1, col - 1];
                            maxLcs = Math.Max(maxLcs, lcsAtB[row, col]);
                        }
                    }
                }
                return maxLcs;
            }


            public static void main()
            {
                //int n = 35;
                //fibArr = new int[n + 1];
                //int ans = fibonnaciRec(n);
                //int ans = fibonnaciDP(n);
                //Console.WriteLine($"{ans}");

                //int[] potential = { 1, 3, 5, 0, 4, 2, 6, 0, 6, 8, 9};
                //int[] potential = { 3, 6, 7, 1, 6, 3, 5, 8, 3 };
                //jumparr = new int[potential.Length];
                //for (int i = 0; i < jumparr.Length; ++i)
                //{
                //    jumparr[i] = -1;
                //}
                //int ans = nJumpsRec(potential, 0);

                //int[] potential = { 3, 6, 7, 1, 6, 3, 5, 8, 3 };
                //int ans = nJumpsDP(potential);
                //Console.WriteLine($"{ans}");

                //string wordA = "abfdef";
                //string wordB = "bfcdef";
                string wordA = "zxabczycde";
                string wordB = "abc";
                int ans = longesetCommonSubstr(wordA, wordB);
                Console.WriteLine($"{ans}");
            }
        }
    }
}
