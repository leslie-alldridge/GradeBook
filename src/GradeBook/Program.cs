using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book();
            book.AddGrade(89.1);
            var grades = new List<double>() { 12.7, 2.4, 8.9 };
            grades.Add(56.1);
            var result = 0.00;
            foreach (var grade in grades)
            {
                result += grade;
            }
            var average = result / grades.Count;
            
            Console.WriteLine($"The final result is: {result:N1} with an average of {average:N1}");
        }
    }
}
