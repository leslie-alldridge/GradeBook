using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class InMemoryBook : Book // book "is" a "named object" and the Name property is inherited
    {
        public List<double> grades;
        readonly string Category = "Science"; // readonly is a good way to set untouchable fields in classes
        public const int Counter = 5; // Declare a constant within the class, normal convention is to use uppercase COUNTER and to have constants public
        public string notSet { get; private set; } // outsiders cannot change "notSet"

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            return result;
        }
        public Statistics GetStatisticsDoLoop()
        {
            var result = new Statistics();
            
            var index = 0;

            do
            {
                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);
                
                index++;
            } while (index < grades.Count);

            return result;
        }
        public Statistics GetStatisticsForLoop()
        {
            var result = new Statistics();
           
            for (var index = 0; index < grades.Count; index++)
            {
                result.High = Math.Max(index, result.High);
                result.Low = Math.Min(index, result.Low);
            }

            return result;
        }
    }
}
