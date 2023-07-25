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
            FirstTask.Solution(1, 100);
            break;
        case 2:
            Console.Write("Root path : ");
            SecondTask.Solution(Console.ReadLine());
            break;
        case 3:
            ThirdTask.Solution();
            break;
        default:
            Console.WriteLine("Select task number from list");
            break;
    }
    Console.Write("Press 'e' and Enter to close the app, or press any other key and Enter to continue: ");
    if (Console.ReadLine() == "e") isEnd = true;
    Console.Clear();
} while (!isEnd);