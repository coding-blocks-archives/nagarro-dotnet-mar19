using System;
using System.Collections.Generic;
using System.Text;

namespace nagarro_dotNet_mar19
{
    namespace dynamicprogramming
    {
        class knapsack
        {
            public static void main()
            {
                int capacity = 10;
                int[] val = { 160, 90, 80};
                int[] wt = { 10, 5, 4};
                //int ans = calcProfit(val, wt, capacity, 0);
                int ans = maxProfitDP(val, wt, capacity);
                Console.WriteLine(ans);
            }

            public static int calcProfit(int[] val, int[] wt, int capacity, int startIdx)
            {
                if (startIdx == val.Length)
                {
                    return 0;
                }

                int profitWhenPicked = 0;
                int profitWhenLeft = 0;

                if (wt[startIdx] <= capacity)
                {

                    profitWhenPicked = val[startIdx] + 
                        calcProfit(val, wt, capacity - wt[startIdx], startIdx + 1);
                }

                profitWhenLeft = calcProfit(val, wt, capacity, startIdx + 1);

                return Math.Max(profitWhenLeft, profitWhenPicked);
            }

            public static int maxProfitDP(int[] value, int[] wt, int threshold)
            {
                int[,] profitMat = new int[wt.Length + 1, threshold + 1];
                int nItems = wt.Length;

                for(int item = 1; item <= nItems; ++item)
                {
                    for(int capacity = 1; capacity <= threshold; ++capacity)
                    {
                        int pickProfit = 0;
                        int leftProfit = 0;
                        if (capacity >= wt[item - 1])
                        {
                            pickProfit = value[item - 1] + 
                                         profitMat[item - 1, capacity - wt[item -1]];
                        }

                        leftProfit = profitMat[item - 1, capacity];

                        profitMat[item, capacity] = Math.Max(pickProfit, leftProfit);
                    }
                }
                return profitMat[nItems, threshold];
            }

        }
    }
}
