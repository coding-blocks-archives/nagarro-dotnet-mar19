using System;
using System.Collections.Generic;
using System.Text;

namespace nagarro_dotNet_mar19.Questions
{
    using System;
    using System.Linq;

    public class Test
    {
        public static void main()
        {
            string inp = "";
            try
            {
                inp = Console.ReadLine();
                int nTest = int.Parse(inp);

                for (int curTest = 1; curTest <= nTest; ++curTest)
                {
                    var inpStr = Console.ReadLine().Split(' ');
                    int nBooks = int.Parse(inpStr[0]);
                    int nStudents = int.Parse(inpStr[1]);
                    // Console.WriteLine(nBooks);
                    //Console.WriteLine(nStudents);
                    int[] pages = new int[nBooks];

                    var inpPages = Console.ReadLine().Split(' ');
                    for (int i = 0; i < nBooks; ++i)
                    {
                        pages[i] = int.Parse(inpPages[i]);
                        //Console.Write($"{pages[i]} ");
                    }
                    // Console.WriteLine();
                    int bestPages = MinPages(pages, nStudents);
                    Console.WriteLine(bestPages);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(inp);
                throw;
            }
        }


        public static int MinPages(int[] pages, int nStudents)
        {
            int minPages = 0;
            int maxPages = pages.Sum();

            int bestAns = maxPages;

            while (minPages <= maxPages)
            {
                int guess = (minPages + maxPages) / 2;
                bool success = Simulate(pages, nStudents, guess);
                if (success)
                {
                    bestAns = guess;
                    maxPages = guess - 1;

                }
                else
                {
                    minPages = guess + 1;
                }
            }
            return bestAns;
        }

        public static bool Simulate(int[] books, int nStudents, int thresholdForPages)
        {
            int pagesRead = 0;
            int studentsUsed = 1;

            foreach (int nPages in books)
            {
                if (nPages > thresholdForPages) return false;

                if (pagesRead + nPages <= thresholdForPages)
                {
                    pagesRead += nPages;
                }
                else
                {
                    ++studentsUsed;
                    pagesRead = nPages;
                }
                if (studentsUsed > nStudents) return false;
            }
            return true;
        }
    }
}
