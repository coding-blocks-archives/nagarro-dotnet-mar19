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


        public static int countWays(int[,] board, int startRow, int startCol)
        {
            if (startRow == board.GetLength(0) - 1 && startCol == board.GetLength(1) - 1)
            {
                return 1;
            }

            int totalWays = 0;

            // if diagonal behave as Bishop
            if (startRow == startCol)
            {
                int nextRow = startRow + 1;
                int nextCol = startCol + 1;
                if (isValidBox(board, nextRow, nextCol))
                {
                    totalWays += countWays(board, nextRow, nextCol);
                }
            }

            // if endRow/endCol behave as Rook
            if (startCol == board.GetLength(1) - 1)
            {
                int nextRow = startRow + 1;
                int nextCol = startCol;
                if (isValidBox(board, nextRow, nextCol))
                    totalWays += countWays(board, nextRow, nextCol);
            }

            if (startRow == 0)
            {
                int nextRow = startRow;
                int nextCol = startCol + 1;
                if (isValidBox(board, nextRow, nextCol))
                    totalWays += countWays(board, nextRow, nextCol);
            }


            // now behave as knight; down, down, right
            {
                int nextRow = startRow + 2;
                int nextCol = startCol + 1;
                if (isValidBox(board, nextRow, nextCol))
                {
                    totalWays += countWays(board, nextRow, nextCol);
                }
            }

            // right, right, down
            {
                int nextCol = startCol + 2;
                int nextRow = startRow + 1;
                if (isValidBox(board, nextRow, nextCol))
                {
                    totalWays += countWays(board, nextRow, nextCol);
                }
            }

            return totalWays;
        }

        public static void main()
        {
            int n = Utils.readInt();
            int[,] board = new int[n, n];

            int ans = countWays(board, 0, 0);
            Console.WriteLine(ans);
        }
    }
}
