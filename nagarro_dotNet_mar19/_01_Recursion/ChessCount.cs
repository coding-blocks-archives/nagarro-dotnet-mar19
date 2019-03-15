using System;
using System.Collections.Generic;
using System.Text;
using utils;

namespace nagarro_dotNet_mar19.recursion
{
    class ChessCount
    {
        enum Mario
        {
            Bomb = 1,
            Port = 2
        };


        public static bool isValidBox(int[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) &&
                   col >= 0 && col < board.GetLength(1) &&
                   board[row, col] != (int)Mario.Bomb;
        }

        public static int countWays(int[,] board, int startRow, int startCol,
                                    LinkedList<string> pathSoFar)
        {
            // Get Chess Count 1 from version control
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

            int totalWays = 0;

            if (board[startRow, startCol] == (int)Mario.Port)
            {
                // print PathSoFar
                int n = board.GetLength(0) - 1;
                pathSoFar.AddLast($"P{{{n}-{n}}}");
                foreach (var node in pathSoFar)
                {
                    // I know I should write it as a function but who cares! Dang!!
                    Console.Write($"{node}");
                }
                pathSoFar.RemoveLast();
                Console.Write(" ");
                totalWays += 1;  // port
            }

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
            // Dang...Dang!!! I was missing that in the seconday diagonal bishop can move diagonally 
            // such that the move is +ve.  
            // Second Diagonal Condition: {startRow + startCol == board.GetLength(0) - 1}
            if (startRow == startCol || startRow + startCol == board.GetLength(0) - 1)
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

            // we can use seive of Erasosthenes but root(N) is good enough
            bool alternate = false;
            int cellNo = 1;
            for (int row = 0; row < n; ++row)
            {
                for (int col = 0; col < n; ++col)
                {
                    if (isPrime(cellNo))
                    {
                        board[row, col] = alternate ? (int)Mario.Port : (int)Mario.Bomb;
                        alternate = !alternate;
                    }
                    ++cellNo;
                }
            }

            int ans = countWays(board, 0, 0, pathSoFar);
            Console.WriteLine();
            Console.WriteLine(ans);
        }

        public static bool isPrime(int n)
        {
            if (n == 1) return false;
            for (int i = 2; i * i <= n; ++i)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}
