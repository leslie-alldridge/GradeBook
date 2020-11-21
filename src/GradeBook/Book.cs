using System;
using static System.Console;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        private string name;
        private double result = 0.00;
        private double highGrade = double.MinValue;
        private double lowGrade = double.MaxValue;
        private double average;

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {
            foreach (var grade in grades)
            {
                highGrade = Math.Max(grade, highGrade);
                lowGrade = Math.Min(grade, lowGrade);
                result += grade;
            }
            average = result / grades.Count;

            WriteLine($"Statistics for Book: {name}");
            WriteLine($"Average: {average}");
            WriteLine($"Min score: {lowGrade}");
            WriteLine($"Max score: {highGrade}");
        }

    }
}
