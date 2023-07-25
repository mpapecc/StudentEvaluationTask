using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluationTask
{
    internal class ThirdTask
    {
        public static bool checkLeft(int[,] matrix, int x, int y)
        {
            return isDotOnLeftBorder(matrix, x, y) ? false : matrix[x - 1, y] == 2;
        }

        public static bool checkRight(int[,] matrix, int x, int y)
        {
            return isDotOnRightBorder(matrix, x, y) ? false : matrix[x + 1, y] == 2;
        }

        public static bool checkTop(int[,] matrix, int x, int y)
        {
            return isDotOnTopBorder(matrix, x, y) ? false : matrix[x, y - 1] == 2;
        }

        public static bool checkTopLeft(int[,] matrix, int x, int y)
        {
            return isDotOnTopBorder(matrix, x, y) || isDotOnLeftBorder(matrix, x, y)
                ? false
                : matrix[x - 1, y - 1] == 2;
        }

        public static bool checkTopRight(int[,] matrix, int x, int y)
        {
            return isDotOnTopBorder(matrix, x, y) || isDotOnRightBorder(matrix, x, y)
                ? false
                : matrix[x + 1, y - 1] == 2;
        }

        public static bool checkBottom(int[,] matrix, int x, int y)
        {
            return isDotOnBottomBorder(matrix, x, y) ? false : matrix[x, y + 1] == 2;
        }

        public static bool checkBottomLeft(int[,] matrix, int x, int y)
        {
            return isDotOnBottomBorder(matrix, x, y) || isDotOnLeftBorder(matrix, x, y)
                ? false
                : matrix[x - 1, y + 1] == 2;
        }

        public static bool checkBottomRight(int[,] matrix, int x, int y)
        {
            return isDotOnBottomBorder(matrix, x, y) || isDotOnRightBorder(matrix, x, y)
                ? false
                : matrix[x + 1, y + 1] == 2;
        }

        public static bool isDotOnTopBorder(int[,] matrix, int x, int y)
        {
            return y == 0;
        }

        public static bool isDotOnBottomBorder(int[,] matrix, int x, int y)
        {
            return matrix.Length / matrix.GetLength(0) - 1 == y;
        }

        public static bool isDotOnRightBorder(int[,] matrix, int x, int y)
        {
            return matrix.GetLength(0) - 1 == x;
        }

        public static bool isDotOnLeftBorder(int[,] matrix, int x, int y)
        {
            return x == 0;
        }

        public static bool shouldConvertDot(int[,] matrix, int x, int y)
        {

            return matrix[x, y] == 0 && (checkLeft(matrix, x, y) || checkRight(matrix, x, y) || checkBottom(matrix, x, y) || checkTop(matrix, x, y)
                || checkTopLeft(matrix, x, y) || checkTopRight(matrix, x, y) || checkBottomLeft(matrix, x, y) || checkBottomRight(matrix, x, y));
        }

        public static void markDotsForConvertion(int[,] matrix, int rows, int columns)
        {
            do
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (shouldConvertDot(matrix, i, j))
                        {
                            matrix[i, j] = 2;
                        }
                    }
                }
            }
            while (!isTaskFinished(matrix, columns, rows));
        }

        public static void convertDots(int[,] matrix, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] == 2)
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
        }

        public static void printMatrix(int[,] matrix,int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static bool isTaskFinished(int[,] matrix, int columns, int rows)
        {

            bool isTaskFinished = true;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (shouldConvertDot(matrix, i, j))
                    {
                        isTaskFinished = false;
                    }
                }
            }
            return isTaskFinished;
        }

        public static void Solution(int[,] matrix,int Px, int Py)
        {
            int r, c, i, j;
            r = matrix.GetLength(0);
            c = matrix.Length/r;
            matrix[Py, Px] = 2;

            Console.WriteLine("Printing Input Matrix: ");
            printMatrix(matrix, r, c);
            markDotsForConvertion(matrix, r, c);
            convertDots(matrix, r, c);
            Console.WriteLine("Printing Output Matrix: ");
            printMatrix(matrix, r, c); 
        }
    }
}

