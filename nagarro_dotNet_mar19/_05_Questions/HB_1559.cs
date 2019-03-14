using System;
using System.Collections.Generic;
using System.Text;

namespace nagarro_dotNet_mar19
{
    namespace Questions
    {
        class HB_1559
        {
            public static string read()
            {
                return Console.ReadLine();
            }

            public static void main()
            {
                string inp = "";

                try
                {
                    inp = read();
                    int nCases = int.Parse(inp);
                    for (int i = 0; i < nCases; ++i)
                    {
                        inp = read();
                        int nElements = int.Parse(inp);
                        List<int> arr = new List<int>(nElements);

                        inp = read();
                        var inpArr = inp.Split(' ');

                        for (int cur = 0; cur < nElements; ++cur)
                        {
                            arr.Add(int.Parse(inpArr[cur]));
                        }

                        arr.Sort();
                        inp = read();
                        var queries = int.Parse(inp);
                        for (int curQ = 0; curQ < queries; ++curQ)
                        {
                            inp = read();
                            bool isPresent = arr.BinarySearch(int.Parse(inp)) >= 0;

                            if (isPresent) Console.WriteLine("Yes");
                            else Console.WriteLine("No");
                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(inp);
                    //throw;
                }

            }
        }
    }
}
