using System;
using System.Collections.Generic;
using System.Text;

namespace nagarro_dotNet_mar19
{
    namespace dynamicprogramming
    {
        class Questions
        {
            public static int fibonnaciRec(int n)
            {
                if (n <= 0) return 0;
                if (n == 1) return 1;
                int prev = fibonnaciRec(n - 1);
                int superPrev = fibonnaciRec(n - 2);
                return prev + superPrev;
            }


            public static void main()
            {
                int ans = fibonnaciRec(45);
                Console.WriteLine($"{ans}");
            }
        }
    }
}
