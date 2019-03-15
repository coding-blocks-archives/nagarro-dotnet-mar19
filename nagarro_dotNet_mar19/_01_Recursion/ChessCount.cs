using System;
using System.Collections.Generic;
using System.Text;
using utils;

namespace nagarro_dotNet_mar19.recursion
{
    class ChessCount
    {
        public static bool isValidBox(int[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) &&
                   col >= 0 && col < board.GetLength(1);
        }

        public static int countWays(int[,] board, int startRow, int startCol,
                                    LinkedList<string> pathSoFar)
        {
            if (startRow == board.GetLength(0) - 1 && startCol == board.GetLength(1) - 1)
            {
                // print PathSoFar
                foreach (var node in pathSoFar)
                {
                    Console.Write($"{node}");
                }
                Console.Write(" ");
                return 1;
            }

            if (board[startRow, startCol] == -2) return 0;  // bomb
            if (board[startRow, startCol] == -1) return 1;  // port

            int totalWays = 0;

            // now behave as knight; down, down, right
            {
                int nextRow = startRow + 2;
                int nextCol = startCol + 1;
                if (isValidBox(board, nextRow, nextCol))
                {
                    pathSoFar.AddLast($"K{{{nextRow}-{nextCol}}}");
                    totalWays += countWays(board, nextRow, nextCol, pathSoFar);
                    pathSoFar.RemoveLast();

                }
            }

            // right, right, down
            {
                int nextCol = startCol + 2;
                int nextRow = startRow + 1;
                if (isValidBox(board, nextRow, nextCol))
                {
                    pathSoFar.AddLast($"K{{{nextRow}-{nextCol}}}");
                    totalWays += countWays(board, nextRow, nextCol, pathSoFar);
                    pathSoFar.RemoveLast();

                }
            }

            // if endRow/endCol behave as Rook
            if (startCol == board.GetLength(1) - 1 || startCol == 0 ||
                startRow == 0 || startRow == board.GetLength(0) - 1)
            {

                for (int step = 1; step < board.GetLength(0); ++step)
                {
                    int nextRow = startRow;
                    int nextCol = startCol + step;
                    if (isValidBox(board, nextRow, nextCol))
                    {
                        pathSoFar.AddLast($"R{{{nextRow}-{nextCol}}}");
                        totalWays += countWays(board, nextRow, nextCol, pathSoFar);
                        pathSoFar.RemoveLast();

                    }
                }

                for (int step = 1; step < board.GetLength(0); ++step)
                {
                    int nextRow = startRow + step;
                    int nextCol = startCol;

                    if (isValidBox(board, nextRow, nextCol))
                    {
                        pathSoFar.AddLast($"R{{{nextRow}-{nextCol}}}");
                        totalWays += countWays(board, nextRow, nextCol, pathSoFar);
                        pathSoFar.RemoveLast();

                    }
                }

            }

            // if diagonal behave as Bishop
            //if (startRow == startCol)
            {
                for (int step = 1; step < board.GetLength(0); ++step)
                {
                    int nextRow = startRow + step;
                    int nextCol = startCol + step;
                    if (isValidBox(board, nextRow, nextCol))
                    {
                        pathSoFar.AddLast($"B{{{nextRow}-{nextCol}}}");
                        totalWays += countWays(board, nextRow, nextCol, pathSoFar);
                        pathSoFar.RemoveLast();

                    }
                }
            }

            return totalWays;
        }

        public static void main()
        {
            int n = Utils.readInt();
            int[,] board = new int[n, n];
            LinkedList<string> pathSoFar = new LinkedList<string>();
            pathSoFar.AddLast("{0-0}");

            bool alternate = false;
            for (int i = 2; i <= n*n; ++i)
            {
                //if (isPrime(i))
                //{
                //    board[i, j] = alternate ? -1 : -2;
                //    alternate = !alternate;
                //}

            }


            int ans = countWays(board, 0, 0, pathSoFar);
            Console.WriteLine();
            Console.WriteLine(ans);
        }
    }
}
