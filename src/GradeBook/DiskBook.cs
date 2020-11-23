using System;
using System.IO;

namespace GradeBook
{
    class DiskBook : Book
    {
        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            Console.WriteLine(result);
            return result;
        }

        public override event GradeAddedDelegate GradeAdded;

        public DiskBook(string name) : base(name)
        {
            Name = name;
        }
    }
}
