using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluationTask
{
    internal class ThirdTask
    {
        public static bool left(int[,] matrix, int x, int y)
        {
            return isDotOnLeftBorder(matrix, x, y) ? false : matrix[x - 1, y] == 2 || matrix[x - 1, y] == 3;
        }

        public static bool right(int[,] matrix, int x, int y)
        {
            return isDotOnRightBorder(matrix, x, y) ? false : matrix[x + 1, y] == 2 || matrix[x + 1, y] == 3;
        }

        public static bool top(int[,] matrix, int x, int y)
        {
            return isDotOnTopBorder(matrix, x, y) ? false : matrix[x, y - 1] == 2 || matrix[x, y - 1] == 3;
        }

        public static bool topLeft(int[,] matrix, int x, int y)
        {
            return isDotOnTopBorder(matrix, x, y) || isDotOnLeftBorder(matrix, x, y)
                ? false
                : matrix[x - 1, y - 1] == 2 || matrix[x - 1, y - 1] == 3;
        }

        public static bool topRight(int[,] matrix, int x, int y)
        {
            return isDotOnTopBorder(matrix, x, y) || isDotOnRightBorder(matrix, x, y)
                ? false
                : matrix[x + 1, y - 1] == 2 || matrix[x + 1, y - 1] == 3;
        }

        public static bool bottom(int[,] matrix, int x, int y)
        {
            return isDotOnBottomBorder(matrix, x, y) ? false : matrix[x, y + 1] == 2 || matrix[x, y + 1] == 3;
        }

        public static bool bottomLeft(int[,] matrix, int x, int y)
        {
            return isDotOnBottomBorder(matrix, x, y) || isDotOnLeftBorder(matrix, x, y)
                ? false
                : matrix[x - 1, y + 1] == 2 || matrix[x - 1, y + 1] == 3;
        }

        public static bool bottomRight(int[,] matrix, int x, int y)
        {
            return isDotOnBottomBorder(matrix, x, y) || isDotOnRightBorder(matrix, x, y)
                ? false
                : matrix[x + 1, y + 1] == 2 || matrix[x + 1, y + 1] == 3;
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

            return matrix[x, y] == 0 && (left(matrix, x, y) || right(matrix, x, y) || bottom(matrix, x, y) || top(matrix, x, y)
                || topLeft(matrix, x, y) || topRight(matrix, x, y) || bottomLeft(matrix, x, y) || bottomRight(matrix, x, y));
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

        public static void Solution()
        {
            int r, c, i, j, Px, Py;
            {

                int[,] matrix =
                {
                { 1, 1, 0, 0, 1, 1, 0, 0, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 0, 0, 1, 1, 0, 0, 1, 1 },
                { 1, 1, 1, 1, 1, 0, 0, 0, 1, 1 },
                { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
                { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 1, 0, 0, 1, 1, 0, 0, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            };

                r = 8;
                c = 10;
                Console.WriteLine("Type a number that represent x coordinate of dot inside matrix");

                int num1 = Convert.ToInt32(Console.ReadLine());
                Px = num1;

                Console.WriteLine("Type a number that represent y coordinate of dot inside matrix");
                int num2 = Convert.ToInt32(Console.ReadLine());
                Py = num2;

                matrix[Py, Px] = 2;

                Console.WriteLine("Printing Input Matrix: ");
                for (i = 0; i < r; i++)
                {
                    for (j = 0; j < c; j++)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }

                do
                {
                    for (i = 0; i < r; i++)
                    {
                        for (j = 0; j < c; j++)
                        {
                            if (shouldConvertDot(matrix, i, j))
                            {
                                matrix[i, j] = 2;
                            }
                        }
                    }
                }
                while (!isTaskFinished(matrix, c, r));


                for (i = 0; i < r; i++)
                {
                    for (j = 0; j < c; j++)
                    {
                        if (matrix[i, j] == 2)
                        {
                            matrix[i, j] = 1;
                        }
                    }
                }

                Console.WriteLine("Printing Output Matrix: ");
                for (i = 0; i < r; i++)
                {
                    for (j = 0; j < c; j++)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
