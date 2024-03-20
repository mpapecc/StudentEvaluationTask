using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluationTask
{
    internal class ThirdTask
    {
      
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

        private static void MarkRecurssion(int[,] matrix, int Px, int Py)
        {
            if(Px>=matrix.GetLength(0) || Px < 0)
            {
                return;
            }

            if (Py >= matrix.GetLength(1) || Py < 0)
            {
                return;
            }

            if (matrix[Px,Py] == 1)
            {
                return;
            }
            matrix[Px, Py] = 1;

            MarkRecurssion(matrix, Px + 1, Py);

            MarkRecurssion(matrix, Px - 1, Py);

            MarkRecurssion(matrix, Px , Py+1);

            MarkRecurssion(matrix, Px, Py-1);


        }

        public static void Solution(int[,] matrix,int Px, int Py)
        {
            int r, c, i, j;
            r = matrix.GetLength(0);
            c = matrix.Length/r;
            matrix[Py, Px] = 2;

            Console.WriteLine("Printing Input Matrix: ");
            printMatrix(matrix, r, c);
            MarkRecurssion(matrix, Px, Py);
            Console.WriteLine("Printing Output Matrix: ");
            printMatrix(matrix, r, c); 
        }
    }
}

