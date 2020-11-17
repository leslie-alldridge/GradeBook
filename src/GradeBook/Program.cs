using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 12.7, 2.4, 8.9 };
            var result = 0.0;
            foreach (double num in numbers)
            {
                result += num;
            }
            Console.WriteLine($"The final result is {result}");

            if (args.Length > 0){
                Console.WriteLine($"Hello {args[0]}!");
            }
            else
            {
                Console.WriteLine("Hello!");
            }
        }
    }
}
