using System;
using System.Collections.Generic;
using System.Text;

namespace nagarro_dotNet_mar19.dynamicprogramming
{
    class MatrixChainMultiplication
    {
        public static KeyValuePair<int, int> readPair()
        {
            var inp = Console.ReadLine().Split(' ');
            return new KeyValuePair<int, int>(int.Parse(inp[0]),
                                              int.Parse(inp[1]));
        }

        public static int readInt()
        {
            return int.Parse(Console.ReadLine());
        }


        public static int minOperations(KeyValuePair<int, int>[] matrices, int startIdx, int endIdx)
        {
            if (startIdx == endIdx) return 0;

            int bestAns = int.MaxValue;

            for (int curIdx = startIdx; curIdx < endIdx; ++curIdx)
            {
                int leftOperations = minOperations(matrices, startIdx, curIdx);
                int rightOperations = minOperations(matrices, curIdx + 1, endIdx);

                int curOperations = matrices[startIdx].Key * matrices[curIdx].Value *
                                    matrices[endIdx].Value;

                int totalOperations = curOperations + leftOperations + rightOperations;
                bestAns = Math.Min(totalOperations, bestAns);
            }

            return bestAns;
        }


        public static int minOperations(KeyValuePair<int, int>[] matrices)
        {
            int totalMat = matrices.Length;
            int[,] operations = new int[totalMat, totalMat];

            // len 1 is already filled with 0
            for (int nMat = 2; nMat <= totalMat; ++nMat)
            {
                for (int startMat = 0; startMat <= totalMat - nMat; ++startMat)
                {
                    int endMat = startMat + nMat - 1;
                    int ans = int.MaxValue;

                    for (int matInLeft = startMat; matInLeft < endMat; ++matInLeft)
                    {
                        int curOperations = 
                            operations[startMat, matInLeft] +
                            operations[matInLeft + 1, endMat] +
                            matrices[startMat].Key * matrices[matInLeft].Value * matrices[endMat].Value;

                        ans = Math.Min(curOperations, ans);
                    }
                    operations[startMat, endMat] = ans;
                }
            }

            return operations[0, totalMat - 1];
        }


        public static void main()
        {
            int nDim = readInt();
            KeyValuePair<int, int>[] matrices = new KeyValuePair<int, int>[nDim];

            for (int i = 0; i < nDim; ++i)
            {
                matrices[i] = readPair();
            }

            //int minAns = minOperations(matrices, 0, nDim - 1);
            int minAns = minOperations(matrices);
            Console.WriteLine(minAns);
        }

    }
}
