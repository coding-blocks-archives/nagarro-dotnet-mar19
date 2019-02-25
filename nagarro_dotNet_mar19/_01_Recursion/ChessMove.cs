using System;
using System.Collections.Generic;
using System.Text;

namespace nagarro_dotNet_mar19.recursion
{
    public class ChessMove
    {
        public static void main()
        {
            int[,] board = new int[8, 8];
            bool[,] visited = new bool[8, 8];
            KnightMove(board, 0, 0, visited);
            PrintMat(board, 8, 8);
        }

        public static void PrintMat(int[,] mat, int maxRow, int maxCol)
        {
            for (int r = 0; r < maxRow; ++r)
            {
                for (int c = 0; c < maxCol; ++c)
                {
                    Console.Write($"{mat[r, c]}\t");
                }
                Console.WriteLine();
            }
        }

        public static bool KnightMove(int[,] board, int rowIdx, int colIdx, bool[,] visited)
        {
            if (board[rowIdx, colIdx] == 63) return true;

            int[] xDir = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] yDir = { 1, 2, 2, 1, -1, -2, -2, -1 };

            for (int i = 0; i < 8; ++i)
            {
                int nextRow = rowIdx + xDir[i];
                int nextCol = colIdx + yDir[i];
                bool isValid = nextRow < 8 && nextCol < 8 && nextRow >=0 && nextCol >= 0;
                if (isValid && visited[nextRow, nextCol] == false)
                {
                    visited[nextRow, nextCol] = true;
                    board[nextRow, nextCol] = board[rowIdx, colIdx] + 1;
                    bool success = KnightMove(board, nextRow, nextCol, visited);
                    if (success == true)
                    {
                        return true;
                    }
                    else
                    {
                        visited[nextRow, nextCol] = false;
                        board[nextRow, nextCol] = 0;
                    }
                }
            }
            return false;
        }
    }
}
