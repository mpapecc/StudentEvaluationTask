// See https://aka.ms/new-console-template for more information
using StudentEvaluationTask;

bool isEnd = false;
do
{
    Console.WriteLine("Choose an option from the following list:");
    Console.WriteLine("\t1 - Write numbers within range to console and check their divisibility");
    Console.WriteLine("\t2 - Write file tree of directory");
    Console.WriteLine("\t3 - Color all neighbours of given point");
    Console.WriteLine("\tPress Esc for end");

    Console.Write("Your option?");

    switch (Convert.ToInt32(Console.ReadLine()))
    {
        case 1:
            Console.WriteLine("Type start of range");
            int start = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Type end of range");
            int end = Convert.ToInt32(Console.ReadLine());

            if (start >= end)
            {
                Console.Clear();
                Console.WriteLine("Start must be greater then end");
                continue;
            }
            FirstTask.Solution(start, end);
            break;
        case 2:
            Console.Write("Root path : ");
            string path = Console.ReadLine();
            if(SecondTask.IsFile(path) || SecondTask.IsDirectory(path)) 
            {
                SecondTask.Solution(path);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Path is not file or directory");
                continue;
            }
            break;
        case 3:
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
           
            int r = matrix.GetLength(0);
            int c = matrix.Length / r;

            Console.WriteLine($"Type a number that represent x coordinate of dot inside matrix beetwen 0 and {c-1}");
            int Px = Convert.ToInt32(Console.ReadLine());
            if (Px > c)
            {
                Console.Clear();
                Console.WriteLine($"Select x coordinate inside matrix width ({c})");
                continue;
            }

            Console.WriteLine($"Type a number that represent y coordinate of dot inside matrix beetwen 0 and {r-1}");
            int Py = Convert.ToInt32(Console.ReadLine());
            if (Py > c)
            {
                Console.Clear();
                Console.WriteLine($"Select y coordinate inside matrix height ({r})");
                continue;
            }

            ThirdTask.Solution(matrix,Px,Py);
            break;
        default:
            Console.WriteLine("Select task number from list");
            break;
    }
    Console.Write("Press 'e' and Enter to close the app, or press any other key and Enter to continue: ");
    if (Console.ReadLine() == "e")
    {
        isEnd = true;
    }
    Console.Clear();
} while (!isEnd);