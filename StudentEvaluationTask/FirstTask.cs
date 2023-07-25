using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluationTask
{
    internal class FirstTask
    {
        public static void Solution(int start,int end)
        {
            
            for (int i = start; i <= end; i++)
            {

                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("Djeljiv s 3 i 5");
                    continue;
                }

                if (i%3 == 0)
                {
                    Console.WriteLine("Djeljiv s 3");
                    continue;

                }

                if (i % 5 == 0)
                {
                    Console.WriteLine("Djeljiv s 5");
                    continue;

                }

                if (i % 5 != 0 || i % 3 != 0)
                {
                    Console.WriteLine(i);
                    continue;

                }

            }
        }
    }
}
