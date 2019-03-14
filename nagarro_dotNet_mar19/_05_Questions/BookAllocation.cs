using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace nagarro_dotNet_mar19
{
    namespace Questions
    {
        class BookAllocation
        {
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



            public static void main()
            {
                int nStudents = 1;
                int[] pages = { 2, 5, 7, 1, 4, 3, 8 };

                int bestPages = MinPages(pages, nStudents);

                Console.WriteLine(bestPages);

            }




        }

    }
}
