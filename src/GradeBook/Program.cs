using System;
using static System.Console;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Leslie's Book");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);
        }

        private static void EnterGrades(IBook book)
        {
            do
            {
                WriteLine($"Please enter the grade for: {book.Name}, or press Q to quit.");
                var input = ReadLine();
                double.TryParse(input, out double grade);

                if (grade <= 100 && grade > 0)
                {
                    try
                    {
                        book.AddGrade(grade);
                    }
                    catch (ArgumentException ex)
                    {
                        WriteLine(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        WriteLine(ex.Message);
                    }
                    finally
                    {
                        WriteLine("**");
                    }
                }
                else
                {
                    var result = book.GetStatistics();
                    WriteLine($"Average: {result.Average:N1}, Max: {result.High:N1}, Min: {result.Low:N1}, Letter: {result.Letter}");
                    WriteLine("Exiting..");
                    break;
                }
            }
            while (true);
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            WriteLine("A grade was added!");
        }
    }
}
